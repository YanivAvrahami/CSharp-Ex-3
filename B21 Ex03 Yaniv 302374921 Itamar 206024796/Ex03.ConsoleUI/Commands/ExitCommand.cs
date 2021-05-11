using System;
using Ex03.ConsoleUI.UI.UIElements;

namespace Ex03.ConsoleUI.Commands
{
    class ExitCommand : ICommand
    {
        public ConsoleUI ConsoleUI { get; set; }

        public ExitCommand(ConsoleUI i_ConsoleUI)
        {
            ConsoleUI = i_ConsoleUI;
        }

        public void Execute()
        {
            ConsoleUI.Exit();
        }
    }
}
