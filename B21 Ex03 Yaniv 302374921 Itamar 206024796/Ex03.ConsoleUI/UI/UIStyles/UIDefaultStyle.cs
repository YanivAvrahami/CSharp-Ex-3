using System;
using Ex03.ConsoleUI.Factories;

namespace Ex03.ConsoleUI.UI.UIElements
{
    public class UIDefaultStyle : IUIStyle
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor FocusedBackgroundColor { get; set; }
        public ConsoleColor FocusedForegroundColor { get; set; }

        public UIDefaultStyle()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
            FocusedBackgroundColor = ConsoleColor.DarkBlue;
            FocusedForegroundColor = ConsoleColor.White;
        }
    }
}
