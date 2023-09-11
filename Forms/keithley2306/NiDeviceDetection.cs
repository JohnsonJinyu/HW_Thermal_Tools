using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Thermal_Tools.Forms.keithley2306
{
    public class NiDeviceDetection
    {
        private ResourceManager resourceManager = new ResourceManager();

        public bool CheckGPIBDevice(string address)
        {
            try
            {
                string[] resources = (string[])resourceManager.Find(address);
                if (resources.Length > 0)
                    return true;
                else
                    return false; //添加默认的返回情况，也就是 == 0的时候
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}
