using DevExpress.XtraSpreadsheet.Model;
using HW_Thermal_Tools.Forms.keithley2306;
using DevExpress.XtraCharts.Native;
using System.Collections.Generic;


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

            if (!ConnectedStatu)
            {
                MessageBox.Show("未连接");
            }
            else
            {
                this.NiVisa.OpenSession();
                this.NiVisa.SelectChannel(Combox_Channel.Text);
                this.NiVisa.SetVoltage(ComboBox_Voltage_Select.Text);
                this.NiVisa.OutPut_On();
                MessageBox.Show("Session 会话已开启");
            }

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

                await Task.Delay(1000); // 每100毫秒读取一次


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



        public void updateChart()
        {



            //调用Chart的RefreshData()方法刷新数据显示
            //ChartControl_Watchdog.RefreshData();
            ChartControl_Watchdog.Refresh();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            StartReadData();
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            StopReadData();
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
    }

}
