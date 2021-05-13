using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class FriendMenu : Menu, IRegistrable
    {
        FriendController controllerFriend = new FriendController();

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
            DisplayerHeader("REGISTER FRIEND");

            Console.WriteLine(" - Enter id of the new registered friend.");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter name of the new registered friend.");
            string name = Console.ReadLine();

            Console.WriteLine(" - Enter name of the legal guardian of the new registered friend.");
            string nameGuardian = Console.ReadLine();

            Console.WriteLine(" - Enter telephone of the new registered friend.");
            string telephone = Console.ReadLine();

            Console.WriteLine(" - Enter address of the new registered friend.");
            string address = Console.ReadLine();

            string response = controllerFriend.CreateFriend(id, name, nameGuardian, telephone, address);

            if (response != "Register Operation Sucessful")
                DisplayErrorText(response);
            else
                DisplaySuccessText(response);
        }

        public void VisualizeAllElements()
        {
            object[] friends = controllerFriend.SelectAllEntities();
            DisplayerHeader("REGISTERED FRIEDS");
            foreach(Friend f in friends)
            {
                Console.WriteLine($"  - Friend {f.Id}: {f.Name}");
            }
        }

        public void ModifyElement()
        {
            Console.WriteLine("Modify");
        }

        public void RemoveElement()
        {
            VisualizeAllElements();

            DisplayerHeader("REMOVE FRIEND");

            Console.WriteLine(" - Enter id of the friend to remove");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer");
                return;
            }

            if (controllerFriend.DeleteEntity(id))
            {
                DisplaySuccessText("Delete operation sucessful");
            }
            else
            {
                DisplayErrorText("Delete operation failed. Element not found.");
            }
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
