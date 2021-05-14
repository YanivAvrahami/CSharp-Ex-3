namespace Ex03.GarageLogic
{
    class RegularMotorcycle : FuelVehicle
    {
        public eLicense License { get; set; }
        public int EngineVolume { get; set; }

        public RegularMotorcycle(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }
    }
}
