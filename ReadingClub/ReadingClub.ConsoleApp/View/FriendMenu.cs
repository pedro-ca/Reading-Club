using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class FriendMenu : Menu, IRegistrable
    {
        FriendController controllerFriend;

        public FriendMenu(ConsoleColor fontColor)
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
                        RegisterElement(0);
                        break;

                    case "2":
                        VisualizeElement();
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

        public void RegisterElement(int id)
        {
            Console.WriteLine("Register " + id.ToString());
        }

        public void ModifyElement()
        {
            Console.WriteLine("Modify");
        }

        public void VisualizeElement()
        {
            Console.WriteLine("Visualize");
        }

        public void RemoveElement()
        {
            Console.WriteLine("Remove");
        }

        protected override string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to insert a new Friend.");
            Console.WriteLine(" - Enter 2 to visualize existing Friends.");
            Console.WriteLine(" - Enter 3 to modify an existing Friend.");
            Console.WriteLine(" - Enter 4 to remove an existing Friend.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }
    }
}
