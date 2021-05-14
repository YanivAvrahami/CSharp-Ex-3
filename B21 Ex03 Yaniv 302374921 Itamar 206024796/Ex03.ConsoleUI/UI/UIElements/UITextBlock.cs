using System;
using Ex03.ConsoleUI.Factories;
using Ex03.ConsoleUI.UI.UIBase;

namespace Ex03.ConsoleUI.UI.UIElements
{
    public class UITextBlock : IUIElement
    {
        public string Text { get; set; }
        public Transform Transform { get; set; }
        public IUIStyle Style { get; set; }

        private bool m_IsUnderlined;
        public bool IsUnderlined
        {
            get { return m_IsUnderlined; }
            set
            {
                m_IsUnderlined = value;
                Transform.Height = value == true ? 2 : 1;
            }
        }

        public UITextBlock()
            : this("", false)
        {
        }

        public UITextBlock(string i_Text)
            : this(i_Text, false)
        {
        }

        public UITextBlock(string i_Text, bool i_IsUnderlined) 
            : this(i_Text, i_IsUnderlined, new UIDefaultStyle())
        {
        }

        public UITextBlock(string i_Text, bool i_IsUnderlined, IUIStyle i_Style)
        {
            Text = i_Text;
            Transform = new Transform();
            IsUnderlined = i_IsUnderlined;
            Style = i_Style;
        }

        public void Render()
        {
            Console.BackgroundColor = Style.BackgroundColor;
            Console.ForegroundColor = Style.ForegroundColor;

            Console.SetCursorPosition(Transform.Position.X, Transform.Position.Y);
            Console.WriteLine(Text);
            if(IsUnderlined)
            {
                ConsoleUtils.WriteUnderline(Text.Length, Transform.Position.X, Transform.Position.Y + 1);
            }

            Console.ResetColor();
        }
    }
}
