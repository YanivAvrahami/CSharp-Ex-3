using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        public string MenuString { get; set; }

        public bool IsRunning { get; set; }

        public Garage Garage { get; set; }

        public ConsoleUI()
        {
            Garage = new Garage();
            MenuString = ConsoleUIHelper.CreateMenuString();
        }

        public void Run()
        {
            IsRunning = true;

            while(IsRunning)
            {
                renderMenu();
                handleMenuChoice();

                Console.Clear();
            }
        }

        private void handleMenuChoice()
        {
            ConsoleKey keyPressed = Console.ReadKey().Key;
            Console.WriteLine("");

            switch(keyPressed)
            {
                case ConsoleKey.D1:
                    addVehicle();
                    break;
                case ConsoleKey.D2:
                    displayAllLicenseNumbers();
                    break;
                case ConsoleKey.D3:
                    changeVehicleState();
                    break;
                case ConsoleKey.D4:
                    inflateVehicleWheelsToMax();
                    break;
                case ConsoleKey.D5:
                    refuelPetrolVehicle();
                    break;
                case ConsoleKey.D6:
                    chargeElectricVehicle();
                    break;
                case ConsoleKey.D7:
                    displayFullCarInfo();
                    break;
                case ConsoleKey.D8:
                    exit();
                    break;
            }

            Console.WriteLine("Enter key to continue...");
            Console.ReadKey();
        }

        private void addVehicle()
        {
            Console.Write("Enter license number: ");
            string licenseInput = Console.ReadLine();

            Console.Write("Enter energy percentage: ");
            string energyInput = Console.ReadLine();

            printListWithIndex(Garage.AvailableVehiclesWithoutSpaces);
            ConsoleKey keyPressed = Console.ReadKey().Key;

            Garage.AddVehicle(licenseInput, Garage.AvailableVehiclesWithoutSpaces[0]);

            List<string> listOfParameters = new List<string>();
            switch(keyPressed)
            {
                case ConsoleKey.D1:
                    
                    break;
                case ConsoleKey.D2:

                    break;
                case ConsoleKey.D3:

                    break;
                case ConsoleKey.D4:

                    break;
                case ConsoleKey.D5:
                    
                    break;
            }

            
            
        }

        private void displayAllLicenseNumbers()
        {
            Console.Write("Filter license numbers? (y/n):");
            ConsoleKey keyPressed = Console.ReadKey().Key;
            bool isLicenseNumbersFiltered = keyPressed == ConsoleKey.Y;

            eVehicleState stateTypeChoosen = eVehicleState.InRepair;
            if(isLicenseNumbersFiltered)
            {
                stateTypeChoosen = userInputGetFilterState();
            }

            List<string> licenses = Garage.GetLicensesByState(isLicenseNumbersFiltered, stateTypeChoosen);
            foreach(string license in licenses)
            {
                Console.WriteLine(license);
            }

        }

        private void changeVehicleState()
        {
            string licenseNumberString = userInputGetExistLicenseWithMessage();
            eVehicleState stateTypeChoosen = userInputVehicleState();
            Garage.ChangeVehicleState(licenseNumberString, stateTypeChoosen);
        }

        private void inflateVehicleWheelsToMax()
        {
            string licenseNumberString = userInputGetExistLicenseWithMessage();
            Garage.InflateVehicleWheelsToMax(licenseNumberString);
        }

        private void refuelPetrolVehicle()
        {
            string licenseNumberString = userInputGetExistLicenseWithMessage();

            if(!Garage.IsPetrolVehicle(licenseNumberString))
            {
                Console.WriteLine("The vehicle is not electricity");
            }
            else
            {
                eFuelType fuelType = userInputGetFuelType();
                float fuelAmount = userInputRefuelAmount();

                Garage.RefuelPetrolVehicle(licenseNumberString, fuelType, fuelAmount);
            }
        }

        private void chargeElectricVehicle()
        {
            string licenseNumberString = userInputGetExistLicenseWithMessage();

            if(!Garage.IsElectricityVehicle(licenseNumberString))
            {
                Console.WriteLine("The vehicle is not electricity");
            }
            else
            {
                float batteryMinutes = userInputBatteryChargeTime();
                Garage.ChargeElectricVehicle(licenseNumberString, batteryMinutes);
            }
        }

        private void displayFullCarInfo()
        {
            string licenseNumberString = userInputGetExistLicenseWithMessage();
            Console.WriteLine(Garage.GetCustomerInformationAsAstring(licenseNumberString));
        }

        private string userInputGetExistLicenseWithMessage()
        {
            Console.WriteLine("Enter license number:");
            return userInputGetExistLicense();
        }

        private void exit()
        {
            IsRunning = false;
        }

        private void renderMenu()
        {
            Console.Write(MenuString);
        }


        /// <summary>
        /// Console utils
        /// Console utils
        /// Console utils
        /// </summary>


        private string userInputGetExistLicense()
        {
            string licenseNumberString;

            do
            {
                licenseNumberString = Console.ReadLine();

            }
            while(!Garage.IsCustomerExist(licenseNumberString));

            return licenseNumberString;
        }

        private eVehicleState userInputGetFilterState()
        {
            Console.Write("Filter by tags:");

            return userInputGetEnumTypeOption<eVehicleState>();
        }

        private eFuelType userInputGetFuelType()
        {
            Console.Write("Fuel Types:");

            return userInputGetEnumTypeOption<eFuelType>();
        }

        private eVehicleState userInputVehicleState()
        {
            Console.Write("Choose state:");

            return userInputGetEnumTypeOption<eVehicleState>();
        }

        private float userInputBatteryChargeTime()
        {
            Console.Write("Enter Charging time in minutes:");

            return userInputIncreaseEnergy();
        }

        private float userInputRefuelAmount()
        {
            Console.Write("Enter fuel amount:");

            return userInputIncreaseEnergy();
        }

        private float userInputIncreaseEnergy()
        {
            string EnergyToIncreaseStr;
            float EnergyToIncrease;

            EnergyToIncreaseStr = Console.ReadLine();
            if(!float.TryParse(EnergyToIncreaseStr, out EnergyToIncrease))
            {
                throw new FormatException("The input is not a float.");
            }

            return EnergyToIncrease;
        }

        private T userInputGetEnumTypeOption<T>()
        {
            Console.WriteLine(getEnumAsStringOptions<T>());

            string inputStr;
            int typeChoosen;

            do
            {
                inputStr = Console.ReadLine();

                if(!int.TryParse(inputStr, out typeChoosen))
                {
                    throw new FormatException("The input is not an integer.");
                }

            }
            while(!(1 <= typeChoosen && typeChoosen <= Enum.GetNames(typeof(T)).Length));

            return (T)Enum.Parse(typeof(T), inputStr);
        }

        private string getEnumAsStringOptions<T>() // TODO: move to logic
        {
            StringBuilder enumTypesStrBuilder = new StringBuilder();
            int index = 1;

            foreach(string currentEnumTypeName in Enum.GetNames(typeof(T)))
            {
                enumTypesStrBuilder.AppendLine($"{index}. {currentEnumTypeName}");
                index++;
            }

            enumTypesStrBuilder.AppendLine("Enter option: ");

            return enumTypesStrBuilder.ToString();
        }

        private void printListWithIndex(List<string> i_ListToPrint)
        {
            for(int i = 1; i <= i_ListToPrint.Count; i++)
            {
                Console.WriteLine($"{i}. {i_ListToPrint[i - 1]}");
            }
        }
    }
}