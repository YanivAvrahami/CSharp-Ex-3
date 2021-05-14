using System;

namespace Ex03.ConsoleUI
{
    class ConsoleUtils
    {
        public static void WriteUnderline(int i_UnderlineLength, int i_X, int i_Y)
        {
            Console.SetCursorPosition(i_X, i_Y);
            for (int i = 0; i < i_UnderlineLength; i++)
            {
                Console.Write('-');
            }
        }
    }
}