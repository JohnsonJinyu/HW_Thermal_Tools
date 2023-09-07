using DevExpress.XtraSpreadsheet.Model;
using HW_Thermal_Tools.Forms.keithley2306;
using DevExpress.XtraCharts.Native;
using System.Collections.Generic;
using DevExpress.CodeParser;
using OfficeOpenXml;
using System.Diagnostics;

namespace HW_Thermal_Tools.Forms
{

    public partial class Keithley2306Form : DevExpress.XtraEditors.XtraForm
    {



        // 创建一个布尔变量来记录设备的连接状态
        private bool ConnectedStatu;
        // 定义一个私有的布尔变量，用来表示是否需要继续检测设备的变化
        private static volatile bool CheckSignal = true;
        // 定义私有布尔变量，表示是否继续读取数据
        private static volatile bool ReadSignal = false;
        // 定义两个后台任务
        private Task CheckDeviceTask;
        private Task ReadDataTask;
        // 定义2个私有的字段，用来存储取消令牌源
        private CancellationTokenSource CheckCTS;
        private CancellationTokenSource ReadCTS;

        public NiVisaFunction NiVisa { get; set; } //这里声明Visa属性

        //定义一个采集频率的常量
        private static int ReadFrequence;

        //定义数据Grid的列索引
        private int ItemCol, MinValueCol, MaxValueCol, CurrentValueCol, AverageValueCol;


        public Keithley2306Form(NiVisaFunction niVisaFunction)
        {
            InitializeComponent();
            this.NiVisa = niVisaFunction; //构造函数中初始化



            //初始化两个布尔变量为false
            CheckSignal = false;
            ReadSignal = false;

            //初始化列的索引
            MinValueCol = 0;
            MaxValueCol = 1;
            CurrentValueCol = 2;
            AverageValueCol = 3;

        }



        private void keithley2306_Load(object sender, EventArgs e)
        {
            InitialGrid_WatchDog();
            InitialChart();
            //启动后台线程检测设备变化
            StartDetection();


        }







        private void Btn_Power_Off_Click(object sender, EventArgs e)
        {
            this.NiVisa.OutPut_Off();
        }

        private void Btn_Power_On_Click(object sender, EventArgs e)
        {
            if (RadioButton_PowerTest.Checked == true)
            {
                if (!ConnectedStatu)
                {
                    MessageBox.Show("未连接设备");
                }
                else
                {
                    this.NiVisa.OpenSession();
                    this.NiVisa.SelectChannel(Combox_Channel.Text);
                    this.NiVisa.SetVoltage(ComboBox_Voltage_Select.Text);
                    this.NiVisa.SetCurrent_Lim(Combox_CurrentLim_Select.Text);
                    this.NiVisa.OutPut_On();
                    MessageBox.Show("Session 会话已开启");
                }
            }


        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (this.NiVisa.data.CurrentHistory.Count > 0)
            {
                Save_OriData();
            }
            else
            {
                MessageBox.Show("当前暂无数据可以保存！");
            }
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            StartReadData();
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            StopReadData();
        }





        private void Keithley2306Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //当Form closed时，关闭session会话和Task

            CheckSignal = false;
            // 发送取消信号给后台任务
            CheckCTS.Cancel();

            // 等待后台任务结束
            CheckDeviceTask.Wait();

            //关闭Session会话
            this.NiVisa.DisposeSession();

        }


        // 定义一个方法，初始化采集数据显示的表格
        public void InitialGrid_WatchDog()
        {
            DataGridView_WhatchDog.Rows.Add(2);


            //将dataGridView 的RowHeader设定
            DataGridView_WhatchDog.Rows[0].HeaderCell.Value = "Current";
            DataGridView_WhatchDog.Rows[1].HeaderCell.Value = "Voltage";
            DataGridView_WhatchDog.Rows[2].HeaderCell.Value = "Power";
        }
        //定义一个方法,初始化数据曲线图
        public void InitialChart()
        {

            // 设置Current Series的属性
            ChartControl_Watchdog.Series["Current"].DataSource = this.NiVisa.data.CurrentHistory;
            //ChartControl_Watchdog.Series["Current"].SeriesDataMember = "Current"; // 指定Series的名称
            ChartControl_Watchdog.Series["Current"].ArgumentDataMember = "Time"; // 指定Series的横轴数据
            ChartControl_Watchdog.Series["Current"].ValueDataMembers.AddRange(new string[] { "Value" }); // 指定Series的纵轴数据

            // 设置Voltage Series的属性
            ChartControl_Watchdog.Series["Voltage"].DataSource = this.NiVisa.data.VoltageHistory;
            //ChartControl_Watchdog.Series["Voltage"].SeriesDataMember = "Voltage"; // 指定Series的名称
            ChartControl_Watchdog.Series["Voltage"].ArgumentDataMember = "Time"; // 指定Series的横轴数据
            ChartControl_Watchdog.Series["Voltage"].ValueDataMembers.AddRange(new string[] { "Value" }); // 指定Series的纵轴数据

            // 设置Power Series的属性
            ChartControl_Watchdog.Series["Power"].DataSource = this.NiVisa.data.PowerHistory;
            //ChartControl_Watchdog.Series["Power"].SeriesDataMember = "Power"; // 指定Series的名称
            ChartControl_Watchdog.Series["Power"].ArgumentDataMember = "Time"; // 指定Series的横轴数据
            ChartControl_Watchdog.Series["Power"].ValueDataMembers.AddRange(new string[] { "Value" }); // 指定Series的纵轴数据

        }


        //定义一个方法，用来初始化采集频率
        public void Initial_ReadFreq()
        {
            switch (ComboBox_DataFrequence.Text)
            {
                case "250 ms / 次":
                    ReadFrequence = 250;
                    break;
                case "500 ms / 次":
                    ReadFrequence = 250;
                    break;
                case "1 S / 次":
                    ReadFrequence = 250;
                    break;
                case "2 S / 次":
                    ReadFrequence = 250;
                    break;
                case "5 S / 次":
                    ReadFrequence = 250;
                    break;
                case "10 S / 次":
                    ReadFrequence = 250;
                    break;

            }
        }




        // 定义一个公共的方法，用来启动check()任务
        public void StartDetection()
        {
            // 设置running变量为true，表示需要继续检测
            CheckSignal = true;

            // 创建一个取消令牌源
            CheckCTS = new CancellationTokenSource();

            // 获取取消令牌
            var token = CheckCTS.Token;

            // 使用Task类的Run方法来创建并启动一个后台线程，并传入DectionAndUpdateUITask方法和取消令牌作为参数

            CheckDeviceTask = Task.Run(() => DectionAndUpdateUITask(token), token);

        }

        private void DectionAndUpdateUITask(CancellationToken token)
        {
            while (CheckSignal)
            {
                ConnectedStatu = this.NiVisa.Detection_Thread();
                // 如果connected为true，表示设备已连接
                if (ConnectedStatu)
                {
                    // 使用Invoke方法来更新界面上的控件或触发事件，例如：
                    Invoke(new Action(() =>
                    {
                        StatusLabel_DeviceStatus.Text = "Connected";
                        StatusLabel_DeviceStatus.BackColor = Color.Green;
                    }));
                }
                else
                {
                    // 使用Invoke方法来更新界面上的控件或触发事件，例如：
                    Invoke(new Action(() =>
                    {
                        StatusLabel_DeviceStatus.Text = "DisConnected";
                        StatusLabel_DeviceStatus.BackColor = Color.Red;
                    }));
                }

                // 在循环中检查取消令牌是否已经被取消，如果是，则退出循环
                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }


        //定义一个方法，用来启动ReadData()后台任务
        public void StartReadData()
        {
            //设置ReadSignal 为 true ,表示需要运行ReadData()后台任务
            ReadSignal = true;

            // 创建一个取消令牌
            ReadCTS = new CancellationTokenSource();

            //get cancel token
            var token = ReadCTS.Token;

            // 使用Task类的 Run方法来创建并启动一个后台任务，并传入ReadData方法和取消令牌作为参数
            ReadDataTask = Task.Run(() => ReadData(token), token);
        }

        //定义一个方法，用来停止ReadDta方法
        public void StopReadData()
        {
            // 设置ReadSignal 为false ，表示不需要运行ReadData任务
            ReadSignal = false;
            //发送取消信号给ReadData()后台任务
            ReadCTS.Cancel();
            // 等待readData()后台任务结束
            ReadDataTask.Wait();
            // 释放资源
            ReadCTS.Dispose();
        }


        // 定义一个方法，用来在后台执行 readData() 方法
        public async void ReadData(CancellationToken token)
        {
            while (true)
            {
                // 调用 NI_VISA_Function 类中的 readData() 方法，执行读取电流电压的操作
                this.NiVisa.ReadData();
                //计算数据
                this.NiVisa.CalculatedReaData();

                Invoke(new Action(() =>
                {
                    updateGridView();
                    ChartControl_Watchdog.RefreshData();

                }));

                await Task.Delay(ReadFrequence); // 每100毫秒读取一次


                // 在循环中检查取消令牌是否已经被取消，如果是，则退出循环
                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }



        //定义一个更新表格的方法

        public void updateGridView()
        {
            //DataGridView_WhatchDog.Rows[0].Cells[ItemCol].Value = "Current";
            DataGridView_WhatchDog.Rows[0].Cells[MinValueCol].Value = this.NiVisa.data.CurrentMin;
            DataGridView_WhatchDog.Rows[0].Cells[MaxValueCol].Value = this.NiVisa.data.CurrentMax;
            DataGridView_WhatchDog.Rows[0].Cells[CurrentValueCol].Value = this.NiVisa.data.Current;
            DataGridView_WhatchDog.Rows[0].Cells[AverageValueCol].Value = this.NiVisa.data.CurrentAve;

            //DataGridView_WhatchDog.Rows[1].Cells[ItemCol].Value = "Voltage";
            DataGridView_WhatchDog.Rows[1].Cells[MinValueCol].Value = this.NiVisa.data.VoltageMin;
            DataGridView_WhatchDog.Rows[1].Cells[MaxValueCol].Value = this.NiVisa.data.VoltageMax;
            DataGridView_WhatchDog.Rows[1].Cells[CurrentValueCol].Value = this.NiVisa.data.Voltage;
            DataGridView_WhatchDog.Rows[1].Cells[AverageValueCol].Value = this.NiVisa.data.VoltageAve;

            // DataGridView_WhatchDog.Rows[2].Cells[ItemCol].Value = "Power";
            DataGridView_WhatchDog.Rows[2].Cells[MinValueCol].Value = this.NiVisa.data.PowerMin;
            DataGridView_WhatchDog.Rows[2].Cells[MaxValueCol].Value = this.NiVisa.data.PowerMax;
            DataGridView_WhatchDog.Rows[2].Cells[CurrentValueCol].Value = this.NiVisa.data.Power;
            DataGridView_WhatchDog.Rows[2].Cells[AverageValueCol].Value = this.NiVisa.data.PowerAve;
        }



        




        /*
         控制曲线的显示选项
         */
        private void CheckBox_CurrentLineDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ChartControl_Watchdog.Series["Current"].Visible = CheckBox_CurrentLineDisplay.Checked;
        }

        private void CheckBox_VoltageLineDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ChartControl_Watchdog.Series["Voltage"].Visible = CheckBox_VoltageLineDisplay.Checked;
        }

        private void CheckBox_PowerLineDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ChartControl_Watchdog.Series["Power"].Visible = CheckBox_PowerLineDisplay.Checked;
        }



        //定义一个方法用来保存数据
        public void Save_OriData()
        {
            // 创建一个SaveFileDialog对象，用于让用户选择保存目录和文件名称
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"; // 设置文件过滤器，只显示xlsx格式的文件
            saveFileDialog.Title = "保存数据到Excel"; // 设置对话框的标题
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // 声明非商用许可证
            if (saveFileDialog.ShowDialog() == DialogResult.OK) // 如果用户点击了保存按钮
            {
                var file = new FileInfo(saveFileDialog.FileName); // 创建一个FileInfo对象，指定文件路径

                using (var package = new ExcelPackage(file)) // 创建一个ExcelPackage对象
                {
                    var ws = package.Workbook.Worksheets.Add("Data_Test_Worksheet"); // 创建一个工作表

                    // 将OriDataHistory列表中的数据加载到工作表中，从第一行第一列开始
                    ws.Cells["A1"].LoadFromCollection(this.NiVisa.data.OriDataHistory, true);

                    package.SaveAs(file); // 将excel文件保存到指定的路径
                }

                MessageBox.Show("保存成功！");

            }
          
        }
      
    }

}
