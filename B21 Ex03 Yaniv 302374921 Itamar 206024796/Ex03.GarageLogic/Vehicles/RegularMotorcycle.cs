using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class RegularMotorcycle : PetrolVehicle
    {
        public eLicense License { get; set; }
        public int EngineVolume { get; set; }

        public RegularMotorcycle()
            : base(2, 30f, eFuelType.Octan98, 6f)
        {
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder(base.GetInformationAboutVehicleAsString());

            stringBuilder.AppendLine($"License: {License}");
            stringBuilder.AppendLine($"Engine Volume: {EngineVolume}");

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
