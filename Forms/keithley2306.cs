using MathNet.Numerics.Distributions;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace HW_Thermal_Tools.Forms
{
    public partial class keithley2306 : Form
    {
        //定义一个串口对象
        private SerialPort serialPort = new SerialPort();

        public keithley2306()
        {
            InitializeComponent();
        }

        private void keithley2306_Load(object sender, EventArgs e)
        {
            LoadTheme();
            //设置串口参数
            serialPort.PortName = "COM1"; //设置串口号，根据实际情况修改
            serialPort.BaudRate = 9600; //设置波特率，根据实际情况修改
            serialPort.DataBits = 8; //设置数据位，根据实际情况修改
            serialPort.StopBits = StopBits.One; //设置停止位，根据实际情况修改
            serialPort.Parity = Parity.None; //设置奇偶校验位，根据实际情况修改
            serialPort.ReadTimeout = 1000; //设置读取超时时间，根据实际情况修改

            //创建一个定时器，用于循环检测设备连接状态
            Timer timer = new Timer();
            timer.Interval = 1000; //设置定时器间隔时间，根据实际情况修改
            timer.Tick += new EventHandler(timer_Tick); //设置定时器触发事件
            timer.Start(); //启动定时器
        }

        private void LoadTheme()
        {
            //通过这种方式获取
            foreach (System.Windows.Forms.Control control in tableLayoutPanel_Control.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)control;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        //定时器触发事件的方法
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //尝试打开串口
                serialPort.Open();
                //发送查询设备标识符的命令
                serialPort.WriteLine("*IDN?");
                //读取设备返回的数据
                string data = serialPort.ReadLine();
                //判断数据是否包含Keithley 2306的标识符
                if (data.Contains("KEITHLEY INSTRUMENTS INC.,MODEL 2306"))
                {
                    //如果包含，则说明设备已连接，更新statusLabel的状态为已连接，并设置为绿色
                    DevicesConnetStatuLabel.Text = "已连接";
                    DevicesConnetStatuLabel.ForeColor = Color.Green;
                }
                else
                {
                    //如果不包含，则说明设备未连接，更新statusLabel的状态为未连接，并设置为红色
                    DevicesConnetStatuLabel.Text = "未连接";
                    DevicesConnetStatuLabel.ForeColor = Color.Red;
                }
                //关闭串口
                serialPort.Close();
            }
            catch (Exception ex)
            {
                //如果发生异常，则说明设备未连接或通信错误，更新statusLabel的状态为未连接，并设置为红色
                DevicesConnetStatuLabel.Text = "未连接";
                DevicesConnetStatuLabel.ForeColor = Color.Red;
                //关闭串口
                serialPort.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
