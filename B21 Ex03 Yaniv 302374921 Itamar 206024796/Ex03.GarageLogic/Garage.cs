using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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

            if (r_CustomerBook.IsCustomerExist(i_LicenseNumber)) // TODO: Check if the UI handle it. If so, remove this condition block.
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
        public void ChangeVehicleState(string i_LicenseNumber, eVehicleState i_NewVehicleState)
        {
            r_CustomerBook.GetCustomer(i_LicenseNumber).VehicleState = i_NewVehicleState;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            CustomerTicket customer = r_CustomerBook.GetCustomer(i_LicenseNumber);

            foreach (Wheel wheel in customer.Vehicle.Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressure);
            }
        }

        public void RefuelPetrolVehicle(string i_LicenseNumber, eFuelType i_FuelType, int i_Quantity)
        {
            CustomerTicket customer = r_CustomerBook.GetCustomer(i_LicenseNumber);

            (customer.Vehicle as PetrolVehicle).Refuel(i_Quantity, i_FuelType);
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, int i_ChargingTimeInMinutes)
        {
            CustomerTicket customer = r_CustomerBook.GetCustomer(i_LicenseNumber);

            (customer.Vehicle as ElectricityVehicle).ChargeBattery(i_ChargingTimeInMinutes);
        }

        public string GetCustomerInformationAsAstring(string i_LicenseNumber) // TODO: Add to different static class ( or customer class)
        {
            StringBuilder customerInfoStr = new StringBuilder();
            CustomerTicket customer = r_CustomerBook.GetCustomer(i_LicenseNumber);
            Vehicle vehicle = customer.Vehicle;

            customerInfoStr.AppendLine($"License number: {i_LicenseNumber}");
            customerInfoStr.AppendLine($"Model Name: {vehicle.ModelName}");
            customerInfoStr.AppendLine($"Owner Name: {customer.FullName}");
            customerInfoStr.AppendLine($"Vehicle State: {customer.VehicleState}");
            customerInfoStr.AppendLine($"Wheel Air Pressure: {vehicle.Wheels[0].CurrentAirPressure}");
            customerInfoStr.AppendLine($"Wheel Max Pressure: {vehicle.Wheels[0].MaxAirPressure}");

            return customerInfoStr.ToString();
        }

        public bool IsPetrolVehicle(string i_LicenseNumber)
        {
            return r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle is PetrolVehicle;
        }

        public bool IsElectricityVehicle(string i_LicenseNumber)
        {
            return r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle is ElectricityVehicle;
        }

        public bool IsCustomerExist(string i_LicenseNumber)
        {
            return r_CustomerBook.IsCustomerExist(i_LicenseNumber);
        }

        public bool IsValidPhoneNumber(string i_PhoneNumber)
        {
            return false;
        }
    }
}