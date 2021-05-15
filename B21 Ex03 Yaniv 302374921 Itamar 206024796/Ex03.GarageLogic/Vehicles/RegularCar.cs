using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class RegularCar : PetrolVehicle
    {
        public eColor Color { get; set; }
        public int Doors { get; set; }

        public RegularCar()
            : base(4, 32f, eFuelType.Octan95, 45f)
        {
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder(base.GetInformationAboutVehicleAsString());

            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Number of doors: {Doors}");

            return stringBuilder.ToString();
        }

        public override List<string> PropertiesNeededToFillForTheSpecificVehicle()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            throw new System.NotImplementedException();
        }
    }
}
