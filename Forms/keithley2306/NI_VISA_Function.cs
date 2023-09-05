using DevExpress.Mvvm.Native;
using DevExpress.Utils.Extensions;
using DevExpress.Xpo;
using Ivi.Visa;
using NationalInstruments.Visa;
using NPOI.SS.Formula.Functions;
using System;


namespace HW_Thermal_Tools.Forms.keithley2306
{

    internal class Keithley2306
    {


        //定义一个锁对象
        private Object sessionLock = new object();
        private MessageBasedSession Session;
        private bool connected;

        private ResourceManager rm = new ResourceManager();
        //定义设备地址
        private string address = "GPIB0::6::INSTR";

        //定义一个信号


        public Keithley2306()
        {

            
            
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
                //对于使用过程中断开设备，不关闭Form情况下，session会话未正常关闭，需要清空缓存后才能正常重新识别设备
                if(Session != null)
                {
                    Session.Dispose();
                }
                
                //尝试打开会话
                Session = (MessageBasedSession)rm.Open(address);
                // 检测设备ID
                Session.RawIO.Write("*IDN?");
                string idn = Session.RawIO.ReadString();
                
                
                if (idn != null)
                {
                    // 连接正常
                connected = true;
                }
            }catch (VisaException e)
            {
                //打开会话失败，设备未连接
                connected = false;
            }
            Monitor.Exit(sessionLock);
            return connected;

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
            
        }


    }
}
