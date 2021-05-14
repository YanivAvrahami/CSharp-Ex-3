using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public string LicenseNumber { get; set; }
        public float EnergyPercentage { get; set; }
        public List<Wheel> Wheels { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(string i_ModelName, float i_CurrentEnergy)
        {
            ModelName = i_ModelName;
            EnergyPercentage = i_CurrentEnergy;
        }

        public abstract string GetCalssModelName();

        public abstract string GetInformationAboutVehicle();
    }
}
