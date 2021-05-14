namespace Ex03.ConsoleUI.Commands
{
    class GoToHomeViewCommand : ICommand
    {
        public ConsoleUI ConsoleUI { get; set; }

        public GoToHomeViewCommand(ConsoleUI i_ConsoleUI)
        {
            ConsoleUI = i_ConsoleUI;
        }

        public void Execute()
        {
            ConsoleUI.GoToPreviousView();
        }
    }
}
