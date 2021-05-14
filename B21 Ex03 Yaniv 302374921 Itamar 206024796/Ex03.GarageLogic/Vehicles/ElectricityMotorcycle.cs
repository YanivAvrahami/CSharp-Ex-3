namespace Ex03.GarageLogic
{
    class ElectricityMotorcycle : ElectricityVehicle
    {
        public eLicense License { get; set; }
        public int EngineVolume { get; set; }

        public ElectricityMotorcycle() : base()
        {

        }

        public ElectricityMotorcycle(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }

        public override string GetCalssModelName()
        {
            return "Electric Motorcycle";
        }
    }
}
