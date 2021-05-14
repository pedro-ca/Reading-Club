using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class MainMenu : Menu
    {
        FriendController controllerFriend;
        StorageBoxController controllerStorageBox;
        MagazineController controllerMagazine;
        BorrowingController controllerBorrowing;

        public MainMenu(ConsoleColor fontColor)
        {
            controllerFriend = new FriendController();
            controllerStorageBox = new StorageBoxController();
            controllerMagazine = new MagazineController();
            controllerBorrowing = new BorrowingController();
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
                        menu = new FriendMenu(controllerFriend,fontColor);
                        break;

                    case "2":
                        menu = new StorageBoxMenu(controllerStorageBox,fontColor);
                        break;

                    case "3":
                        menu = new MagazineMenu(controllerMagazine,controllerStorageBox,fontColor);
                        break;

                    case "4":
                        menu = new BorrowingMenu(controllerBorrowing, controllerFriend, controllerMagazine, fontColor);
                        break;

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
            Console.WriteLine(" - Enter 4 to manage Borrowings of magazines to friends.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }
    }
}
