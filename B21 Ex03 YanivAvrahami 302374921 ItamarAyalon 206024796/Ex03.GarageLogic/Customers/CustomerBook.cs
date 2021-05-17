using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class CustomerBook
    {
        public Dictionary<string, CustomerTicket> CustomerDictionary { get; set; }

        public CustomerBook()
        {
            CustomerDictionary = new Dictionary<string, CustomerTicket>();
        }

        public bool IsCustomerExist(string i_LicenseNumber)
        {
            return CustomerDictionary.ContainsKey(i_LicenseNumber);
        }

        public CustomerTicket GetCustomer(string i_LicenseNumber)
        {
            if (!IsCustomerExist(i_LicenseNumber))
            {
                throw new ArgumentException("Customer does not exist");
            }

            return CustomerDictionary[i_LicenseNumber];
        }

        public void AddCustomer(CustomerTicket i_Customer)
        {
            CustomerDictionary.Add(i_Customer.Vehicle.LicenseNumber, i_Customer);
        }

        public void RemoveCustomer(CustomerTicket i_Customer)
        {
            CustomerDictionary.Remove(i_Customer.Vehicle.LicenseNumber);
        }

        public string GetCustomerInfo(string i_LicenseNumber)
        {
            if (!IsCustomerExist(i_LicenseNumber))
            {
                throw new ArgumentException("Customer does not exist");
            }

            StringBuilder customerInfoStr = new StringBuilder();
            CustomerTicket customer = GetCustomer(i_LicenseNumber);
            Vehicle vehicle = customer.Vehicle;

            customerInfoStr.AppendLine($"Owner Name: {customer.FullName}");
            customerInfoStr.AppendLine($"Vehicle State: {customer.VehicleState}");
            customerInfoStr.AppendLine(vehicle.GetVehicleInfo());

            return customerInfoStr.ToString();
        }
    }
}
