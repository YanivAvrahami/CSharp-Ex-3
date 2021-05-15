using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricityCar : ElectricityVehicle
    {
        public eColor Color { get; set; }
        public int Doors { get; set; }

        public ElectricityCar() : base()
        {

        }

        public ElectricityCar(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Number of doors: {Doors}");


            return stringBuilder.ToString();
        }

        public override List<string> PropertiesNeededToFillForTheSpecificVehicle()
        {
            List<string> listOfProperties = new List<string>();

            listOfProperties.Add("color");
            listOfProperties.Add("doors");

            return listOfProperties;
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            throw new NotImplementedException();
        }

    }
}
