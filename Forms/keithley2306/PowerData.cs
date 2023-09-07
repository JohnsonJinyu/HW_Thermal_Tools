namespace HW_Thermal_Tools.Forms.keithley2306
{
    public class PowerData
    {
        public float Current { get; set; }
        public float CurrentMin { get; set; }
        public float CurrentMax { get; set; }
        public float CurrentAve { get; set; }


        public float Voltage { get; set; }
        public float VoltageMin { get; set; }
        public float VoltageMax { get; set; }
        public float VoltageAve { get; set; }


        public float Power { get; set; }
        public float PowerMin { get; set; }
        public float PowerMax { get; set; }
        public float PowerAve { get; set; }


        public List<DataPoint> CurrentHistory { get; set; } = new List<DataPoint>(); // 电流历史记录列表
        public List<DataPoint> VoltageHistory { get; set; } = new List<DataPoint>(); // 电压历史记录列表
        public List<DataPoint> PowerHistory { get; set; } = new List<DataPoint>(); // 功率历史记录列表





    }

    public class DataPoint
    {
        public DateTime Time { get; set; } // 时间字段，用于横轴数据
        public float Value { get; set; } // 数值字段，用于纵轴数据

        public DataPoint(DateTime time, float value) // 构造函数
        {
            Time = time;
            Value = value;
        }
    }


}
