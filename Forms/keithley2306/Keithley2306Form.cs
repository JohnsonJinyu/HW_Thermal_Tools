using DevExpress.XtraGauges.Win;
using HW_Thermal_Tools.Forms.keithley2306;
using HZH_Controls;
using OfficeOpenXml;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;

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
        // 定义1个后台任务

        private Task ReadDataTask;
        // 定义2个私有的字段，用来存储取消令牌源
        private CancellationTokenSource CheckCTS;
        private CancellationTokenSource ReadCTS;

        public NiVisaFunction NiVisa { get; set; } //这里声明Visa属性

        //定义一个采集频率的常量
        private static int ReadFrequence;

        //定义数据Grid的列索引
        private int MinValueCol, MaxValueCol, CurrentValueCol, AverageValueCol;




        private DeviceDetectionService service;


        // 定义一个变量来记录计时器的运行时间
        private int seconds = 0;


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

            // 创建一个 DeviceDetectionService 的实例
            service = new DeviceDetectionService();

            // 调用 SubscribeToDeviceDetection 方法，并传入 service 实例
            SubscribeToDeviceDetection(service);


        }



        private async void keithley2306_Load(object sender, EventArgs e)
        {
            InitialGrid_WatchDog();
            InitialChart();
            // 异步开始检测设备连接状态
            await service.StartAsync(CancellationToken.None);
            LoadTheme();


        }

        private void LoadTheme()
        {

            //通过这种方式获取
            foreach (System.Windows.Forms.Control control in TablePanel_Control.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button btn = (Button)control;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

        }



        private void Btn_Power_Off_Click(object sender, EventArgs e)
        {
            this.NiVisa.OutPut_Off();

        }

        private void Btn_Power_On_Click(object sender, EventArgs e)
        {
            //功能实现前弹窗提醒 模式选择的没有错误
            if (DataGridView_ChargeInput.Rows.Count > 1)
            {
                // 弹出确认框
                DialogResult result = MessageBox.Show("确认功能是否选择正确？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }


            }

            if (!ConnectedStatu)
            {
                MessageBox.Show("未连接设备");
            }
            else if (RadioButton_PowerTest.Checked == true)
            {
                this.NiVisa.OpenSession();
                this.NiVisa.SelectChannel(Combox_Channel.Text);
                this.NiVisa.SetVoltage(ComboBox_Voltage_Select.Text);
                this.NiVisa.SetCurrent_Lim(Combox_CurrentLim_Select.Text);
                this.NiVisa.OutPut_On();
                MessageBox.Show("Session 会话已开启");
            }
            else if (RadioButton_ChargeTest.Checked == true)
            {

                if (DataGridView_ChargeInput.Rows.Count == 1)
                {
                    MessageBox.Show("请先输入充电电流 电压 时间！！！");
                }
                else
                {
                    this.NiVisa.OpenSession();
                    MessageBox.Show("Session 会话已开启");
                    // 创建一个BackgroundWorker组件
                    BackgroundWorker worker = new BackgroundWorker();
                    // 设置worker可以报告进度
                    worker.WorkerReportsProgress = true;
                    // 在DoWork事件中执行耗时的充电操作
                    worker.DoWork += (s, e) =>
                    {
                        // 获取worker的引用
                        BackgroundWorker bw = s as BackgroundWorker;
                        // 遍历DataGridView_ChargeInput的所有行
                        for (int i = 0; i < DataGridView_ChargeInput.Rows.Count - 1; i++)
                        {
                            // 判断是否已经输出了电压和电流
                            if (this.NiVisa.IsOutputOn())
                            {
                                // 使用Invoke方法，在主线程上访问Combox_Channel控件
                                this.Invoke((Action)delegate
                                {
                                    this.NiVisa.SelectChannel(Combox_Channel.Text);
                                });
                                this.NiVisa.SetVoltage(DataGridView_ChargeInput.Rows[i].Cells["Charge_Voltage"].Value.ToString());
                                this.NiVisa.SetCurrent_Lim(DataGridView_ChargeInput.Rows[i].Cells["Charge_Current"].Value.ToString());
                            }
                            else
                            {
                                // 使用Invoke方法，在主线程上访问Combox_Channel控件
                                this.Invoke((Action)delegate
                                {
                                    this.NiVisa.SelectChannel(Combox_Channel.Text);
                                });
                                this.NiVisa.SetVoltage(DataGridView_ChargeInput.Rows[i].Cells["Charge_Voltage"].Value.ToString());
                                this.NiVisa.SetCurrent_Lim(DataGridView_ChargeInput.Rows[i].Cells["Charge_Current"].Value.ToString());
                                this.NiVisa.OutPut_On();
                            }
                            // 持续多长时间
                            Thread.Sleep(DataGridView_ChargeInput.Rows[i].Cells["Charge_Time"].Value.ToInt() * 1000);
                            // 报告进度，传递当前行的索引和充电时间
                            bw.ReportProgress(i, DataGridView_ChargeInput.Rows[i].Cells["Charge_Time"].Value.ToInt());
                        }
                    };
                    // 在ProgressChanged事件中访问或修改控件，显示充电进度
                    worker.ProgressChanged += (s, e) =>
                    {
                        // 获取当前行的索引和充电时间
                        int index = e.ProgressPercentage;
                        int time = (int)e.UserState;
                        // 显示充电进度信息
                        Label_Progress.Text = $"正在执行第{index + 1}行充电操作，持续{time}秒";
                    };
                    // 在RunWorkerCompleted事件中访问或修改控件，显示充电完成信息
                    worker.RunWorkerCompleted += (s, e) =>
                    {
                        // 显示充电完成信息
                        Label_Progress.Text = "所有充电操作已完成";
                    };
                    // 启动worker
                    worker.RunWorkerAsync();
                }
            }

        }






        private void Btn_Start_Click(object sender, EventArgs e)
        {
            Initial_ReadFreq();
            // 如果有数据则清零
            if (seconds > 0)
            {
                seconds = 0;
                digitalGauge1.Text = "00:00:00";
            }

            // 启动计时器
            timer1.Start();

            //如果已有数据 需要清空
            if (this.NiVisa.data.OriDataHistory.Count > 0)
            {
                this.NiVisa.data.OriDataHistory.Clear();
                this.NiVisa.data.CurrentHistory.Clear();
                this.NiVisa.data.VoltageHistory.Clear();
                this.NiVisa.data.PowerHistory.Clear();
            }

            StartReadData();

            //禁用按钮，避免误触
            Btn_Start.Enabled = false;
            Btn_Stop.Enabled = true;
            Btn_Power_Off.Enabled = false;
            Btn_Save.Enabled = false;
            Combox_Channel.Enabled = false;
            Combox_CurrentLim_Select.Enabled = false;
            ComboBox_Voltage_Select.Enabled = false;
            ComboBox_DataFrequence.Enabled = false;


        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {

            StopReadData();
            // 停止计时
            timer1.Stop();
            //启用按钮
            Btn_Start.Enabled = true;
            Btn_Stop.Enabled = false;
            Btn_Power_Off.Enabled = true;
            Btn_Save.Enabled = true;
            Combox_Channel.Enabled = true;
            Combox_CurrentLim_Select.Enabled = true;
            ComboBox_Voltage_Select.Enabled = true;
            ComboBox_DataFrequence.Enabled = true;
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


        private void Keithley2306Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //当Form closed时，关闭session会话和Task


            //关闭Session会话
            //this.NiVisa.DisposeSession();

        }


        // 定义一个方法，初始化采集数据显示的表格
        public void InitialGrid_WatchDog()
        {
            DataGridView_WhatchDog.Rows.Add(2);
            //将dataGridView 的RowHeader设定
            DataGridView_WhatchDog.Rows[0].HeaderCell.Value = "Current(mA)";
            DataGridView_WhatchDog.Rows[1].HeaderCell.Value = "Voltage(V)";
            DataGridView_WhatchDog.Rows[2].HeaderCell.Value = "Power(mW)";
        }
        //定义一个方法,初始化数据曲线图
        public void InitialChart()
        {

            // 设置Current Series的属性
            ChartControl_Watchdog.Series["Current(mA)"].DataSource = this.NiVisa.data.CurrentHistory;
            //ChartControl_Watchdog.Series["Current"].SeriesDataMember = "Current"; // 指定Series的名称
            ChartControl_Watchdog.Series["Current(mA)"].ArgumentDataMember = "Time"; // 指定Series的横轴数据
            ChartControl_Watchdog.Series["Current(mA)"].ValueDataMembers.AddRange(new string[] { "Value" }); // 指定Series的纵轴数据

            // 设置Voltage Series的属性
            ChartControl_Watchdog.Series["Voltage(V)"].DataSource = this.NiVisa.data.VoltageHistory;
            //ChartControl_Watchdog.Series["Voltage"].SeriesDataMember = "Voltage"; // 指定Series的名称
            ChartControl_Watchdog.Series["Voltage(V)"].ArgumentDataMember = "Time"; // 指定Series的横轴数据
            ChartControl_Watchdog.Series["Voltage(V)"].ValueDataMembers.AddRange(new string[] { "Value" }); // 指定Series的纵轴数据

            // 设置Power Series的属性
            ChartControl_Watchdog.Series["Power(mW)"].DataSource = this.NiVisa.data.PowerHistory;
            //ChartControl_Watchdog.Series["Power"].SeriesDataMember = "Power"; // 指定Series的名称
            ChartControl_Watchdog.Series["Power(mW)"].ArgumentDataMember = "Time"; // 指定Series的横轴数据
            ChartControl_Watchdog.Series["Power(mW)"].ValueDataMembers.AddRange(new string[] { "Value" }); // 指定Series的纵轴数据

        }


        //定义一个方法，用来初始化采集频率
        public void Initial_ReadFreq()
        {
            switch (ComboBox_DataFrequence.Text)
            {
                case "100 ms / 次":
                    ReadFrequence = 100;
                    break;
                case "250 ms / 次":
                    ReadFrequence = 250;
                    break;
                case "500 ms / 次":
                    ReadFrequence = 500;
                    break;
                case "1 S / 次":
                    ReadFrequence = 1000;
                    break;
                case "2 S / 次":
                    ReadFrequence = 2000;
                    break;
                case "5 S / 次":
                    ReadFrequence = 5000;
                    break;
                case "10 S / 次":
                    ReadFrequence = 10000;
                    break;

            }
        }



        // 在 Form 类中定义一个方法，用于订阅 DeviceDetectionService 类的自定义事件，并实现事件处理器的逻辑
        void SubscribeToDeviceDetection(DeviceDetectionService service)
        {
            // 使用 += 运算符订阅自定义事件，并指定一个匿名方法作为事件处理器
            service.DeviceDetectionChanged += (sender, e) =>
            {
                // 在事件处理器中，获取事件参数中的检测结果
                bool result = e.IsConnected;

                // 根据检测结果更新 UI 或执行其他操作
                if (result)
                {
                    // 设备已连接，更新 UI 或执行其他操作
                    // 例如，将 ConnectedStatu 变量设置为 true，并显示连接成功的提示信息
                    ConnectedStatu = true;
                    //MessageBox.Show("设备已连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StatusLabel_DeviceStatus.Text = "Connected";
                    StatusLabel_DeviceStatus.BackColor = Color.Green;
                }
                else
                {
                    // 设备未连接，更新 UI 或执行其他操作
                    // 例如，将 ConnectedStatu 变量设置为 false，并显示连接失败的提示信息
                    ConnectedStatu = false;
                    // MessageBox.Show("设备未连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    StatusLabel_DeviceStatus.Text = "DisConnect";
                    StatusLabel_DeviceStatus.BackColor = Color.Red;
                }
            };
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

        public void StopReadData()
        {
            // 设置ReadSignal 为false ,表示不需要运行ReadData任务
            ReadSignal = false;

            //发送取消信号给ReadData()后台任务
            ReadCTS.Cancel();

            // 等待readData()后台任务结束
            ReadDataTask.Wait();

            // 释放资源
            ReadCTS.Dispose();
        }


        public async void ReadData(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // 调用 NI_VISA_Function 类中NiVisa.ReadDataAsync() 来异步读取数据:
                await this.NiVisa.ReadDataAsync();

                //计算数据
                this.NiVisa.CalculatedReaData();

                Invoke(new Action(() =>
                {
                    updateGridView();
                    ChartControl_Watchdog.RefreshData();
                }));

                await Task.Delay(ReadFrequence); // 每100毫秒读取一次

                // 检查是否取消
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
            ChartControl_Watchdog.Series["Current(mA)"].Visible = CheckBox_CurrentLineDisplay.Checked;
        }

        private void CheckBox_VoltageLineDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ChartControl_Watchdog.Series["Voltage(V)"].Visible = CheckBox_VoltageLineDisplay.Checked;
        }

        private void CheckBox_PowerLineDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ChartControl_Watchdog.Series["Power(mW)"].Visible = CheckBox_PowerLineDisplay.Checked;
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

                    ws.Column(1).Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss"; // 设置第一列的单元格格式为DateTime
                    ws.Column(1).Width = 20;
                    ws.Column(2).Width = 14;
                    ws.Column(3).Width = 14;
                    ws.Column(4).Width = 14;
                    package.SaveAs(file); // 将excel文件保存到指定的路径
                }

                MessageBox.Show("保存成功！");

            }

        }





        private async void Keithley2306Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            await service.StopAsync(CancellationToken.None);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            // 每次Tick事件增加一秒
            seconds++;

            // 计算时分秒
            int hour = seconds / 3600;
            int minute = (seconds % 3600) / 60;
            int second = seconds % 60;

            // 格式化字符串，如果小于10则补零
            string hourStr = hour < 10 ? "0" + hour : hour.ToString();
            string minuteStr = minute < 10 ? "0" + minute : minute.ToString();
            string secondStr = second < 10 ? "0" + second : second.ToString();

            // 更新gaugecontrol控件的Text属性
            digitalGauge1.Text = hourStr + ":" + minuteStr + ":" + secondStr;
        }
    }

}
