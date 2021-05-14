namespace Ex03.ConsoleUI.Commands
{
    class ExitProgramCommand : ICommand
    {
        public ConsoleUI ConsoleUI { get; set; }

        public ExitProgramCommand(ConsoleUI i_ConsoleUI)
        {
            ConsoleUI = i_ConsoleUI;
        }

        public void Execute()
        {
            ConsoleUI.Exit();
        }
    }
}
