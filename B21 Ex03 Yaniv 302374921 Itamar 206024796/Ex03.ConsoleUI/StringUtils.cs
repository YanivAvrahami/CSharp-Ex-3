using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class StringUtils
    {
        public static string GetEnumAsStringOptions<T>()
        {
            StringBuilder enumTypesStrBuilder = new StringBuilder();
            int index = 1;

            foreach (string currentEnumTypeName in Enum.GetNames(typeof(T)))
            {
                string option = StringUtils.AddSpacesToStringByUpperCase(currentEnumTypeName);

                enumTypesStrBuilder.AppendLine($"{index}.{option}");
                index++;
            }

            enumTypesStrBuilder.AppendLine("Enter option: ");

            return enumTypesStrBuilder.ToString();
        }

        public static string GetListWithIndex(List<string> i_ListToPrint)
        {
            StringBuilder listAsAstr = new StringBuilder();

            for (int i = 1; i <= i_ListToPrint.Count; i++)
            {
                listAsAstr.AppendLine($"{i}.{i_ListToPrint[i - 1]}");
            }

            return listAsAstr.ToString();
        }

        public static List<string> AddSpacesToListOfStringsByUpperCase(List<string> i_listOfStrings)
        {
            List<string> listOfSpacedStrings = new List<string>();

            foreach (string currentStr in i_listOfStrings)
            {
                listOfSpacedStrings.Add(AddSpacesToStringByUpperCase(currentStr));
            }

            return listOfSpacedStrings;
        }

        public static string AddSpacesToStringByUpperCase(string i_stringToChange)
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (char curCharInStr in i_stringToChange)
            {
                if (char.IsUpper(curCharInStr))
                {
                    strBuilder.Append(' ');
                }

                strBuilder.Append(curCharInStr);
            }

            return strBuilder.ToString();
        }
    }
}
