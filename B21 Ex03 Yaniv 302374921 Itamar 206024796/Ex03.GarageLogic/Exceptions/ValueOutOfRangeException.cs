using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        public ValueOutOfRangeException(float i_MaxValue)
        {
            MaxValue = i_MaxValue;
            MinValue = 0;
        }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}
