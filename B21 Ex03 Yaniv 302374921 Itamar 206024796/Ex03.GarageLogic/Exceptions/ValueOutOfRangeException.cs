using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
    }
}
