using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly CustomerBook r_CustomerBook;
        private readonly Creator r_VehicleCreator;

        public List<string> AvailableVehiclesWithoutSpaces { get; private set; }

        public Garage()
        {
            r_CustomerBook = new CustomerBook();
            r_VehicleCreator = new Creator();

            AvailableVehiclesWithoutSpaces = r_VehicleCreator.AvailableVehicles;
        }

        public void AddVehicle(string i_LicenseNumber, string i_VehicleNameStr)
        {
            if (!AvailableVehiclesWithoutSpaces.Contains(i_VehicleNameStr))
            {
                throw new FormatException("The requested type is not a vehicle");
            }

            if (r_CustomerBook.IsCustomerExist(i_LicenseNumber)) // TODO: Check if the UI handle it. If so, remove this condition block.
            {
                r_CustomerBook.GetCustomer(i_LicenseNumber).VehicleState = eVehicleState.InRepair;

                throw new ArgumentException("The vehicle already in the garage.");
            }

            CustomerTicket customerTicket = new CustomerTicket();
            customerTicket.Vehicle = r_VehicleCreator.CreateNewVehicle(i_VehicleNameStr);
            customerTicket.VehicleState = eVehicleState.InRepair;
            customerTicket.Vehicle.LicenseNumber = i_LicenseNumber;

            r_CustomerBook.AddCustomer(customerTicket);
        }

        public List<string> GetVehiclePropertiesByLicense(string i_LicenseNumber)
        {
            return r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.PropertiesNeededToFillForTheSpecificVehicle();
        }

        public void SetVehiclePropertiesByLicense(string i_LicenseNumber, List<string> i_listOfProperties)
        {
            r_CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.InitializeProperites(i_listOfProperties);
        }

        public void UpdateCustomer(string i_LicenseNumber, string i_FullName, string i_PhoneNumber)
        {
            CustomerTicket customer =  r_CustomerBook.GetCustomer(i_LicenseNumber);

            customer.FullName = i_FullName;
            customer.PhoneNumber = i_PhoneNumber;
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
                wheel.InflateToMax();
            }
        }

        public void RefuelPetrolVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_Quantity)
        {
            CustomerTicket customer = r_CustomerBook.GetCustomer(i_LicenseNumber);

            (customer.Vehicle as PetrolVehicle).Refuel(i_Quantity, i_FuelType);
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_ChargingTimeInHours)
        {
            CustomerTicket customer = r_CustomerBook.GetCustomer(i_LicenseNumber);

            (customer.Vehicle as ElectricityVehicle).ChargeBattery(i_ChargingTimeInHours);
        }

        public string GetCustomerInformationAsAstring(string i_LicenseNumber)
        {
            return r_CustomerBook.GetCustomerInformationAsAstring(i_LicenseNumber);
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
    }
}