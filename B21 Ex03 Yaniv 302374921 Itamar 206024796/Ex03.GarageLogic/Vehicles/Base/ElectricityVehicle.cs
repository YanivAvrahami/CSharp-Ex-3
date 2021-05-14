namespace Ex03.GarageLogic
{
    abstract class ElectricityVehicle : Vehicle
    {
        public float CurrentBatteryTime { get; set; }
        public float MaxBatteryTime { get; set; }

        public ElectricityVehicle() : base()
        {

        }


        public ElectricityVehicle(string i_ModelName, float i_CurrentEnergy)
            : base(i_ModelName, i_CurrentEnergy)
        {

        }

        public void ChargeBattery(float i_ChargeAmount)
        {
            if ((i_ChargeAmount < 0) || (CurrentBatteryTime + i_ChargeAmount > MaxBatteryTime))
            {
                //TODO: throw exception?
            }

            CurrentBatteryTime += i_ChargeAmount;
        }
    }
}
