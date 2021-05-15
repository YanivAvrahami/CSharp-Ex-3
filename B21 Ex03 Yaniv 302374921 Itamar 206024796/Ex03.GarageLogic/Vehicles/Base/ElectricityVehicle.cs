using System.Text;

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
                ValueOutOfRangeException ex = new ValueOutOfRangeException();
                ex.MaxValue = MaxBatteryTime;
                throw ex;
            }

            CurrentBatteryTime += i_ChargeAmount;
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Fuel: {CurrentBatteryTime} of {MaxBatteryTime}");

            return stringBuilder.ToString();
        }
    }
}
