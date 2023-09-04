using HW_Thermal_Tools.Forms.keithley2306;
using NationalInstruments.Visa;


namespace HW_Thermal_Tools.Forms
{


    public partial class Keithley2306Form : DevExpress.XtraEditors.XtraForm
    {
        DeviceConnectionChecker connectionChecker;

        private Keithley2306 NI_VISA_Function;
        private bool connected;

        // 创建一个GPIB会话对象
        private GpibSession gpibSession;
        // 创建一个定时器对象
        private System.Windows.Forms.Timer timer;
        // 创建一个布尔变量来记录设备的连接状态
        private bool isConnected;

        // 私有化构造函数，防止外部直接创建对象
        public Keithley2306Form()
        {
            InitializeComponent();
            NI_VISA_Function = new Keithley2306(); //构造函数中初始化

            // 初始化定时器对象
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 设置定时器的间隔为1秒
            timer.Tick += Timer_Tick; // 设置定时器的Tick事件处理函数

            // 初始化设备的连接状态为true
            isConnected = true;
        }

        // 定义一个静态方法，用于创建对象并初始化GPIB会话
        public static Keithley2306Form Create()
        {
            // 创建一个Keithley2306Form对象
            var form = new Keithley2306Form();

            // 尝试初始化GPIB会话对象
            try
            {
                form.gpibSession = new GpibSession("GPIB0::6::INSTR");
            }
            catch (Exception ex)
            {
                // 弹出提示框或其他操作
                // 使用MessageBox.Show方法的重载版本，指定提示框的标题、按钮和图标
                MessageBox.Show("未安装GPIB设备驱动：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            // 返回创建好的对象
            return form;
        }

        private void keithley2306_Load(object sender, EventArgs e)
        {

            // 当窗体加载时执行以下操作

            // 启动定时器
            timer.Start();

        }







        private void Btn_Power_Off_Click(object sender, EventArgs e)
        {
            NI_VISA_Function.OutPut_Off();
        }

        private void Btn_Power_On_Click(object sender, EventArgs e)
        {

            if (!connected)
            {
                MessageBox.Show("未连接");
            }
            else
            {
                NI_VISA_Function.SelectChannel(Combox_Channel.Text);
                NI_VISA_Function.SetVoltage(ComboBox_Voltage_Select.Text);
                NI_VISA_Function.OutPut_On();
            }

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // 定时器每次Tick时执行以下操作

            try
            {
                // 使用null条件运算符（?.）来检查gpibSession对象是否为空
                gpibSession?.RawIO.Write("*IDN?\n");


                // 读取返回的结果
                string result = gpibSession?.RawIO.ReadString();

                // 检查结果是否为空或异常
                if (string.IsNullOrEmpty(result) || result.Contains("Error"))
                {
                    // 如果结果为空或异常，说明设备已经断开连接

                    // 如果之前的状态是连接的，那么触发状态改变事件
                    if (isConnected)
                    {
                        OnConnectionStateChanged(false);
                    }
                }
                else
                {
                    // 如果结果不为空或异常，说明设备仍然连接正常

                    // 如果之前的状态是断开的，那么触发状态改变事件
                    if (!isConnected)
                    {
                        OnConnectionStateChanged(true);
                    }
                }
            }
            catch (Exception ex)
            {
                // 如果发送或读取过程中发生异常，也说明设备已经断开连接

                // 如果之前的状态是连接的，那么触发状态改变事件
                if (isConnected)
                {
                    OnConnectionStateChanged(false);
                }
            }
        }

        private void OnConnectionStateChanged(bool state)
        {
            // 当设备的连接状态改变时执行以下操作

            // 更新布尔变量的值
            isConnected = state;

            // 更新界面上的标签或图标等显示元素
            if (isConnected)
            {
                StatusLabel_DeviceStatus.Text = "Connected";
                StatusLabel_DeviceStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                StatusLabel_DeviceStatus.Text = "Disconnected";
                StatusLabel_DeviceStatus.ForeColor = System.Drawing.Color.Red;
            }

            // 弹出提示框或其他操作
            MessageBox.Show("Device connection state changed to " + state);
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 当窗体关闭时执行以下操作

            // 停止定时器
            timer.Stop();

            // 关闭GPIB会话对象
            gpibSession.Dispose();
        }





    }

}
