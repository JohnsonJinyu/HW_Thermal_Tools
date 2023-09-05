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

       


    }
}
