namespace Ex03.GarageLogic
{
    class RegularCar : FuelVehicle
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
    }
}
