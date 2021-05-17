using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        public ValueOutOfRangeException(float i_MaxValue)
            : this(0, i_MaxValue)
        {
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base("The value range is: " + i_MinValue + " - " + i_MaxValue)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}
