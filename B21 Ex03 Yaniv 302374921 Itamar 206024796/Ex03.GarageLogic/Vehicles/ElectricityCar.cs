using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricityCar : ElectricityVehicle
    {
        public eColor Color { get; set; }
        public int Doors { get; set; }

        public ElectricityCar(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }
    }
}
