using HW_Thermal_Tools.Forms.keithley2306;
using NationalInstruments.Visa;
using NPOI.SS.Formula.Functions;
using System.Threading.Tasks;


namespace HW_Thermal_Tools.Forms
{


    public partial class Keithley2306Form : DevExpress.XtraEditors.XtraForm
    {


        private static Keithley2306 NI_VISA_Function;
        // 创建一个布尔变量来记录设备的连接状态
        private bool ConnectedStatu;
        // 定义一个私有的布尔变量，用来表示是否需要继续检测USB设备的变化
        private static volatile bool running = true;

        

        // 定义一个私有的字段，用来存储后台任务
        private Task task;

        // 定义一个私有的字段，用来存储取消令牌源
        private CancellationTokenSource cts;

        // 私有化构造函数，防止外部直接创建对象
        public Keithley2306Form()
        {
            InitializeComponent();
            NI_VISA_Function = new Keithley2306(); //构造函数中初始化

            // 初始化定时器对象
            


        }



        private void keithley2306_Load(object sender, EventArgs e)
        {

            //启动后台线程检测设备变化
            StartDetection();

        }







        private void Btn_Power_Off_Click(object sender, EventArgs e)
        {
            NI_VISA_Function.OutPut_Off();
        }

        private void Btn_Power_On_Click(object sender, EventArgs e)
        {

            if (!ConnectedStatu)
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


        // 定义一个公共的方法，用来启动后台线程
        public  void StartDetection()
        {
            // 设置running变量为true，表示需要继续检测
            running = true;

            // 创建一个取消令牌源
            cts = new CancellationTokenSource();

            // 获取取消令牌
            var token = cts.Token;

            // 使用Task类的Run方法来创建并启动一个后台线程，并传入DectionAndUpdateUITask方法和取消令牌作为参数
            // 不需要再调用Start方法来启动任务
            task = Task.Run(() => DectionAndUpdateUITask(token), token);

        }

        private  void DectionAndUpdateUITask(CancellationToken token)
        {
            while(running)
            {
                ConnectedStatu = NI_VISA_Function.Detection_Thread();
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


        

        private void Keithley2306Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //当Form closed时，关闭session会话和Task

            running = false;
            // 发送取消信号给后台任务
            cts.Cancel();

            // 等待后台任务结束
            task.Wait();
        }
    }

}
