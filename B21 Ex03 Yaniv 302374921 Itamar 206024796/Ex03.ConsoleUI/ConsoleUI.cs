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
            UpdateMenuString();
        }

        void UpdateMenuString()
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
            Console.ReadLine();

            while (IsRunning)
            {
                Console.Clear();
                DisplayMenu();
                string stringInput = Console.ReadLine();
                executeMenuSelection(stringInput);
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
                    DisplayAllLicensePlates();
                    break;
                case "3":
                    ChangeVehicleState();
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
            throw new NotImplementedException();
        }

        private void DisplayAllLicensePlates()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Display All License Plates");
            strBuilder.AppendLine("--------------------------");
            strBuilder.AppendLine("Filter by tags:");
            strBuilder.AppendLine("1. Repaired");
            strBuilder.AppendLine("2. In Repair");
            strBuilder.AppendLine("3. Paid");
            strBuilder.AppendLine("");
            Console.WriteLine(strBuilder);

            string inputString = Console.ReadLine();
            int choice = int.Parse(inputString);

            List<string> licenseStrings;


            switch(choice)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
            }
            
        }

        private void ChangeVehicleState()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = userInputGetExistLicense();

            int choice = userInputVehicleState();

            List<string> licenseStrings;


            switch (choice)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
            }
        }

        private void inflateVehicleWheelsToMax()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = userInputGetExistLicense();

            Garage.InflateVehicleWheelsToMax(licenseNumberString);
        }

        private void refuelPetrolVehicle()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = userInputGetExistLicense();

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
            Console.WriteLine("--------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = userInputGetExistLicense();

            if (!Garage.IsElectricityVehicle(licenseNumberString))
            {
                Console.WriteLine("The vehicle is not electricity");
            }
            else
            {
                int batteryMinutes = userInputBatteryChargeTime();

                Garage.ChargeElectricVehicle(licenseNumberString, batteryMinutes);
            }
        }

        private void displayFullCarInfo()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = userInputGetExistLicense();

            Console.WriteLine(Garage.GetCustomerInformationAsAstring(licenseNumberString));
        }

        private string userInputGetExistLicense()
        {
            string licenseNumberString;

            do
            {
                licenseNumberString = Console.ReadLine();

            } while (Garage.IsCustomerExist(licenseNumberString));

            return licenseNumberString;
        }

        private eFuelType userInputGetFuelType()
        {
            Console.WriteLine("Fuel Types:");
            Console.WriteLine(getEnumAsStringOptions<eFuelType>());

            string fuelTypeStr;
            int fuelTypeChoosen;

            do
            {
                fuelTypeStr = Console.ReadLine();

                if (!int.TryParse(fuelTypeStr, out fuelTypeChoosen))
                {
                    throw new FormatException("The input is not an integer.");
                }

            } while (1 <= fuelTypeChoosen && fuelTypeChoosen <= Enum.GetNames(typeof(eFuelType)).Length);

            return (eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeStr);
        }

        private int userInputBatteryChargeTime()
        {
            Console.WriteLine("Enter Charging time in minutes:");

            string batteryMinutesStr;
            int batteryMinutes;

            batteryMinutesStr = Console.ReadLine();
            if (!int.TryParse(batteryMinutesStr, out batteryMinutes))
            {
                throw new FormatException("The input is not an integer.");
            }

            return batteryMinutes;
        }

        private float userInputRefuelAmount()
        {
            Console.WriteLine("Enter fuel amount:");

            string refuelAmountStr;
            float refuelAmount;

            refuelAmountStr = Console.ReadLine();
            if (!float.TryParse(refuelAmountStr, out refuelAmount))
            {
                throw new FormatException("The input is not a float.");
            }

            return refuelAmount;
        }

        private int userInputVehicleState()
        {
            Console.WriteLine("Choose state:");
            Console.WriteLine(getEnumAsStringOptions<eVehicleState>());

            string stateInputStr;
            int stateChoosen;

            do
            {
                stateInputStr = Console.ReadLine();

                if (!int.TryParse(stateInputStr, out stateChoosen))
                {
                    throw new FormatException("The input is not an integer.");
                }

            } while (1 <= stateChoosen && stateChoosen <= Enum.GetNames(typeof(eVehicleState)).Length);

            return stateChoosen;
        }

        private string getEnumAsStringOptions<T>() // TODO: fuck off to another class lazzy bitch
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

        void DisplayMenu()
        {
            Console.Write(MenuString);
        }
    }


}