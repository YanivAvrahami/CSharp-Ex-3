using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        enum eMenuOption
        {
            AddVehicle = 1,
            DisplayAllLicenses,
            ChangeVehicleState,
            InflateVehicleWheels,
            RefuelVehicle,
            ChargeVehicle,
            DisplayCarInfo,
            Exit,
        }

        private bool m_IsRunning;
        private readonly Garage r_Garage;
        private readonly ConsoleUIHelper r_UIHelper;
        private readonly List<string> r_MainMenuOptionsLabels;

        public ConsoleUI()
        {
            m_IsRunning = true;
            r_Garage = new Garage();
            r_UIHelper = new ConsoleUIHelper();

            r_MainMenuOptionsLabels = r_UIHelper.GetMainMenuOptionsLabels();
        }

        public void Run()
        {
            while(m_IsRunning)
            {
                try
                {
                    renderMainMenu();
                    handleMainMenu();
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

                if (m_IsRunning)
                {
                    pause();
                }
            }
        }

        private void renderMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Garage Menu:");
            Console.WriteLine("------------");
            foreach (string mainMenuButtonLabel in r_MainMenuOptionsLabels)
            {
                Console.WriteLine(mainMenuButtonLabel);
            }
        }

        private void handleMainMenu()
        {
            int menuChoice = r_UIHelper.AskOptionUntilValid("> Enter menu option: ", 1, r_MainMenuOptionsLabels.Count);

            handleUserMenuChoice((eMenuOption)menuChoice);
        }

        private void handleUserMenuChoice(eMenuOption i_MenuOption)
        {
            switch (i_MenuOption)
            {
                case eMenuOption.AddVehicle:
                    addVehicle();
                    break;
                case eMenuOption.DisplayAllLicenses:
                    displayAllLicenseNumbers();
                    break;
                case eMenuOption.ChangeVehicleState:
                    changeVehicleState();
                    break;
                case eMenuOption.InflateVehicleWheels:
                    inflateVehicleWheelsToMax();
                    break;
                case eMenuOption.RefuelVehicle:
                    refuelPetrolVehicle();
                    break;
                case eMenuOption.ChargeVehicle:
                    chargeElectricVehicle();
                    break;
                case eMenuOption.DisplayCarInfo:
                    displayFullCarInfo();
                    break;
                case eMenuOption.Exit:
                    exit();
                    break;
            }
        }

        private void addVehicle()
        {
            string licenseInput = r_UIHelper.GetLicenseNumber();

            List<string> availableVehicles = StringUtils.AddSpacesToListOfStringsByUpperCase(r_Garage.AvailableVehicles);

            Console.Write(StringUtils.GetListWithIndex(availableVehicles));

            int vehicleTypeIndex = r_UIHelper.AskOptionUntilValid("> Enter vehicle option: ", 1, r_Garage.AvailableVehicles.Count);

            if (r_Garage.IsCustomerExist(licenseInput))
            {
                r_Garage.ChangeVehicleState(licenseInput, eVehicleState.InRepair);
            }
            else
            {
                r_Garage.AddVehicle(licenseInput, r_Garage.AvailableVehicles[vehicleTypeIndex - 1]);
            }

            updateVehicleProperties(licenseInput);
            updateVehicleUserInfo(licenseInput);
        }

        private void displayAllLicenseNumbers()
        {
            bool isLicenseNumbersFiltered = isLicensesFilter();

            eVehicleState stateTypeChoosen = eVehicleState.InRepair;
            if(isLicenseNumbersFiltered)
            {
                stateTypeChoosen = r_UIHelper.GetFilterState();
            }

            List<string> licenses = r_Garage.GetLicensesByState(isLicenseNumbersFiltered, stateTypeChoosen);
            foreach(string license in licenses)
            {
                Console.WriteLine(license);
            }
        }

        private bool isLicensesFilter()
        {
            Console.Write("Filter license numbers? (y/n): ");
            string yesOrNoInput = Console.ReadLine();
            bool isLicenseNumbersFiltered;

            if (yesOrNoInput == "y")
            {
                isLicenseNumbersFiltered = true;
            }
            else
            {
                isLicenseNumbersFiltered = false;
            }

            return isLicenseNumbersFiltered;
        }

        private void changeVehicleState()
        {
            string licenseStr = r_UIHelper.GetLicenseNumber();
            if (r_Garage.IsCustomerExist(licenseStr))
            {
                eVehicleState stateTypeChoosen = r_UIHelper.GetVehicleState();

                r_Garage.ChangeVehicleState(licenseStr, stateTypeChoosen);
            }
            else
            {
                Console.WriteLine("License does not exist in the garage.");
            }
        }

        private void inflateVehicleWheelsToMax()
        {
            string licenseStr = r_UIHelper.GetLicenseNumber();
            if (r_Garage.IsCustomerExist(licenseStr))
            {
                r_Garage.InflateVehicleWheelsToMax(licenseStr);
            }
            else
            {
                Console.WriteLine("License does not exist in the garage.");
            }
        }

        private void refuelPetrolVehicle()
        {
            string licenseStr = r_UIHelper.GetLicenseNumber();
            if (r_Garage.IsCustomerExist(licenseStr))
            {
                if (!r_Garage.IsPetrolVehicle(licenseStr))
                {
                    Console.WriteLine("The vehicle is not petrol vehicle");
                }
                else
                {
                    eFuelType fuelType = r_UIHelper.GetFuelType();
                    float fuelAmount = r_UIHelper.RefuelAmount();

                    r_Garage.RefuelPetrolVehicle(licenseStr, fuelType, fuelAmount);
                }
            }
            else
            {
                Console.WriteLine("License does not exist in the garage.");
            }
        }

        private void chargeElectricVehicle()
        {
            string licenseStr = r_UIHelper.GetLicenseNumber();
            if (r_Garage.IsCustomerExist(licenseStr))
            {
                if (!r_Garage.IsElectricityVehicle(licenseStr))
                {
                    Console.WriteLine("The vehicle is not electricity vehicle");
                }
                else
                {
                    float batteryMinutes = r_UIHelper.BatteryChargeTime();
                    r_Garage.ChargeElectricVehicle(licenseStr, batteryMinutes);
                }
            }
            else
            {
                Console.WriteLine("License does not exist in the garage.");
            }
        }

        private void displayFullCarInfo()
        {
            string licenseStr = r_UIHelper.GetLicenseNumber();
            if (r_Garage.IsCustomerExist(licenseStr))
            {
                Console.WriteLine(r_Garage.GetCustomerInformationAsAstring(licenseStr));
            }
            else
            {
                Console.WriteLine("License does not exist in the garage.");
            }
        }

        private void updateVehicleProperties(string i_LicenseNumber)
        {
            List<string> propertyList = new List<string>();
            foreach (string propertyStr in r_Garage.GetVehiclePropertiesByLicense(i_LicenseNumber))
            {
                Console.Write("> " + propertyStr + ": ");
                string propertyInput = Console.ReadLine();
                propertyList.Add(propertyInput);
            }

            try
            {
                r_Garage.SetVehiclePropertiesByLicense(i_LicenseNumber, propertyList);
            }
            catch
            {
                r_Garage.RemoveVehicle(i_LicenseNumber);
                throw;
            }
        }

        private void updateVehicleUserInfo(string i_LicenseNumber)
        {
            string fullNameInput = r_UIHelper.GetString("Enter ower fullname: ");
            string phoneNumberInput = r_UIHelper.GetString("Enter phone number: ");

            r_Garage.UpdateCustomer(i_LicenseNumber, fullNameInput, phoneNumberInput);
        }

        private void exit()
        {
            m_IsRunning = false;
        }

        private void pause()
        {
            Console.WriteLine("Enter key to continue...");
            Console.ReadKey();
        }
    }
}