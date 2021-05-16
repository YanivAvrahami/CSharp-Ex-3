using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Creator
    {
        private readonly Dictionary<string, Type> r_VehiclesTypes;
        public List<string> AvailableVehicles { get; private set; }

        public Creator()
        {
            r_VehiclesTypes = AssemblyUtils.GetDictOfNamesAndTypesOfASubClass(typeof(Vehicle), false);
            AvailableVehicles = new List<string>();

            foreach (string vehicleName in r_VehiclesTypes.Keys)
            {
                AvailableVehicles.Add(vehicleName);
            }
        }

        public Vehicle CreateNewVehicle(string i_Vehicle)
        {
            return Activator.CreateInstance(r_VehiclesTypes[i_Vehicle]) as Vehicle;
        }
    }
}
