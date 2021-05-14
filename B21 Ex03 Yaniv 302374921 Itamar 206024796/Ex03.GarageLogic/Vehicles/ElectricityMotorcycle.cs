namespace Ex03.GarageLogic
{
    class ElectricityMotorcycle : ElectricityVehicle
    {
        public eLicense License { get; set; }
        public int EngineVolume { get; set; }

        public ElectricityMotorcycle(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }
    }
}
