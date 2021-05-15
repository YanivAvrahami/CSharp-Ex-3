using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class PetrolVehicle : Vehicle
    {
        private float m_CurrentFuelAmount;
        public eFuelType FuelType { get; }
        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set
            {
                if (!(0 <= value && value <= MaxFuelAmount))
                {
                    throw new ValueOutOfRangeException(MaxFuelAmount);
                }

                m_CurrentFuelAmount = value;
            }
        }
        public float MaxFuelAmount { get; }

        public PetrolVehicle(int i_NumberOfWheels, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuelAmount)
            : base(i_NumberOfWheels, i_MaxAirPressure)
        {
            FuelType = i_FuelType;
            MaxFuelAmount = i_MaxFuelAmount;
        }

        public void Refuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if (i_FuelAmount < 0 || CurrentFuelAmount + i_FuelAmount > MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(MaxFuelAmount);
            }
            if (i_FuelType != FuelType)
            {
                throw new ArgumentException();
            }

            CurrentFuelAmount += i_FuelAmount;
            EnergyPercentage = CurrentFuelAmount / MaxFuelAmount * 100;
        }

        public override string GetVehicleInfo()
        {
            StringBuilder infoStrBuilder = new StringBuilder(base.GetVehicleInfo());

            infoStrBuilder.AppendLine($"FuelType: {FuelType}");
            infoStrBuilder.AppendLine($"Fuel: {CurrentFuelAmount} of {MaxFuelAmount}");

            return infoStrBuilder.ToString();
        }

        public override void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            base.InitializeProperites(i_PropertiesToCastAndFill);

            CurrentFuelAmount = EnergyPercentage * MaxFuelAmount / 100;
        }
    }
}
