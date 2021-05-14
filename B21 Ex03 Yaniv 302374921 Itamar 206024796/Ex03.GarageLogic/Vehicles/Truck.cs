namespace Ex03.GarageLogic
{
    class Truck : FuelVehicle
    {
        public bool HasHazardous { get; set; }
        public float MaxCarry { get; set; }

        public Truck(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }
    }
}
