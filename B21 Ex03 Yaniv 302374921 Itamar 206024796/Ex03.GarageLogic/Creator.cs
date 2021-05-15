using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Creator
    {
        private static Dictionary<string, Type> m_VehiclesTypes;
        public List<string> AvailableVehicles { get; private set; }

        public Creator()
        {
            m_VehiclesTypes = AssemblyUtils.GetDictOfNamesAndTypesOfASubClass(typeof(Vehicle), false);
            AvailableVehicles = new List<string>();

            foreach (string vehicleName in m_VehiclesTypes.Keys)
            {
                AvailableVehicles.Add(vehicleName);
            }
        }

        public Vehicle CreateNewVehicle(string i_Vehicle)
        {
            return Activator.CreateInstance(m_VehiclesTypes[i_Vehicle]) as Vehicle;
        }
    }


}
