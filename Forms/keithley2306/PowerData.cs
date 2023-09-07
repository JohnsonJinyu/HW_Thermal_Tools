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


        public List<float> CurrentHistory { get; set; } = new List<float>();
        public List<float> VoltageHistory { get; set; } = new List<float>();
        public List<float> PowerHistory { get; set; } = new List<float>();




    }


    
}
