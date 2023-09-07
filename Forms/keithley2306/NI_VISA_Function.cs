using Ivi.Visa;
using NationalInstruments.Visa;


namespace HW_Thermal_Tools.Forms.keithley2306
{

    public class NiVisaFunction
    {


        //定义一个锁对象
        private Object sessionLock = new object();
        private MessageBasedSession Session;
        private bool connected;

        private ResourceManager rm = new ResourceManager();
        //定义设备地址
        private string address = "GPIB0::6::INSTR";

        
        // 创建PowerData对象
        public PowerData data;

        public NiVisaFunction()
        {
            data = new PowerData();


        }

        /*
         设备连接检测功能
         */

        public bool Detection_Thread()
        {
            //获取锁
            Monitor.Enter(sessionLock);
            try
            {
                string[] resources = (string[])rm.Find(address);
                if(resources.Length > 0)
                {
                    connected = true;
                }
             
            }
            catch (VisaException e)
            {
                
                connected = false;
                
            }
            Monitor.Exit(sessionLock);
            return connected;

        }


        /*
         打开及关闭 Session会话
         */
        public void OpenSession()
        {
            Session = (MessageBasedSession)rm.Open(address);
            // 置相关属性
            Session.TimeoutMilliseconds = 3000;  //设置响应超时时间
            // 设置终止字符(Terminator)
            //Session.TerminationCharacter = (byte)'\n';

            //Session.TerminationCharacterEnabled = true;


        }

           public void DisposeSession()
        {
            if(Session != null)
            {
                Session.Dispose();
            }
            
        }


        /*
         设置输出
         */
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


        /*
         设置读取
         */
        public void ReadData()
        {
            

            // 读取电流
            Session.RawIO.Write("MEAS:CURR?");
            data.Current = float.Parse(Session.RawIO.ReadString());

            // 读取电压  
            Session.RawIO.Write("MEAS:VOLT?");
            data.Voltage = float.Parse(Session.RawIO.ReadString());

            // 计算功率 
            data.Power = data.Current * data.Voltage;

            



            // 保存到队列历史记录
            data.CurrentHistory.Add(data.Current);
            data.VoltageHistory.Add(data.Voltage);
            data.PowerHistory.Add(data.Power);

            // 只保留最近4800条记录
            if (data.CurrentHistory.Count > 4800)
            {
                data.CurrentHistory.RemoveAt(0);
            }
            if (data.VoltageHistory.Count > 4800)
            {
                data.VoltageHistory.RemoveAt(0);
            }
            if (data.PowerHistory.Count > 4800)
            {
                data.PowerHistory.RemoveAt(0);
            }

        }



        public void CalculatedReaData()
        {
            //Current
            data.CurrentMin = data.CurrentHistory.Min();
            data.CurrentMax = data.CurrentHistory.Max();
            data.CurrentAve = data.CurrentHistory.Average();

            //Voltage
            data.VoltageMin = data.VoltageHistory.Min();
            data.VoltageMax = data.VoltageHistory.Max();
            data.VoltageAve = data.VoltageHistory.Average();

            //Power
            data.PowerMin = data.PowerHistory.Min();
            data.PowerMax = data.PowerHistory.Max();
            data.PowerAve = data.PowerHistory.Average();
        }

    }
}
