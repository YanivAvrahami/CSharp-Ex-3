namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string ManifactureName { get; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; }

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirPressure)
        {
            if ((i_AirPressure < 0) || (CurrentAirPressure + i_AirPressure > MaxAirPressure))
            {
                // TODO: throw exception?
            }

            CurrentAirPressure += i_AirPressure;
        }
    }
}
