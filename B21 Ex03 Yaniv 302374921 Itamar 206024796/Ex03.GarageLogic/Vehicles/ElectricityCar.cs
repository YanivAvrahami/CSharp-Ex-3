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

        public override string GetCalssModelName()
        {
            return "Electric Car";
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Number of doors: {Doors}");


            return stringBuilder.ToString();
        }
    }
}
