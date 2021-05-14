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
                currentWheelToInflate.Inflate(currentWheelToInflate.MaxPressure);
            }
        }

        public FuelPetrolVehicle(string i_LicenseNumber, eFuelType i_FuelType, int i_Quantity)
        {
            FuelVehicle vehicleToFuel = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as FuelVehicle;
            vehicleToFuel.Refuel(i_Quantity);
        }

        public ChargeElectricVehicle(string i_LicenseNumber, int i_ChargingTimeInMin)
        {
            ElectricVehicle vehicleToCharge = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as ElectricVehicle;
            vehicleToCharge.ChargeBattery(i_ChargingTimeInMin);
        }

    }
}