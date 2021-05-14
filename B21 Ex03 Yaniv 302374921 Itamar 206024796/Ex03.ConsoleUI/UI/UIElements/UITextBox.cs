using System;
using Ex03.ConsoleUI.Factories;
using Ex03.ConsoleUI.UI.UIBase;

namespace Ex03.ConsoleUI.UI.UIElements
{
    public class UITextBox : IUIInteractive
    {
        public string Text { get; set; }
        public Transform Transform { get; set; }
        public IUIStyle Style { get; set; }

        public string Input { get; set; }
        public bool IsFocused { set; get; }

        public UITextBox(string i_Text) 
            : this(i_Text, new UIDefaultStyle())
        {
        }

        public UITextBox(string i_Text, IUIStyle i_Style)
        {
            Text = i_Text;
            Transform = new Transform(1);
            IsFocused = false;
            Style = i_Style;
        }

        public void Render()
        {
            Console.SetCursorPosition(Transform.Position.X, Transform.Position.Y);

            if(IsFocused)
            {
                Console.BackgroundColor = Style.FocusedBackgroundColor;
                Console.ForegroundColor = Style.FocusedForegroundColor;
            }
            else
            {
                Console.BackgroundColor = Style.BackgroundColor;
                Console.ForegroundColor = Style.ForegroundColor;
            }

            Console.Write(Text + ": " + Input);

            Console.ResetColor();
        }

    }
}
