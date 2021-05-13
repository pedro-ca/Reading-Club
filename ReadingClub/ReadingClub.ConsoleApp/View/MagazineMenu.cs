using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class MagazineMenu : Menu, IRegistrable
    {
        MagazineController controllerMagazine;

        public MagazineMenu(ConsoleColor fontColor)
        {
            this.fontColor = fontColor;
        }

        public override void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayerHeader("MANAGE FRIENDS");

                string option = SelectOption();

                switch (option.ToLowerInvariant())
                {
                    case "q":
                        return;

                    case "1":
                        RegisterElement();
                        break;

                    case "2":
                        VisualizeAllElements();
                        break;

                    case "3":
                        ModifyElement();
                        break;

                    case "4":
                        RemoveElement();
                        break;

                    default:
                        DisplayErrorText("Invalid option. Use only the available options from above.");
                        Console.ReadLine();
                        continue;
                }
                Console.ReadLine();
            }
        }

        public void RegisterElement()
        {
            Console.WriteLine("Register ");
        }

        public void ModifyElement()
        {
            Console.WriteLine("Modify");
        }

        public void VisualizeAllElements()
        {
            Console.WriteLine("Visualize");
        }

        public void RemoveElement()
        {
            Console.WriteLine("Remove");
        }

        protected override string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to insert a new Magazine.");
            Console.WriteLine(" - Enter 2 to visualize existing Magazine.");
            Console.WriteLine(" - Enter 3 to modify an existing Magazine.");
            Console.WriteLine(" - Enter 4 to remove an existing Magazine.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }
    }
}
