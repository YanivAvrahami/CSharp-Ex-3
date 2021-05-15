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

        public abstract string GetInformationAboutVehicleAsString();

        public abstract List<string> PropertiesNeededToFillForTheSpecificVehicle();

        public abstract void InitializeProperites(List<string> i_PropertiesToCastAndFill);
    }
}
