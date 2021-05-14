namespace Ex03.GarageLogic
{
    class Garage
    {
        public CustomerBook CustomerBook { get; set; }

        public void  AddVehicle(Vehicle i_Vehicle)
        {
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            int numOfWheels = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.Wheels.Count;
            for(int i = 0; i < numOfWheels; i++)
            {
                Wheel currentWheelToInflate = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.Wheels[numOfWheels];
                currentWheelToInflate.Inflate(currentWheelToInflate.MaxAirPressure);
            }
        }

        public void FuelPetrolVehicle(string i_LicenseNumber, eFuelType i_FuelType, int i_Quantity)
        {
            FuelVehicle vehicleToFuel = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as FuelVehicle;
            vehicleToFuel.Refuel(i_Quantity, i_FuelType);
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, int i_ChargingTimeInMin)
        {
            ElectricityVehicle vehicleToCharge = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as ElectricityVehicle;
            vehicleToCharge.ChargeBattery(i_ChargingTimeInMin);
        }

    }
}