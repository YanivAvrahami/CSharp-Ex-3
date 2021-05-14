namespace Ex03.GarageLogic
{
    abstract class FuelVehicle : Vehicle
    {
        public eFuelType FuelType { get; set; }
        public float CurrentFuelAmount { get; set; }
        public float MaxFuelAmount { get; set; }

        public FuelVehicle() : base()
        {

        }

        public FuelVehicle(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }

        public void Refuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if ((i_FuelType != FuelType) || 
                (i_FuelAmount < 0) ||
                (CurrentFuelAmount + i_FuelAmount > MaxFuelAmount))
            {
                // TODO: throw exception?
            }

            CurrentFuelAmount += i_FuelAmount;
        }
    }
}
