using Ivi.Visa;
using NationalInstruments.Visa;
using System;

namespace HW_Thermal_Tools.Forms.keithley2306
{
    internal class Keithley2306
    {
        // 创建一个 GPIB 会话对象
        private GpibSession gpibSession;

        // 定义仪器的 GPIB 地址
        private const string gpibAddress = "GPIB0::12::INSTR";

        // 定义超时时间，单位为毫秒
        private const int timeout = 10000;

        // 定义终止字符
        private const string termination = "\n";

        // 定义设备是否连接的标志
        private bool isConnected;

        // 构造函数
        public Keithley2306()
        {
            // 初始化 GPIB 会话
            try
            {
                gpibSession = (GpibSession)GlobalResourceManager.Open(gpibAddress, AccessModes.None, timeout);
                gpibSession.TerminationCharacterEnabled = true;
                gpibSession.TerminationCharacter = (byte)termination[0];
                isConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("无法打开 GPIB 会话: " + e.Message);
                isConnected = false;
            }
        }

        // 设置通道 1 的电压和电流的方法
        public void SetChannel1(double voltage, double current)
        {
            // 选择通道 1
            gpibSession.RawIO.Write("INST CH1" + termination);

            // 设置电压值，单位为伏特
            gpibSession.RawIO.Write("VOLT " + voltage.ToString() + termination);

            // 设置电流限制，单位为安培
            gpibSession.RawIO.Write("CURR " + current.ToString() + termination);

            // 启用输出
            gpibSession.RawIO.Write("OUTP ON" + termination);

            //关闭输出
            gpibSession.RawIO.Write("OUTP OFF" + termination);
        }

        //选择通道1
        public void SetChannel_1()
        {
            // 选择通道 1
            gpibSession.RawIO.Write("INST CH1" + termination);
        }

        //选择通道1
        public void SetChannel_2()
        {
            // 选择通道 1
            gpibSession.RawIO.Write("INST CH2" + termination);
        }

        //设定电压值
        public void SetVoltage(string voltage)
        {
            // 设置电压值，单位为伏特
            gpibSession.RawIO.Write("VOLT " + voltage + termination);
        }

        public void Power_On()
        {
            // 启用输出
            gpibSession.RawIO.Write("OUTP ON" + termination);
        }

        public void Power_Off()
        {
            // 关闭输出
            gpibSession.RawIO.Write("OUTP OFF" + termination);
        }


        // 关闭 GPIB 会话的方法
        public void Close()
        {
            gpibSession.Dispose();
        }

        // 判断设备是否连接的方法，返回布尔值
        public bool IsConnected()
        {
            return isConnected;
        }
    }
}
