using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa;
using NationalInstruments.Visa; // 引入 VISA .NET API

namespace HW_Thermal_Tools.Forms.keithley2306
{
    public class PowerData
    {
        public float Current { get; set; }
        public float Voltage { get; set; }
        public float Power { get; set; }

        public Queue<float> CurrentHistory { get; set; } = new Queue<float>();
        public Queue<float> VoltageHistory { get; set; } = new Queue<float>();
        public Queue<float> PowerHistory { get; set; } = new Queue<float>();

        // 定义一个 MessageBasedSession 对象
        private MessageBasedSession session;

        // 定义一个构造函数，用于初始化 MessageBasedSession 对象
        public PowerData(string resourceString)
        {
            session = (MessageBasedSession)GlobalResourceManager.Open(resourceString); // 打开指定资源的会话
            session.TimeoutMilliseconds = 3000; // 设置超时为 3000 毫秒

            // 发送一些初始化指令，例如设置输出格式、触发模式、限制功能等
            session.RawIO.Write("*RST\n"); // 复位电源
            session.RawIO.Write(":FORM:ELEM CURR,VOLT\n"); // 设置输出格式为电流和电压
            session.RawIO.Write(":TRIG:SOUR EXT\n"); // 设置为外部触发模式
            session.RawIO.Write(":TRIG:DEL 0.01\n"); // 设置触发延迟为 0.01 秒
            session.RawIO.Write(":TRIG:COUN 10\n"); // 设置触发计数为 10 次
            session.RawIO.Write(":TRIG:OUTP ON\n"); // 设置输出触发信号
            session.RawIO.Write(":SENS1:CURR:LIM:UPP 1.0\n"); // 设置电流上限为 1.0 A
            session.RawIO.Write(":SENS1:CURR:LIM:LOW 0.5\n"); // 设置电流下限为 0.5 A
            session.RawIO.Write(":SENS1:CURR:LIM:STAT ON\n"); // 开启电流限制功能
            session.RawIO.Write(":SENS1:VOLT:LIM:UPP 10.0\n"); // 设置电压上限为 10.0 V
            session.RawIO.Write(":SENS1:VOLT:LIM:LOW 5.0\n"); // 设置电压下限为 5.0 V
            session.RawIO.Write(":SENS1:VOLT:LIM:STAT ON\n"); // 开启电压限制功能
        }

        // 定义一个析构函数，用于关闭 MessageBasedSession 对象
        ~PowerData()
        {
            session.Dispose(); // 关闭会话并释放资源
        }

        // 定义一个方法，用于发送指令并读取返回值
        private string SendCommand(string command)
        {
            session.RawIO.Write(command + "\n"); // 发送指令，并在末尾添加换行符 \n
            return session.RawIO.ReadString(); // 读取返回值，并去除末尾的换行符 \n
        }

        // 定义一个方法，用于获取电流值
        private float GetCurrent()
        {
            string response = SendCommand(":MEAS:CURR?"); // 发送测量电流的指令，并获取返回值
            return float.Parse(response); // 将返回值转换为浮点数并返回
        }

        // 定义一个方法，用于获取电压值
        private float GetVoltage()
        {
            string response = SendCommand(":MEAS:VOLT?"); // 发送测量电压的指令，并获取返回值
            return float.Parse(response); // 将返回值转换为浮点数并返回
        }

        // 定义一个方法，用于获取功率值
        private float GetPower()
        {
            string response = SendCommand(":MEAS:POW?"); // 发送测量功率的指令，并获取返回值
            return float.Parse(response); // 将返回值转换为浮点数并返回
        }

        // 读取数据的方法
        public void ReadFromPowerSource()
        {
            float current = GetCurrent();
            float voltage = GetVoltage();
            float power = GetPower();

            // 更新当前值
            Current = current;
            Voltage = voltage;
            Power = power;

            // 添加到历史队列
            CurrentHistory.Enqueue(current);
            VoltageHistory.Enqueue(voltage);
            PowerHistory.Enqueue(power);
        }
    }
}
