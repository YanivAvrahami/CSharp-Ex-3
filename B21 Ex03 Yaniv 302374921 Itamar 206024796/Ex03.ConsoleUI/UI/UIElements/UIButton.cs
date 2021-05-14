using System;
using Ex03.ConsoleUI.Commands;
using Ex03.ConsoleUI.Factories;
using Ex03.ConsoleUI.UI.UIBase;

namespace Ex03.ConsoleUI.UI.UIElements
{
    public class UIButton : IUIInteractive
    {
        public string Text { get; }
        public Transform Transform { get; set; }
        public IUIStyle Style { get; set; }
        public bool IsFocused { get; set; }
        public ICommand Command { get; set; }

        public UIButton(string i_Text, ICommand i_Command)
            : this(i_Text, i_Command, new UIDefaultStyle())
        {
        }

        public UIButton(string i_Text, ICommand i_Command, IUIStyle i_Style)
            : this(i_Text, i_Command, new Transform(1), i_Style)
        {
        }

        public UIButton(string i_Text, ICommand i_Command, Transform i_Transform, IUIStyle i_Style)
        {
            Text = i_Text;
            Command = i_Command;
            Transform = i_Transform;
            IsFocused = false;
            Style = i_Style;
        }

        public void Click()
        {
            Command.Execute();
        }

        public void Render()
        {
            Console.SetCursorPosition(Transform.Position.X, Transform.Position.Y);

            if (IsFocused)
            {
                Console.BackgroundColor = Style.FocusedBackgroundColor;
                Console.ForegroundColor = Style.FocusedForegroundColor;
                Console.Write("> " + Text);
            }
            else
            {
                Console.BackgroundColor = Style.BackgroundColor;
                Console.ForegroundColor = Style.ForegroundColor;
                Console.Write("  " + Text);
            }

            Console.ResetColor();
        }

    }
}
