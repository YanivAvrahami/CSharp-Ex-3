using System;
using Ex03.ConsoleUI.Factories;

namespace Ex03.ConsoleUI.UI.UIElements
{
    public class UIDarkStyle : IUIStyle
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor FocusedBackgroundColor { get; set; }
        public ConsoleColor FocusedForegroundColor { get; set; }

        public UIDarkStyle()
        {
            BackgroundColor = ConsoleColor.Red;
            ForegroundColor = ConsoleColor.White;
            FocusedBackgroundColor = ConsoleColor.DarkRed;
            FocusedForegroundColor = ConsoleColor.Gray;
        }
    }
}
