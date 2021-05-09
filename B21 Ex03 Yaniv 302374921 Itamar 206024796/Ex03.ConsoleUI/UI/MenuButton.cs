using System;

namespace TEST
{
    public class MenuButton : UIElement
    {
        private string m_Label;
        private bool m_IsMarked;

        public string Label
        {
            get { return m_Label; }
            set { m_Label = value; }
        }

        public bool IsMarked
        {
            get { return m_IsMarked; }
            set { m_IsMarked = value; }
        }

        public MenuButton(string i_Label)
        {
            Label = i_Label;
        }

        public override void Render()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Label);
        }
    }
}
