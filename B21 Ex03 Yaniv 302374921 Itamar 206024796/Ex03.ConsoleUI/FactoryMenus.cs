using System.Text;

namespace Ex03.ConsoleUI
{
    class FactoryMenus
    {
        static public string ChangeVehicleStateMenu_1()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Change Car Status");
            strBuilder.AppendLine("-----------------");
            strBuilder.AppendLine("Enter license number:");

            return strBuilder.ToString();
        }
        static public string ChangeVehicleStateMenu_2()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Choosee state:");
            strBuilder.AppendLine("1. Repaired");
            strBuilder.AppendLine("2. In repair");
            strBuilder.AppendLine("3. Paid");
            strBuilder.AppendLine("Enter option: ");

            return strBuilder.ToString();
        }
    }
}
