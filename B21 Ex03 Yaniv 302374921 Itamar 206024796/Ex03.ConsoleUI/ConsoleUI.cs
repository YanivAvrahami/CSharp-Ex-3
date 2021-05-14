using System;
using System.Collections.Generic;
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
                    displayAllLicensePlates();
                    break;
                case "3":
                    changeVehicleState();
                    break;
                case "4":
                    inflateVehicleWheelsToMax();
                    break;
                case "5":
                    fuelPetrolVehicle();
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

        private void displayAllLicensePlates()
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
            eVehicleState vehicleStateChoice;
            switch(choice)
            {
                case 1:
                    vehicleStateChoice = eVehicleState.Repair;
                    break;

                case 2:

                    break;

                case 3:

                    break;
            }

            List<string> licenseStrings = Garage.GetLicensesByState(true, );


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

        private void changeVehicleState()
        {
            Console.WriteLine("Change Car Status");
            Console.WriteLine("-----------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = Console.ReadLine();

            Console.WriteLine("Choosee state:");
            Console.WriteLine("1. Repaired");
            Console.WriteLine("2. In repair");
            Console.WriteLine("3. Paid");
            Console.WriteLine("Enter option: ");
            string stateInputString = Console.ReadLine();
            int choice = int.Parse(stateInputString);

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
            
        }

        private void fuelPetrolVehicle()
        {
            
        }

        private void chargeElectricVehicle()
        {
            
        }

        private void displayFullCarInfo()
        {
            Console.WriteLine("Customer Information");
            Console.WriteLine("--------------------");
            Console.WriteLine("Enter license number:");
            string licenseNumberString = Console.ReadLine();
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