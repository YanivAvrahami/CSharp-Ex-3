namespace Ex03.GarageLogic
{
    public class Garage
    {
        public CustomerBook CustomerBook { get; set; }

        public void FuelPetrolVehicle(string i_LicenseNumber, eFuelType i_FuelType, int i_Quantity)  
        {
            FuelVehicle vehicleToFuel = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as FuelVehicle;
            if(vehicleToFuel != null)
            {
                vehicleToFuel.Refuel(i_Quantity, i_FuelType);
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, int i_ChargingTimeInMin)
        {
            ElectricityVehicle vehicleToCharge = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle as ElectricityVehicle;
            if (vehicleToCharge != null)
            {
                vehicleToCharge.ChargeBattery(i_ChargingTimeInMin);
            }
        }

        public void ChangeVehicleState(string i_LicenseNumber, eVehicleState i_NewVehicleState)
        {
            CustomerBook.GetCustomer(i_LicenseNumber).VehicleState = i_NewVehicleState;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            int numOfWheels = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.Wheels.Count;
            for (int i = 0; i < numOfWheels; i++)
            {
                Wheel currentWheelToInflate = CustomerBook.GetCustomer(i_LicenseNumber).Vehicle.Wheels[numOfWheels];
                currentWheelToInflate.Inflate(currentWheelToInflate.MaxAirPressure);
            }
        }
    }
}