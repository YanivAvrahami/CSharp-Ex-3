using Ex03.ConsoleUI.Commands;
using Ex03.ConsoleUI.UI.UIBase;
using Ex03.ConsoleUI.UI.UIElements;

namespace Ex03.ConsoleUI.Factories
{
    public class UIViewFactory
    {
        public ConsoleUI ConsoleUI { get; set; }

        public UIViewFactory(ConsoleUI i_ConsoleUI)
        {
            ConsoleUI = i_ConsoleUI;
        }

        public UIView CreateGarageMenuView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Garage Menu", true));

            GoToViewCommand command = new GoToViewCommand(ConsoleUI, CreateEnterNewCarView());
            view.AddUIElement(new UIButton("Add new car", command));

            command = new GoToViewCommand(ConsoleUI, CreateDisplayAllLicensePlatesView());
            view.AddUIElement(new UIButton("Display all license plates", command));

            command = new GoToViewCommand(ConsoleUI, CreateChangeCarStatusView());
            view.AddUIElement(new UIButton("Change car status", command));

            command = new GoToViewCommand(ConsoleUI, CreateInflateCarWheelsToMaximumView());
            view.AddUIElement(new UIButton("Inflate car wheels to maximum", command));

            command = new GoToViewCommand(ConsoleUI, CreateFuelPetrolCarView());
            view.AddUIElement(new UIButton("Fuel petrol car", command));

            command = new GoToViewCommand(ConsoleUI, CreateChargeElectricCarView());
            view.AddUIElement(new UIButton("Charge electric car", command));

            command = new GoToViewCommand(ConsoleUI, CreateDisplayFullCarInfoView());
            view.AddUIElement(new UIButton("Display full car information", command));

            view.AddUIElement(new UIButton("Exit", new ExitProgramCommand(ConsoleUI)), 1);
            return view;
        }

        public UIView CreateEnterNewCarView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Enter New Car", true));
            view.AddUIElement(new UITextBox("Model name"));
            view.AddUIElement(new UITextBox("License number"));
            view.AddUIElement(new UITextBox("Energy percentage"));
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1);
            return view;
        }

        public UIView CreateDisplayAllLicensePlatesView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Display All License Plates", true));
            view.AddUIElement(new UITextBlock("filter by tags:", false));
            view.AddUIElement(new UICheckBox("Repaired"));
            view.AddUIElement(new UICheckBox("In repair"));
            view.AddUIElement(new UICheckBox("Paid up"));
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1);
            view.AddUIElement(new UITextBlock(), 1);
            return view;
        }

        public UIView CreateChangeCarStatusView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Change Car Status", true));
            view.AddUIElement(new UITextBox("License number"));
            view.AddUIElement(new UITextBlock("Choose status:"), 1);
            view.AddUIElement(new UICheckBox("Repaired"));
            view.AddUIElement(new UICheckBox("In repair"));
            view.AddUIElement(new UICheckBox("Paid up"));
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1);
            return view;
        }

        public UIView CreateInflateCarWheelsToMaximumView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Inflate Car Wheels To Maximum", true));
            view.AddUIElement(new UITextBox("License number"));
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1);
            return view;
        }

        public UIView CreateFuelPetrolCarView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Fuel Petrol Car", true));
            view.AddUIElement(new UITextBox("License number"));
            view.AddUIElement(new UITextBlock("Choose fuel type:"), 1);
            view.AddUIElement(new UICheckBox("Solar"));
            view.AddUIElement(new UICheckBox("Octan95"));
            view.AddUIElement(new UICheckBox("Octan96"));
            view.AddUIElement(new UICheckBox("Octan98"));
            view.AddUIElement(new UITextBox("Quantity of filling"), 1);
            view.AddUIElement(new UIButton("Fuel", new ExitProgramCommand(ConsoleUI)), 1);
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1); 
            return view;
        }

        public UIView CreateChargeElectricCarView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Charge Electric Car", true));
            view.AddUIElement(new UITextBox("License number"));
            view.AddUIElement(new UITextBox("Duration in minutes"));
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1);
            return view;
        }

        public UIView CreateDisplayFullCarInfoView()
        {
            UIView view = new UIView();
            view.AddUIElement(new UITextBlock("Display Full Car Information", true));
            view.AddUIElement(new UITextBox("License number"));
            view.AddUIElement(new UITextBlock("Information", true), 1);
            view.AddUIElement(new UIButton("Back", new GoToHomeViewCommand(ConsoleUI)), 1);
            return view;
        }
    }
}
