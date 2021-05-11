using System;

namespace Ex03.ConsoleUI.Factories
{
    public interface IUIStyle
    {
        ConsoleColor BackgroundColor { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        ConsoleColor FocusedBackgroundColor { get; set; }
        ConsoleColor FocusedForegroundColor { get; set; }
    }
}
