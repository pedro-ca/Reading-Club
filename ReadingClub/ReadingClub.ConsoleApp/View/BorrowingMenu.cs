using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class BorrowingMenu : Menu
    {
        private BorrowingController controllerBorrowing;
        private FriendController controllerFriend;
        private MagazineController controllerMagazine;

        public BorrowingMenu(BorrowingController controllerBorrowing, FriendController controllerFriend, MagazineController controllerMagazine, ConsoleColor fontColor)
        {
            this.controllerBorrowing = controllerBorrowing;
            this.controllerFriend = controllerFriend;
            this.controllerMagazine = controllerMagazine;
            this.fontColor = fontColor;
        }

        public override void ShowMenu()
        {
            while(true)
            {
                Console.Clear();
                DisplayerHeader("MANAGE BORROWINGS");

                string option = SelectOption();

                switch (option.ToLowerInvariant())
                {
                    case "q":
                        return;

                    case "1":
                        RegisterBorrowingOpening();
                        break;

                    case "2":
                        RegisterBorrowingReturn();
                        break;

                    case "3":
                        VisualizeBorrowingsOfMonth();
                        break;

                    case "4":
                        VisualizeOpenBorrowingsOfDay();
                        break;

                    default:
                        DisplayErrorText("Invalid option. Use only the available options from above.");
                        break;
                }
                Console.ReadLine();
            }
        }

        private void VisualizeOpenBorrowingsOfDay()
        {
            throw new NotImplementedException();
        }

        private void VisualizeBorrowingsOfMonth()
        {
            throw new NotImplementedException();
        }

        private void RegisterBorrowingReturn()
        {
            throw new NotImplementedException();
        }

        private void RegisterBorrowingOpening()
        {
            throw new NotImplementedException();
        }

        public void RegisterBorrowing()
        {

        }

        protected override string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to registrate a new magazine Borrowing.");
            Console.WriteLine(" - Enter 2 to registrate a magazine Borrowing's return date.");
            Console.WriteLine(" - Enter 3 to view all Borrowings from this month.");
            Console.WriteLine(" - Enter 3 to view open Borrowings from today.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }

    }
}
