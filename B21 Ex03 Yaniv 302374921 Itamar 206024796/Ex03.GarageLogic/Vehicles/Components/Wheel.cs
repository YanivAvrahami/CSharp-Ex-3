namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private float m_CurrentAirPressure;

        public string ManifactureName { get; set; }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (0 <= value && value <= MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(MaxAirPressure);
                }
            }
        }
        public float MaxAirPressure { get; }

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }

        public void InflateToMax()
        {
            CurrentAirPressure = MaxAirPressure;
        }
    }
}
