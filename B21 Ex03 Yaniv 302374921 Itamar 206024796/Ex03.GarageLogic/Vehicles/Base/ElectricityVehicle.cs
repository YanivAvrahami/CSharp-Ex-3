using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class ElectricityVehicle : Vehicle
    {
        public float CurrentBatteryTime { get; set; }
        public float MaxBatteryTime { get; }

        public ElectricityVehicle(int i_NumberOfWheels, float i_MaxAirPressure, float i_MaxBatteryTime)
            : base(i_NumberOfWheels, i_MaxAirPressure)
        {
            MaxBatteryTime = i_MaxBatteryTime;
        }

        public void ChargeBattery(float i_ChargeAmount)
        {
            if ((i_ChargeAmount < 0) || (CurrentBatteryTime + i_ChargeAmount > MaxBatteryTime))
            {
                throw new ValueOutOfRangeException(MaxBatteryTime);
            }

            CurrentBatteryTime += i_ChargeAmount;
            EnergyPercentage = CurrentBatteryTime / MaxBatteryTime * 100;
        }

        public override string GetVehicleInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Battery: {CurrentBatteryTime} of {MaxBatteryTime}");

            return stringBuilder.ToString();
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            CurrentBatteryTime = EnergyPercentage * MaxBatteryTime / 100f;
        }
    }
}
