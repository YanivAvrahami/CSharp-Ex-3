using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class ElectricityVehicle : Vehicle
    {
        private float m_CurrentBatteryTime;
        public float CurrentBatteryTime
        {
            get { return m_CurrentBatteryTime; }
            private set
            {
                if (!(0 <= value && value <= MaxBatteryTime))
                {
                    throw new ValueOutOfRangeException(MaxBatteryTime);
                }

                m_CurrentBatteryTime = value;
            }
        }
        public float MaxBatteryTime { get; }

        public ElectricityVehicle(int i_NumberOfWheels, float i_MaxAirPressure, float i_MaxBatteryTime)
            : base(i_NumberOfWheels, i_MaxAirPressure)
        {
            MaxBatteryTime = i_MaxBatteryTime;
        }

        public void ChargeBattery(float i_ChargeAmount)
        {
            CurrentBatteryTime += i_ChargeAmount;
            EnergyPercentage = CurrentBatteryTime / MaxBatteryTime * 100;
        }

        public override string GetVehicleInfo()
        {
            StringBuilder infoStrBuilder = new StringBuilder(base.GetVehicleInfo());

            infoStrBuilder.AppendLine($"Battery: {CurrentBatteryTime} of {MaxBatteryTime}");

            return infoStrBuilder.ToString();
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            CurrentBatteryTime = EnergyPercentage * MaxBatteryTime / 100f;
        }
    }
}
