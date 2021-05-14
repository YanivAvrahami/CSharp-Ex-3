using System;
using Ex03.ConsoleUI.Factories;
using Ex03.ConsoleUI.UI.UIBase;
using Ex03.ConsoleUI.UI.UIElements;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        public UIView CurrentUIView { get; set; }
        public UIViewFactory UIViewFactory { get; }
        public bool IsRunning { get; set; }

        public ConsoleUI()
        {
            UIViewFactory = new UIViewFactory(this);
            GoToView(UIViewFactory.CreateGarageMenuView());
            IsRunning = true;
        }

        public void Run()
        {
            render();
            while (IsRunning)
            {
                handleInput();
                render();
            }
        }

        public void Exit()
        {
            IsRunning = false;
        }

        private void handleInput()
        {
            ConsoleKey keyPressed = getUserInput();

            if (keyPressed == ConsoleKey.DownArrow)
            {
                CurrentUIView.FocusNextUIInteractive();
            }
            else if (keyPressed == ConsoleKey.UpArrow)
            {
                CurrentUIView.FocusPreviousUIInteractive();
            }
            else if (keyPressed == ConsoleKey.Enter)
            {
                if (CurrentUIView.CurrentUIInteractive is UIButton uiButton)
                {
                    uiButton.Click();
                }
                else if (CurrentUIView.CurrentUIInteractive is UICheckBox uiCheckBox)
                {
                    uiCheckBox.Click();
                }
                else if (CurrentUIView.CurrentUIInteractive is UITextBox uiTextBox)
                {
                    CurrentUIView.FocusNextUIInteractive();
                }
            }
            else if (keyPressed == ConsoleKey.Backspace || keyPressed == ConsoleKey.Delete)
            {
                if (CurrentUIView.CurrentUIInteractive is UITextBox uiTextBox)
                {
                    if (uiTextBox.Input != "")
                    {
                        uiTextBox.Input = uiTextBox.Input.Remove(uiTextBox.Input.Length - 1, 1);
                    }
                }
            }
            else if(keyPressed == ConsoleKey.Spacebar)
            {
                if (CurrentUIView.CurrentUIInteractive is UIButton uiButton)
                {
                    uiButton.Click();
                }
                else if (CurrentUIView.CurrentUIInteractive is UICheckBox uiCheckBox)
                {
                    uiCheckBox.Click();
                }
                else if (CurrentUIView.CurrentUIInteractive is UITextBox uiTextBox)
                {
                    uiTextBox.Input += " ";
                }
            }
            else
            {
                if (CurrentUIView.CurrentUIInteractive is UITextBox uiTextBox)
                {
                    uiTextBox.Input += keyPressed.ToString().ToLower();
                }
            }
        }

        private ConsoleKey getUserInput()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            return keyPressed.Key;
        }

        private void render()
        {
            Console.Clear();
            CurrentUIView.Render();
        }

        public void GoToView(UIView i_ToView)
        {
            if(CurrentUIView != null)
            {
                CurrentUIView.CurrentUIInteractive.IsFocused = false;
            }

            CurrentUIView = i_ToView;

            if (CurrentUIView.IsUIInteractiveExist())
            {
                CurrentUIView.FocusFirstUIInteractive();
            }
        }

        public void GoToPreviousView()
        {
            CurrentUIView.CurrentUIInteractive.IsFocused = false;
            GoToView(UIViewFactory.CreateGarageMenuView());
        }
    }
}
