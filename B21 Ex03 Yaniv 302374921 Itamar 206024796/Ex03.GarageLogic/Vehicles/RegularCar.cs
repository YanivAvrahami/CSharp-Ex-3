﻿using System.Text;

namespace Ex03.GarageLogic
{
    class RegularCar : PetrolVehicle
    {
        public eColor Color { get; set; }
        public int Doors { get; set; }

        public RegularCar() : base()
        {

        }

        public RegularCar(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }

        public override string GetCalssModelName()
        {
            return "Regular Car";
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder(base.GetInformationAboutVehicleAsString());

            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Number of doors: {Doors}");

            return stringBuilder.ToString();
        }
    }
}
