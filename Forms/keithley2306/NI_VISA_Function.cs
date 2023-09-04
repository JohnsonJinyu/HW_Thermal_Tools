using Ivi.Visa;
using NationalInstruments.Visa;
using System;


namespace HW_Thermal_Tools.Forms.keithley2306
{

    internal class Keithley2306
    {


        private ResourceManager ResourceManager;
        private MessageBasedSession Session; // 增加一个会话对象

        public Keithley2306()
        {

            ResourceManager = new ResourceManager();
            
        }

        public bool IsConnectedGPIBDevices()
        {
            Dispose(); // 释放旧的ResourceManager
            bool connected = false;
            int retryCount = 0;
            const int MaxRetryCount = 5; // 设置最大重试次数

            using (ResourceManager rm = new ResourceManager())
            {
                // 原有的连接检测逻辑
                while (!connected && retryCount < MaxRetryCount)
                {
                    try
                    {
                        var resources = rm.Find("GPIB?*::?*::INSTR");
                        if (resources != null)
                        {
                            foreach (var resource in resources)
                            {
                                // 打开会话进行测试
                                IVisaSession session = rm.Open(resource);
                                if (session != null)
                                {
                                    connected = true;
                                    // 初始化Session
                                    string address = resource;
                                    Session = (MessageBasedSession)rm.Open(address);

                                    break;
                                }
                                //session.Dispose();
                            }
                        }
                    }
                    catch (VisaException e)
                    {
                        Console.WriteLine(e.Message);
                        retryCount++;

                    }
                }
                // 使用新的ResourceManager实例rm 
            }


            return connected;
        }


        public void Dispose()
        {
            if (ResourceManager != null)
            {
                ResourceManager.Dispose();
                ResourceManager = null;
            }
            
        }



        public void SelectChannel(string channel)
        {
            if (channel == "CH1")
            {
                Session.RawIO.Write("INST CH1"); // 选择通道1
            }
            else if (channel == "CH2")
            {
                Session.RawIO.Write("INST CH2"); // 选择通道2
            }
        }

        public void SetVoltage(string voltage)
        {
            Session.RawIO.Write($"VOLT {voltage}"); // 设置电压值
        }

        public void OutPut_On()
        {
            Session.RawIO.Write("OUTP ON"); // 开启输出
        }

        public void OutPut_Off()
        {
            Session.RawIO.Write("OUTP OFF"); // 关闭输出
        }

    }
}
