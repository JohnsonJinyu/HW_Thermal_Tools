using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using HW_Thermal_Tools.Forms.keithley2306;
using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HW_Thermal_Tools.Forms
{
    public partial class Keithley2306Form : DevExpress.XtraEditors.XtraForm
    {
        // 创建一个 keithley2306 的对象
        private Keithley2306 keithley2306;

        // 创建一个 statusStrip 的对象
        private StatusStrip statusStrip;

        // 创建一个 Timer 的对象
        private System.Windows.Forms.Timer timer;





        public Keithley2306Form()
        {
            InitializeComponent();
            // 初始化 keithley2306 的对象
            keithley2306 = new Keithley2306();

            // 初始化 statusStrip 的对象
            statusStrip = new StatusStrip();
            // 设置 statusStrip 的 RenderMode 为 ManagerRenderMode，使用默认的外观
            statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;

            // 将 StatusLabel_Device 添加到 statusStrip 的 Items 集合中
            statusStrip.Items.Add(StatusLabel_Device);

            // 将 statusStrip 添加到 Form 的 Controls 集合中
            this.Controls.Add(statusStrip);






            // 初始化 timer 的对象
            timer = new System.Windows.Forms.Timer();
            // 设置 timer 的 Interval 为 1000 毫秒，即每隔一秒触发一次 Tick 事件
            timer.Interval = 1000;
            // 注册 timer 的 Tick 事件处理程序
            timer.Tick += new EventHandler(Timer_Tick);


        }

        private void keithley2306_Load(object sender, EventArgs e)
        {
            //加载主题

            // 启动 timer
            timer.Start();

        }

        private void Btn_Power_Off_Click(object sender, EventArgs e)
        {
            keithley2306.Power_Off();
        }

        private void Btn_Power_On_Click(object sender, EventArgs e)
        {
            if (Combox_Channel.Text == "CH1")
            {
                keithley2306.SetChannel_1();
                keithley2306.SetVoltage(ComboBox_Voltage_Select.Text);
                keithley2306.Power_On();
            }
        }




        // timer 的 Tick 事件处理程序，用于检测设备是否连接并更新 statusStrip 的显示
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (keithley2306.IsConnected())
            {
                StatusLabel_Device.Text = "设备已连接";
                StatusLabel_Device.ForeColor = Color.Green;
            }
            else
            {
                StatusLabel_Device.Text = "设备未连接";
                StatusLabel_Device.ForeColor = Color.Red;
            }
        }
    }
}
