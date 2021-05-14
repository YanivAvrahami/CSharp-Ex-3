using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            updateMenuString();
        }

        private void updateMenuString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Garage Menu:");
            stringBuilder.AppendLine("------------");
            stringBuilder.AppendLine("1. Add a new vehicle");
            stringBuilder.AppendLine("2. Display all license plates");
            stringBuilder.AppendLine("3. Change vehicle state");
            stringBuilder.AppendLine("4. Inflate car wheels to max");
            stringBuilder.AppendLine("5. Fuel petrol car");
            stringBuilder.AppendLine("6. Charge electric car");
            stringBuilder.AppendLine("7. Display full car info");
            stringBuilder.AppendLine("8. Exit");
            MenuString = stringBuilder.ToString();
        }

        public void Run()
        {
            IsRunning = true;

            while (IsRunning)
            {
                displayMenu();
                executeMenuSelection(Console.ReadLine());
                Console.WriteLine("Enter key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void executeMenuSelection(string i_StrChoice)
        {
            switch (i_StrChoice)
            {
                case "1":
                    addVehicle();
                    break;
                case "2":
                    displayAllLicensePlates();
                    break;
                case "3":
                    changeVehicleState();
                    break;
                case "4":
                    inflateVehicleWheelsToMax();
                    break;
                case "5":
                    refuelPetrolVehicle();
                    break;
                case "6":
                    chargeElectricVehicle();
                    break;
                case "7":
                    displayFullCarInfo();
                    break;
                case "8":
                    exit();
                    break;
            }
        }

        private void addVehicle()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = Console.ReadLine();

            for (int i = 1; i <= Garage.AvailableVehicles.Count; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}", i, Garage.AvailableVehicles[i - 1]));
            }

            string userInputStr = Console.ReadLine();
            int vehicleType = int.Parse(userInputStr);

            Garage.AddVehicle(licenseNumberString, Garage.AvailableVehicles[vehicleType - 1]);
        }

        private void displayAllLicensePlates()
        {
            Console.WriteLine("Filter by tag (Y/n):");
            string boolInput = Console.ReadKey().KeyChar.ToString();
            bool shouldConsiderState = boolInput.ToLower() == "y";
            eVehicleState stateTypeChoosen = eVehicleState.InRepair;

            if (shouldConsiderState)
            {
                stateTypeChoosen = userInputGetFilterState();
            }

            List<string> licenses = Garage.GetLicensesByState(shouldConsiderState, stateTypeChoosen);
            foreach (var item in licenses)
            {
                Console.WriteLine(item);
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

            if (!Garage.IsPetrolVehicle(licenseNumberString))
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

            if (!Garage.IsElectricityVehicle(licenseNumberString))
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
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter license number:");

            return userInputGetExistLicense();
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

            } while (!Garage.IsCustomerExist(licenseNumberString));

            return licenseNumberString;
        }

        private eVehicleState userInputGetFilterState()
        {
            Console.WriteLine("Filter by tags:");

            return userInputGetEnumTypeOption<eVehicleState>();
        }

        private eFuelType userInputGetFuelType()
        {
            Console.WriteLine("Fuel Types:");

            return userInputGetEnumTypeOption<eFuelType>();
        }

        private eVehicleState userInputVehicleState()
        {
            Console.WriteLine("Choose state:");

            return userInputGetEnumTypeOption<eVehicleState>();
        }

        private float userInputBatteryChargeTime()
        {
            Console.WriteLine("Enter Charging time in minutes:");

            return userInputIncreaseEnergy();
        }

        private float userInputRefuelAmount()
        {
            Console.WriteLine("Enter fuel amount:");

            return userInputIncreaseEnergy();
        }

        private float userInputIncreaseEnergy()
        {
            string EnergyToIncreaseStr;
            float EnergyToIncrease;

            EnergyToIncreaseStr = Console.ReadLine();
            if (!float.TryParse(EnergyToIncreaseStr, out EnergyToIncrease))
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

                if (!int.TryParse(inputStr, out typeChoosen))
                {
                    throw new FormatException("The input is not an integer.");
                }

            } while (!(1 <= typeChoosen && typeChoosen <= Enum.GetNames(typeof(T)).Length));

            return (T)Enum.Parse(typeof(T), inputStr);
        }











        private string getEnumAsStringOptions<T>() // TODO: move to logic
        {
            StringBuilder enumTypesStrBuilder = new StringBuilder();
            int index = 1;

            foreach (string currentEnumTypeName in Enum.GetNames(typeof(T)))
            {
                enumTypesStrBuilder.AppendLine($"{index}. {currentEnumTypeName}");
                index++;
            }

            enumTypesStrBuilder.AppendLine("Enter option: ");

            return enumTypesStrBuilder.ToString();
        }









        private void exit()
        {
            IsRunning = false;
        }

        private void displayMenu()
        {
            Console.Write(MenuString);
        }
    }


}