using System;
using Ex03.ConsoleUI.Factories;
using Ex03.ConsoleUI.UI.UIElements;

namespace Ex03.ConsoleUI.UI.UIBase
{
    public interface IUIElement
    {
        Transform Transform { get; set; }
        IUIStyle Style { get; set; }
        
        void Render();
    }
}
