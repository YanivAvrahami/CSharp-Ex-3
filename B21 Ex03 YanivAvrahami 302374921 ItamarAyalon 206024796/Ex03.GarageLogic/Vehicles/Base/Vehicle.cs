using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private float m_EnergyPercentage;
        public string ModelName { get; set; }
        public string LicenseNumber { get; set; }
        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set
            {
                if (!(0f <= value && value <= 100f))
                {
                    throw new ValueOutOfRangeException(0, 100);
                }

                m_EnergyPercentage = value;
            }
        }
        public List<Wheel> Wheels { get; set; }

        public Vehicle(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            Wheels = new List<Wheel>();

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public virtual string GetVehicleInfo()
        {
            StringBuilder infoStrBuilder = new StringBuilder();

            infoStrBuilder.AppendLine($"License number: {LicenseNumber}");
            infoStrBuilder.AppendLine($"Model Name: {ModelName}");
            infoStrBuilder.AppendLine($"Wheel Air Pressure: {Wheels[0].CurrentAirPressure}");
            infoStrBuilder.AppendLine($"Wheel Max Pressure: {Wheels[0].MaxAirPressure}");

            return infoStrBuilder.ToString();
        }

        /// <summary>
        /// Give the properties that need to be filled after creation
        /// </summary>
        /// <returns>A list of the required properties to initialize</returns>
        public virtual List<string> PropertiesToInitialize()
        {
            List<string> propertiesToFill = new List<string>();

            propertiesToFill.Add("wheels Air Pressure");
            propertiesToFill.Add("wheels Manifacture");
            propertiesToFill.Add("Model Name");
            propertiesToFill.Add("Energy Percentage");

            return propertiesToFill;
        }

        /// <summary>
        /// Set the properties that need to be filled
        /// </summary>
        /// <param name="i_PropertiesToCastAndFill">list of the properties values as string</param>
        public virtual void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            initWheelsAirPressure(i_PropertiesToCastAndFill[0]);

            string wheelsManifacture = i_PropertiesToCastAndFill[1];
            foreach (Wheel wheel in Wheels)
            {
                wheel.ManifactureName = wheelsManifacture;
            }

            string modelName = i_PropertiesToCastAndFill[2];
            ModelName = modelName;

            initEnergyPercentage(i_PropertiesToCastAndFill[3]);

            i_PropertiesToCastAndFill.RemoveRange(0, 4);
        }

        private void initWheelsAirPressure(string i_WheelsAirPressureStr)
        {
            if (float.TryParse(i_WheelsAirPressureStr, out float wheelsAirPressure))
            {
                foreach (Wheel wheel in Wheels)
                {
                    wheel.CurrentAirPressure = wheelsAirPressure;
                }
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }
        }

        private void initEnergyPercentage(string i_EnergyPercentageStr)
        {
            if (float.TryParse(i_EnergyPercentageStr, out float energyPercentage))
            {
                EnergyPercentage = energyPercentage;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }
        }
    }
}
