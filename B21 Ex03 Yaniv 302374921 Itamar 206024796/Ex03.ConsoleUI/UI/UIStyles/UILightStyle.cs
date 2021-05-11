using System;
using Ex03.ConsoleUI.Factories;

namespace Ex03.ConsoleUI.UI.UIElements
{
    public class UILightStyle : IUIStyle
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor FocusedBackgroundColor { get; set; }
        public ConsoleColor FocusedForegroundColor { get; set; }

        public UILightStyle()
        {
            BackgroundColor = ConsoleColor.Cyan;
            ForegroundColor = ConsoleColor.Gray;
            FocusedBackgroundColor = ConsoleColor.DarkCyan;
            FocusedForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
