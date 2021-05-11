using System;
using Ex03.ConsoleUI.Factories;
using Ex03.ConsoleUI.UI.UIBase;

namespace Ex03.ConsoleUI.UI.UIElements
{
    class UICheckBox : IUIInteractive
    {
        public string Text { get; set; }
        public Transform Transform { get; set; }
        public IUIStyle Style { get; set; }

        public bool IsChecked { get; set; }
        public bool IsFocused { set; get; }

        public UICheckBox(string i_Text) 
            : this(i_Text, new UIDefaultStyle())
        {
        }

        public UICheckBox(string i_Text, IUIStyle i_Style)
        {
            Text = i_Text;
            Transform = new Transform(1);
            IsFocused = false;
            Style = i_Style;
        }

        public void Click()
        {
            if(IsChecked)
            {
                IsChecked = false;
            }
            else
            {
                IsChecked = true;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(Transform.Position.X, Transform.Position.Y);
            
            if (IsFocused)
            {
                Console.BackgroundColor = Style.FocusedBackgroundColor;
                Console.ForegroundColor = Style.FocusedForegroundColor;
                if (IsChecked)
                {

                    Console.Write("> " + Text + " x");
                }
                else
                {
                    Console.Write("> " + Text);
                }

            }
            else
            {
                Console.BackgroundColor = Style.BackgroundColor;
                Console.ForegroundColor = Style.ForegroundColor;
                if (IsChecked)
                {
                    Console.Write("  " + Text + " x");
                }
                else
                {
                    Console.Write("  " + Text);
                }
            }

            Console.ResetColor();
        }

    }
}
