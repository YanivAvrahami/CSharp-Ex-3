using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public string LicenseNumber { get; set; }
        public float EnergyPercentage { get; set; }
        public List<Wheel> Wheels { get; set; }

        public Vehicle(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            Wheels = new List<Wheel>();

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public abstract string GetVehicleInfo();

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
            // CHANGE LIST TO QUEUE

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
