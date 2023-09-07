namespace HW_Thermal_Tools.Forms.keithley2306
{
    public class PowerData
    {
        public double Current { get; set; }
        public double CurrentMin { get; set; }
        public double CurrentMax { get; set; }
        public double CurrentAve { get; set; }


        public double Voltage { get; set; }
        public double VoltageMin { get; set; }
        public double VoltageMax { get; set; }
        public double VoltageAve { get; set; }


        public double Power { get; set; }
        public double PowerMin { get; set; }
        public double PowerMax { get; set; }
        public double PowerAve { get; set; }


        public List<DataPoint> CurrentHistory { get; set; } = new List<DataPoint>(); // 电流历史记录列表
        public List<DataPoint> VoltageHistory { get; set; } = new List<DataPoint>(); // 电压历史记录列表
        public List<DataPoint> PowerHistory { get; set; } = new List<DataPoint>(); // 功率历史记录列表

        public List<ExcelDataPoint> OriDataHistory { get; set; } = new List<ExcelDataPoint>(); //用于保存所有数据最后保存到Excel



    }

    public class DataPoint
    {
        public DateTime Time { get; set; } // 时间字段，用于横轴数据
        public double Value { get; set; } // 数值字段，用于纵轴数据

        public DataPoint(DateTime time, double value) // 构造函数
        {
            Time = time;
            Value = value;
        }
    }

    public class ExcelDataPoint
    {
        public DateTime Time { get; set; } //时间
        public double CurentValue { get; set; } //current value
        public double VoltageValue { get; set; } //voltage value
        public double PowerValue { get; set; } //power value

        public ExcelDataPoint(DateTime time, double currentvalue, double voltageValue, double powerValue)
        {
            Time = time;
            VoltageValue = voltageValue;
            PowerValue = powerValue;
        }

    }


}
