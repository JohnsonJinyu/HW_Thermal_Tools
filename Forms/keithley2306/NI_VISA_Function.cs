﻿using NationalInstruments.Visa;


namespace HW_Thermal_Tools.Forms.keithley2306
{

    public class NiVisaFunction
    {
        private MessageBasedSession Session;

        // 创建一个resourceManager 实例化对象
        private ResourceManager rm = new ResourceManager();

        //定义设备地址
        private string address = "GPIB0::6::INSTR";

        // 创建PowerData对象
        public PowerData data;

        public NiVisaFunction()
        {
            data = new PowerData();

        }


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
            if (Session != null)
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

        public void SetVoltage_Lim(string voltage)
        {
            Session.RawIO.Write($"VOLT {voltage}"); // 设置电压值(限制)
        }


        public void SetCurrent(string current)
        {
            Session.RawIO.Write($"CURR {current}"); // 设置电流值
        }

        public void SetCurrent_Lim(string currentLim)
        {
            Session.RawIO.Write($"CURR:LIM {currentLim}"); // 设置电流值（限制）
        }



        public void OutPut_On()
        {
            Session.RawIO.Write("OUTP ON"); // 开启输出
        }

        public void OutPut_Off()
        {
            Session.RawIO.Write("OUTP OFF"); // 关闭输出
        }

        public bool IsOutputOn()
        {
            // 发送 OUTP? 命令
            Session.RawIO.Write("OUTP?");
            // 接收返回的结果
            string result = Session.RawIO.ReadString().Trim();
            // 转换为布尔类型的值
            bool output = result == "1";

            // 返回结果
            return output;
        }



        /*
         设置读取
         */
        public void ReadData()
        {
            /*
             1、使用double.Parse将string转换成double类型
             2、Math.Round的参数为double类型
             3、最后再转为float类型赋值给Current
             */
            // 读取电流
            Session.RawIO.Write("MEAS:CURR?");
            data.Current = Math.Round(float.Parse(Session.RawIO.ReadString()) * 1000, 5); //转为mA,并保留小数点后5位

            // 读取电压  
            Session.RawIO.Write("MEAS:VOLT?");
            data.Voltage = Math.Round(float.Parse(Session.RawIO.ReadString()), 5);  //转为mV,并保留小数点后5位

            // 计算功率 
            data.Power = data.Current * data.Voltage / 1000; // 功率W


            // 保存到队列历史记录
            data.CurrentHistory.Add(new DataPoint(DateTime.Now, data.Current));
            data.VoltageHistory.Add(new DataPoint(DateTime.Now, data.Voltage));
            data.PowerHistory.Add(new DataPoint(DateTime.Now, data.Power));
            data.OriDataHistory.Add(new ExcelDataPoint(DateTime.Now, data.Current, data.Voltage, data.Power));
        }

        public async Task ReadDataAsync()
        {
            await Task.Run(() => ReadData());
        }

        public void CalculatedReaData()
        {
            //Current
            data.CurrentMin = data.CurrentHistory.Min(p => p.Value); // 使用lambda表达式获取Value字段
            data.CurrentMax = data.CurrentHistory.Max(p => p.Value); // 使用lambda表达式获取Value字段
            data.CurrentAve = data.CurrentHistory.Average(p => p.Value); // 使用lambda表达式获取Value字段

            //Voltage
            data.VoltageMin = data.VoltageHistory.Min(p => p.Value); // 使用lambda表达式获取Value字段
            data.VoltageMax = data.VoltageHistory.Max(p => p.Value); // 使用lambda表达式获取Value字段
            data.VoltageAve = data.VoltageHistory.Average(p => p.Value); // 使用lambda表达式获取Value字段

            //Power
            data.PowerMin = data.PowerHistory.Min(p => p.Value); // 使用lambda表达式获取Value字段
            data.PowerMax = data.PowerHistory.Max(p => p.Value); // 使用lambda表达式获取Value字段
            data.PowerAve = data.PowerHistory.Average(p => p.Value); // 使用lambda表达式获取Value字段
        }


    }
}
