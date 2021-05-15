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

        public virtual List<string> PropertiesNeededToFillForTheSpecificVehicle()
        {
            List<string> propertiesToFill = new List<string>();

            propertiesToFill.Add("wheels Air Pressure");
            propertiesToFill.Add("wheels Manifacture");
            propertiesToFill.Add("Model Name");
            propertiesToFill.Add("Energy Percentage");

            return propertiesToFill;
        }

        public virtual void InitializeProperites(List<string> i_PropertiesToCastAndFill)
        {
            // TODO: Move to different methods OR setters?

            if (float.TryParse(i_PropertiesToCastAndFill[0], out float wheelsAirPressure))
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

            string wheelsManifacture = i_PropertiesToCastAndFill[1];
            foreach (Wheel wheel in Wheels)
            {
                wheel.ManifactureName = wheelsManifacture;
            }

            string modelName = i_PropertiesToCastAndFill[2];
            ModelName = modelName;

            if (float.TryParse(i_PropertiesToCastAndFill[3], out float energyPercentage))
            {
                EnergyPercentage = energyPercentage;
            }
            else
            {
                throw new FormatException("Problem parsing the string to value...");
            }

            i_PropertiesToCastAndFill.RemoveRange(0, 4);
        }
    }
}
