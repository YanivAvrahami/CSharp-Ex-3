using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class ConsoleUIHelper
    {
        public List<string> GetMainMenuOptionsLabels()
        {
            List<string> mainMenuOptions = new List<string>();

            mainMenuOptions.Add("1. Add a new vehicle");
            mainMenuOptions.Add("2. Display all license plates");
            mainMenuOptions.Add("3. Change vehicle state");
            mainMenuOptions.Add("4. Inflate car wheels to max");
            mainMenuOptions.Add("5. Fuel petrol car");
            mainMenuOptions.Add("6. Charge electric car");
            mainMenuOptions.Add("7. Display ful car info");
            mainMenuOptions.Add("8. Exit");

            return mainMenuOptions;
        }

        public string GetString(string i_PriorMessage)
        {
            Console.Write(i_PriorMessage);
            return Console.ReadLine();
        }

        public int AskOptionUntilValid(string i_MessageToAsk, int i_MinVal, int i_MaxVal)
        {
            int userChoice;
            bool isGoodInput;

            do
            {
                Console.Write(i_MessageToAsk);
                string userInputStr = Console.ReadLine();
                isGoodInput = int.TryParse(userInputStr, out userChoice);

            }
            while (!isGoodInput || !(i_MinVal <= userChoice && userChoice <= i_MaxVal));

            return userChoice;
        }

        public string GetLicenseNumber()
        {
            return GetString("> Enter license number: ");
        }

        public eVehicleState GetFilterState()
        {
            Console.WriteLine("Filter by tags:");

            return getEnumTypeOption<eVehicleState>();
        }

        public eFuelType GetFuelType()
        {
            Console.WriteLine("Fuel Types:");

            return getEnumTypeOption<eFuelType>();
        }

        public eVehicleState GetVehicleState()
        {
            Console.WriteLine("Choose state:");

            return getEnumTypeOption<eVehicleState>();
        }

        public float BatteryChargeTime()
        {
            Console.Write("Enter Charging time in minutes: ");

            return IncreaseEnergy();
        }

        public float RefuelAmount()
        {
            Console.Write("Enter fuel amount: ");

            return IncreaseEnergy();
        }

        public float IncreaseEnergy()
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

        private T getEnumTypeOption<T>()
        {
            Console.WriteLine(StringUtils.GetEnumAsStringOptions<T>());

            int typeChoosen = AskOptionUntilValid("> Enter option: ", 1, Enum.GetValues(typeof(T)).Length);

            return (T)Enum.Parse(typeof(T), (typeChoosen - 1).ToString());
        }
    }
}