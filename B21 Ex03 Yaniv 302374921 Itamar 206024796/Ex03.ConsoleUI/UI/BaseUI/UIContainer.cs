using System.Collections.Generic;

namespace TEST
{
    public abstract class UIContainer : UIObject
    {
        private Point m_Position = new Point();
        private List<UIElement> m_Children;

        public List<UIElement> Children
        {
            get { return m_Children; }
            set { m_Children = value; }
        }

        public Point Position
        {
            get { return m_Position; }
            set
            {
                foreach (var currentChildElement in Children)
                {
                    Point newPosition = new Point();
                    newPosition.X = currentChildElement.Position.X + value.X - Position.X;
                    newPosition.Y = currentChildElement.Position.Y + value.Y - Position.Y;
                    currentChildElement.Position = newPosition;
                }

                m_Position = value;
            }
        }

        public UIContainer()
        {
            Children = new List<UIElement>();
        }
    }
}
