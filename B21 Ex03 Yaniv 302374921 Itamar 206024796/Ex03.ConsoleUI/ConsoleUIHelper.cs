using System.Text;

namespace Ex03.ConsoleUI
{
    class ConsoleUIHelper
    {
        public static string CreateMenuString()
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
            return stringBuilder.ToString();
        }
    }
}
