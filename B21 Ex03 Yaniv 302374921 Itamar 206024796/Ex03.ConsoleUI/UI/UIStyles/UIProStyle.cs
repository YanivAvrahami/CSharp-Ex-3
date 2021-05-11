using System;
using Ex03.ConsoleUI.Factories;

namespace Ex03.ConsoleUI.UI.UIElements
{
    class UIProStyle : IUIStyle
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor FocusedBackgroundColor { get; set; }
        public ConsoleColor FocusedForegroundColor { get; set; }

        public UIProStyle()
        {
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.Cyan;
            FocusedBackgroundColor = ConsoleColor.DarkGreen;
            FocusedForegroundColor = ConsoleColor.DarkCyan;
        }
    }
}
