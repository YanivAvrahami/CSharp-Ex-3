using System.Text;

namespace Ex03.GarageLogic
{
    abstract class PetrolVehicle : Vehicle
    {
        public eFuelType FuelType { get; set; }
        public float CurrentFuelAmount { get; set; }
        public float MaxFuelAmount { get; set; }

        public PetrolVehicle(int i_NumberOfWheels, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuelAmount)
            : base(i_NumberOfWheels, i_MaxAirPressure)
        {
            FuelType = i_FuelType;
            MaxFuelAmount = i_MaxFuelAmount;
        }

        public void Refuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if ((i_FuelType != FuelType) || (i_FuelAmount < 0) ||
                (CurrentFuelAmount + i_FuelAmount > MaxFuelAmount))
            {
                ValueOutOfRangeException ex = new ValueOutOfRangeException();
                ex.MaxValue = MaxFuelAmount;
                throw ex;
            }

            CurrentFuelAmount += i_FuelAmount;
        }

        public override string GetInformationAboutVehicleAsString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"FuelType: {FuelType}");
            stringBuilder.AppendLine($"Fuel: {CurrentFuelAmount} of {MaxFuelAmount}");

            return stringBuilder.ToString();
        }
    }
}
