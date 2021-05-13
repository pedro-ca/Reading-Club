using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class MainMenu : Menu
    {
        public MainMenu(ConsoleColor fontColor)
        {
            this.fontColor = fontColor;
        }

        public override void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayerHeader("READING CLUB");

                Menu menu;

                string option = SelectOption();

                switch (option.ToLowerInvariant())
                {
                    case "q":
                        return;

                    case "1":
                        menu = new FriendMenu(fontColor);
                        break;

                    case "2":
                        menu = new StorageBoxMenu(fontColor);
                        break;

                    case "3":
                        menu = new MagazineMenu(fontColor);
                        break;

                    case "4":
                        Console.WriteLine("Option 4 - NOT IMPLEMENTED");
                        Console.ReadLine();
                        continue;

                    default:
                        DisplayErrorText("Invalid option. Use only the available options from above.");
                        Console.ReadLine();
                        continue;
                }

                menu.ShowMenu();
            }
        }
        
        protected override string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to manage Friends.");
            Console.WriteLine(" - Enter 2 to manage Storage Boxes.");
            Console.WriteLine(" - Enter 3 to manage Magazines.");
            Console.WriteLine(" - Enter 4 to manage Borrows and Lends.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }
    }
}
