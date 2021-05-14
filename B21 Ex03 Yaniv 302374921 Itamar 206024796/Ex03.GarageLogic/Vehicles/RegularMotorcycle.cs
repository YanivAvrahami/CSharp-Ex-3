using System.Text;

namespace Ex03.GarageLogic
{
    class RegularMotorcycle : PetrolVehicle
    {
        public eLicense License { get; set; }
        public int EngineVolume { get; set; }

        public RegularMotorcycle() : base()
        {

        }

        public RegularMotorcycle(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }

        public override string GetCalssModelName()
        {
            return "Regular Motorcycle";
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder(base.GetInformationAboutVehicleAsString());

            stringBuilder.AppendLine($"License: {License}");
            stringBuilder.AppendLine($"Engine Volume: {EngineVolume}");

            return stringBuilder.ToString();
        }
    }
}
