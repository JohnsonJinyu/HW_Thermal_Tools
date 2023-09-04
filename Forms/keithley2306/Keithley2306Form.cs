using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using HW_Thermal_Tools.Forms.keithley2306;
using HZH_Controls;
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
        DeviceConnectionChecker connectionChecker;

        private Keithley2306 NI_VISA_Function;
        private bool connected;

        public Keithley2306Form()
        {
            InitializeComponent();
            NI_VISA_Function = new Keithley2306(); //构造函数中初始化

        }

        private void keithley2306_Load(object sender, EventArgs e)
        {

            connectionChecker = new DeviceConnectionChecker();
            connected = NI_VISA_Function.IsConnectedGPIBDevices();
            Thread checkThread = new Thread(CheckStatus);
            checkThread.Start();

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


        private void CheckStatus()
        {
            while (true)
            {
                bool connected = connectionChecker.IsConnected();

                Invoke(new Action(() => {
                    UpdateUI(connected);
                }));

                Thread.Sleep(1000);
            }
        }


        private void UpdateUI(bool connected)
        {
            if (this.InvokeRequired) //判断是否需要Invoke
            {
                this.Invoke(new Action<bool>(UpdateUI), new object[] { connected });
            }
            else
            {
                if (connected)

                {
                    StatusLabel_Device.Text = "设备已连接";
                    StatusLabel_Device.BackColor = Color.Green;
                }
                else
                {
                    StatusLabel_Device.Text = "设备未连接";
                    StatusLabel_Device.BackColor = Color.Red;
                }
            }
        }

        private void Keithley2306Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            connectionChecker.Dispose();
        }



    }
}
