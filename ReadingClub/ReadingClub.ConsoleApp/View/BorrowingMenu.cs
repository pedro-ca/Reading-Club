using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
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

        private void RegisterBorrowingOpening()
        {
            DisplayerHeader("REGISTER BORROWING");

            Console.WriteLine(" - Enter id of the Borrowed magazine.");
            string magazineIdTxt = Console.ReadLine();

            if (!int.TryParse(magazineIdTxt, out int magazineId))
            {
                DisplayErrorText("Attribute id of the magazine must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter id of the friend that Borrowed the magazine");
            string friendIdTxt = Console.ReadLine();

            if (!int.TryParse(friendIdTxt, out int friendId))
            {
                DisplayErrorText("Attribute id of the storage box must a valid integer.");
                return;
            }

            Friend friend = (Friend)controllerFriend.SelectEntityById(friendId);
            Magazine magazine = (Magazine)controllerMagazine.SelectEntityById(magazineId);

            Borrowing borrowing = new Borrowing(0, magazine, friend, DateTime.Now);
            string response = controllerBorrowing.CreateBorrowing(borrowing);

            if (response != "OP_SUCCESS")
                DisplayErrorText(response);
            else
            {
                DisplaySuccessText("Register Operation Sucessful");
                Console.ReadLine();
                return;
            }
        }

        private void RegisterBorrowingReturn()
        {

            DisplayerHeader("REGISTER RETURN");

            Console.WriteLine(" - Enter id of the Borrowing to close.");
            string borrowindIdTxxt = Console.ReadLine();

            if (!int.TryParse(borrowindIdTxxt, out int borrowingId))
            {
                DisplayErrorText("Attribute id of the borrow must be a valid integer.");
                return;
            }

            string response;
            Borrowing borrow = (Borrowing)controllerBorrowing.SelectEntityById(borrowingId);
            if (IsBorrowOpen(borrow))
            {
                borrow.ReturnDate = DateTime.Now;
                response = "OP_SUCcESS";
            }
            else
            {
                response = "Error: Borrowing is closed.";
            }

            if (response != "OP_SUCcESS")
                DisplayErrorText(response);
            else
            {
                DisplaySuccessText("Register Operation Sucessful");
                Console.ReadLine();
                return;
            }
        }

        private void VisualizeOpenBorrowingsOfDay()
        {
            object[] borrowings = controllerBorrowing.SelectAllEntities();
            DisplayerHeader("OPEN DAY BORROWINGS");
            foreach (Borrowing b in borrowings)
            {
                if (IsBorrowOpen(b))
                {
                    Console.WriteLine($"  - Storage Borrowing {b.Id}: {b.Magazine.MagazineCollection}, {b.Friend.Name}, {b.BorrowingDate}, {b.ReturnDate}");
                }
            }
        }

        private void VisualizeBorrowingsOfMonth()
        {
            object[] borrowings = controllerBorrowing.SelectAllEntities();
            DisplayerHeader("ALL MONTH BORROWINGS");
            foreach (Borrowing b in borrowings)
            {
                if(DateTime.Now.Month == b.BorrowingDate.Month) 
                {
                    Console.WriteLine($"  - Storage Borrowing {b.Id}: {b.Magazine.MagazineCollection}, {b.Friend.Name}, {b.BorrowingDate}, {b.ReturnDate}");
                }
            }
        }

        protected override string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to registrate a new magazine Borrowing.");
            Console.WriteLine(" - Enter 2 to registrate a magazine Borrowing's return date.");
            Console.WriteLine(" - Enter 3 to view all Borrowings from this month.");
            Console.WriteLine(" - Enter 4 to view open Borrowings from today.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }

        private static bool IsBorrowOpen(Borrowing borrow)
        {
            return DateTime.Now.DayOfYear == borrow.BorrowingDate.DayOfYear && borrow.ReturnDate == DateTime.MinValue;
        }
    }
}
