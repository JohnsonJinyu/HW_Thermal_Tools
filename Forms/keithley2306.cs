﻿using DevExpress.XtraEditors;
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
    public partial class keithley2306 : DevExpress.XtraEditors.XtraForm
    {
        public keithley2306()
        {
            InitializeComponent();
        }

        private void keithley2306_Load(object sender, EventArgs e)
        {
            //加载主题

            //检测设备连接状态
            CheckDeviceConnectStatus();

        }


        //3s一次检查设备是否连接
        private void CheckDeviceConnectStatus()
        {
            throw new NotImplementedException();
        }
    }
}