using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    class Menu : UIContainer, IRenderable
    {
        private int m_IndexOfCurrentButton;

        public Menu()
        {
            m_IndexOfCurrentButton = 0;
        }

        public void AddButton(MenuButton i_MenuButton)
        {
            i_MenuButton.Position = new Point(Position.X, Position.Y + Children.Count);
            Children.Add(i_MenuButton);
        }

        public override void Render()
        {
            foreach (var item in Children)
            {
                item.Render();
            }
        }
    }
}
