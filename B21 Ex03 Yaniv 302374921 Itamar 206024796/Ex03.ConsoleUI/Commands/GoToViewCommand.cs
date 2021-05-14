using Ex03.ConsoleUI.UI.UIBase;

namespace Ex03.ConsoleUI.Commands
{
    class GoToViewCommand : ICommand
    {
        public ConsoleUI ConsoleUI { get; set; }
        public UIView ToView { get; set; }

        public GoToViewCommand(ConsoleUI i_ConsoleUI, UIView i_ToView)
        {
            ConsoleUI = i_ConsoleUI;
            ToView = i_ToView;
        }

        public void Execute()
        {
            ConsoleUI.GoToView(ToView);
        }
    }
}
