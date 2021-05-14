using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly CustomerBook r_CustomerBook;
        private readonly Assembly r_Assembly;
        private readonly Dictionary<string, Type> r_VehiclesTypes;

        public List<string> AvailableVehicles { get; private set; }

        public Garage()
        {
            r_Assembly = Assembly.GetExecutingAssembly();
            r_CustomerBook = new CustomerBook();

            r_VehiclesTypes = new Dictionary<string, Type>();
            initAvailableVehicles();
        }

        private void initAvailableVehicles() // TODO: Move to different class
        {
            AvailableVehicles = new List<string>();

            foreach (Type classType in r_Assembly.GetTypes())
            {
                if (classType.IsSubclassOf(typeof(Vehicle)) && !classType.IsAbstract)
                {
                    var dummy = Activator.CreateInstance(classType);
                    var classTypeName = classType.GetMethod("GetCalssModelName").Invoke(dummy, null).ToString();
                    AvailableVehicles.Add(classTypeName);
                    r_VehiclesTypes.Add(classTypeName, classType);
                }
            }
        }

        public void AddVehicle(string i_LicenseNumber, string i_Vehicle)
        {
            if (!AvailableVehicles.Contains(i_Vehicle))
            {
                throw new FormatException("The requested type is not a vehicle");
            }

            if (r_CustomerBook.IsCustomerExist(i_LicenseNumber))
            {
                r_CustomerBook.GetCustomer(i_LicenseNumber).VehicleState = eVehicleState.InRepair;

                throw new ArgumentException("The vehicle already in the garage.");
            }

            CustomerTicket customerTicket = new CustomerTicket();
            customerTicket.Vehicle = (Vehicle)Activator.CreateInstance(r_VehiclesTypes[i_Vehicle]);
            customerTicket.VehicleState = eVehicleState.InRepair;

            r_CustomerBook.AddCustomer(customerTicket);
        }

        public List<string> GetLicensesByState(bool i_ConsiderState, eVehicleState i_VehicleState)
        {
            List<string> vehicles = new List<string>();

            foreach (var customerTicket in r_CustomerBook.CustomerDictionary)
            {
                if (i_ConsiderState && customerTicket.Value.VehicleState != i_VehicleState)
                {
                    continue;
                }

                vehicles.Add(customerTicket.Key);
            }

            return vehicles;
        }

        public void FuelPetrolVehicle(string i_LicenseNumber, eFuelType i_FuelType, int i_Quantity)
        {
            FuelVehicle vehicleToFuel = r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as FuelVehicle;
            if(vehicleToFuel != null)
            {
                vehicleToFuel.Refuel(i_Quantity, i_FuelType);
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, int i_ChargingTimeInMin)
        {
            ElectricityVehicle vehicleToCharge = r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as ElectricityVehicle;
            if (vehicleToCharge != null)
            {
                vehicleToCharge.ChargeBattery(i_ChargingTimeInMin);
            }
        }

        public void ChangeVehicleState(string i_LicenseNumber, eVehicleState i_NewVehicleState)
        {
            r_CustomerBook.GetCustomer(i_LicenseNumber).VehicleState = i_NewVehicleState;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            int numOfWheels = r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.Wheels.Count;
            for (int i = 0; i < numOfWheels; i++)
            {
                Wheel currentWheelToInflate = r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.Wheels[numOfWheels];
                currentWheelToInflate.Inflate(currentWheelToInflate.MaxAirPressure);
            }
        }
    }
}