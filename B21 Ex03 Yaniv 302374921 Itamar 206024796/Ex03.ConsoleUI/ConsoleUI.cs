using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        public bool IsRunning { get; set; }

        public Garage Garage { get; set; }

        public List<string> MainMenuButtonLabels { get; set; }

        public ConsoleUI()
        {
            IsRunning = true;

            Garage = new Garage();

            initializeMainMenuButtonLabels();
        }

        public void Run()
        {
            while(IsRunning)
            {
                try
                {
                    renderMainMenu();
                    handleMenuMenuChoice();
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (IsRunning)
                {
                    pause();
                }
            }
        }

        private void handleMenuMenuChoice()
        {
            int keyPressed;
            string inputKeyPressed = Console.ReadLine();
            bool goodInput = int.TryParse(inputKeyPressed, out keyPressed);

            while (!goodInput || keyPressed <= 0 || keyPressed > MainMenuButtonLabels.Count)
            {
                Console.WriteLine("Please enter a valid menu choice!");
                inputKeyPressed = Console.ReadLine();
                goodInput = int.TryParse(inputKeyPressed, out keyPressed);
            }

            switch(keyPressed) // TODO: move to another method
            {
                case 1:
                    addVehicle();
                    break;
                case 2:
                    displayAllLicenseNumbers();
                    break;
                case 3:
                    changeVehicleState();
                    break;
                case 4:
                    inflateVehicleWheelsToMax();
                    break;
                case 5:
                    refuelPetrolVehicle();
                    break;
                case 6:
                    chargeElectricVehicle();
                    break;
                case 7:
                    displayFullCarInfo();
                    break;
                case 8:
                    exit();
                    break;
            }
        }

        private void addVehicle()
        {
            string licenseInput = ConsoleUIHelper.GetString("Enter license number: ");

            ConsoleUIHelper.PrintListWithIndex(Garage.AvailableVehiclesWithoutSpaces);

            string vehicleTypeInput = Console.ReadLine(); //TODO: check valid number
            int vehicleTypeIndex = int.Parse(vehicleTypeInput);

            Garage.AddVehicle(licenseInput, Garage.AvailableVehiclesWithoutSpaces[vehicleTypeIndex - 1]);

            List<string> propertyList = new List<string>();
            foreach(string propertyStr in Garage.GetVehiclePropertiesByLicense(licenseInput))
            {
                Console.WriteLine(propertyStr + ": ");
                string propertyInput = Console.ReadLine();
                propertyList.Add(propertyInput);
            }

            try
            {
                Garage.SetVehiclePropertiesByLicense(licenseInput, propertyList);
            }
            catch
            {
                Garage.RemoveVehicle(licenseInput);
                throw;
            }

            string fullNameInput = ConsoleUIHelper.GetString("Enter ower fullname: ");
            string phoneNumberInput = ConsoleUIHelper.GetString("Enter phone number: ");

            Garage.UpdateCustomer(licenseInput, fullNameInput, phoneNumberInput);
        }

        private void displayAllLicenseNumbers()
        {
            Console.WriteLine("Filter license numbers? (y/n):");

            string yesOrNoInput = Console.ReadLine();
            bool isLicenseNumbersFiltered = false;

            if(yesOrNoInput == "y")
            {
                isLicenseNumbersFiltered = true;
            }
            else
            {
                isLicenseNumbersFiltered = false;
            }

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

        private void renderMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Garage Menu:");
            Console.WriteLine("------------");
            foreach(string mainMenuButtonLabel in MainMenuButtonLabels)
            {
                Console.WriteLine(mainMenuButtonLabel);
            }
        }



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
            Console.Write("Enter Charging time in minutes: ");

            return userInputIncreaseEnergy();
        }

        private float userInputRefuelAmount()
        {
            Console.Write("Enter fuel amount: ");

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

            return (T)Enum.Parse(typeof(T), (typeChoosen - 1).ToString());
        }

        private string getEnumAsStringOptions<T>() // TODO: move to UI logic
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

        private void pause()
        {
            Console.WriteLine("Enter key to continue...");
            Console.ReadKey();
        }

        private void initializeMainMenuButtonLabels()
        {
            MainMenuButtonLabels = new List<string>();
            MainMenuButtonLabels.Add("1. Add a new vehicle");
            MainMenuButtonLabels.Add("2. Display all license plates");
            MainMenuButtonLabels.Add("3. Change vehicle state");
            MainMenuButtonLabels.Add("4. Inflate car wheels to max");
            MainMenuButtonLabels.Add("5. Fuel petrol car");
            MainMenuButtonLabels.Add("6. Charge electric car");
            MainMenuButtonLabels.Add("7. Display ful car info");
            MainMenuButtonLabels.Add("8. Exit");
        }
    }
}