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
                    case "s":
                        return;

                    case "1":
                        Console.WriteLine("Option 1");
                        menu = new FriendMenu();
                        break;

                    case "2":
                        Console.WriteLine("Option 2");
                        menu = new StorageBoxMenu();
                        break;

                    case "3":
                        Console.WriteLine("Option 3");
                        menu = new MagazineMenu();
                        break;

                    case "4":
                        Console.WriteLine("Option 4");
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
            Console.WriteLine(" - Enter S to exit;");

            string option = Console.ReadLine();

            return option;
        }
    }
}
