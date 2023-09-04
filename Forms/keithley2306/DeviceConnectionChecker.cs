using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Thermal_Tools.Forms.keithley2306
{
    public class DeviceConnectionChecker
    {
        private Keithley2306 keithley;

        public DeviceConnectionChecker()
        {
            keithley = new Keithley2306();
        }

        public bool IsConnected()
        {
            return keithley.IsConnectedGPIBDevices();
        }

        public void Dispose()
        {
            keithley.Dispose();
        }
    }
}
