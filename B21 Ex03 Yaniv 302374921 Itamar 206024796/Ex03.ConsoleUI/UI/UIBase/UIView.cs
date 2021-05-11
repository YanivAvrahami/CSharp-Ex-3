using System.Collections.Generic;
using Ex03.ConsoleUI.UI.UIBase;

namespace Ex03.ConsoleUI.UIClasses.BaseUI
{
    public class UIView
    {
        public List<IUIElement> UIElements { get; set; }
        public int CurrentIndex { get; set; }

        private IUIInteractive m_CurrentUIInteractive;
        public IUIInteractive CurrentUIInteractive {
            get { return UIElements[CurrentIndex] as IUIInteractive; }
            set { m_CurrentUIInteractive = value; }
        }

        public int Bottom { set; get; }

        public UIView()
        {
            UIElements = new List<IUIElement>();
            Bottom = 0;
        }

        public void AddUIElement(IUIElement i_UIElement)
        {
            i_UIElement.Transform.Position.X = 0;
            i_UIElement.Transform.Position.Y = Bottom;

            UIElements.Add(i_UIElement);
            Bottom += i_UIElement.Transform.Height;
        }

        public void AddUIElement(IUIElement i_UIElement, int i_Space)
        {
            i_UIElement.Transform.Position.X = 0;
            i_UIElement.Transform.Position.Y = Bottom + i_Space;

            UIElements.Add(i_UIElement);
            Bottom = Bottom + i_UIElement.Transform.Height + i_Space;
        }

        public void FocusPreviousUIInteractive()
        {
            int nextIndex = CurrentIndex - 1;
            if (nextIndex == -1)
            {
                nextIndex = UIElements.Count - 1;
            }

            IUIElement uiElementToCheckIfInteractive = UIElements[nextIndex];

            while ( !(uiElementToCheckIfInteractive is IUIInteractive) )
            {
                nextIndex--;
                if (nextIndex == -1)
                {
                    nextIndex = UIElements.Count - 1;
                }
                uiElementToCheckIfInteractive = UIElements[nextIndex];
            }

            IUIInteractive uiInteractive = (IUIInteractive)UIElements[CurrentIndex];
            uiInteractive.IsFocused = false;
            CurrentIndex = nextIndex;
            uiInteractive = (IUIInteractive)UIElements[CurrentIndex];
            uiInteractive.IsFocused = true;
        }

        public void FocusNextUIInteractive()
        {
            int nextIndex = CurrentIndex + 1;
            if(nextIndex == UIElements.Count)
            {
                nextIndex = 0;
            }

            IUIElement uiElementToCheckIfInteractive = UIElements[nextIndex];

            while( !(uiElementToCheckIfInteractive is IUIInteractive) )
            {
                nextIndex++;
                if (nextIndex == UIElements.Count)
                {
                    nextIndex = 0;
                }
                uiElementToCheckIfInteractive = UIElements[nextIndex];
            }

            IUIInteractive uiInteractive = (IUIInteractive)UIElements[CurrentIndex];
            uiInteractive.IsFocused = false;
            CurrentIndex = nextIndex;
            uiInteractive = (IUIInteractive)UIElements[CurrentIndex];
            uiInteractive.IsFocused = true;
        }

        public void FocusFirstUIInteractive()
        {
            for(int i = 0; i < UIElements.Count; i++)
            {
                if(UIElements[i] is IUIInteractive)
                {
                    CurrentIndex = i;
                    IUIInteractive uiInteractive = (IUIInteractive)UIElements[i];
                    uiInteractive.IsFocused = true;
                    break;
                }
            }
            
        }

        public bool IsUIInteractiveExist()
        {
            bool isExist = false;

            foreach (IUIElement uiElement in UIElements)
            {
                if (uiElement is IUIInteractive)
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }

        public void Render()
        {
            foreach (IUIElement uiElement in UIElements)
            {
                uiElement.Render();
            }
        }
    }
}
