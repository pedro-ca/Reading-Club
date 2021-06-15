using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class FriendMenu : Menu, IRegistrable
    {
        FriendController controllerFriend;

        public FriendMenu(FriendController controllerFriend, ConsoleColor fontColor)
        {
            this.controllerFriend = controllerFriend;
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
                        break;
                }
                Console.ReadLine();
            }
        }

        public void RegisterElement()
        {
            DisplayerHeader("REGISTER FRIEND");

            Console.WriteLine(" - Enter name of the new friend.");
            string name = Console.ReadLine();

            Console.WriteLine(" - Enter name of the legal guardian of the new friend.");
            string nameGuardian = Console.ReadLine();

            Console.WriteLine(" - Enter telephone of the new friend.");
            string telephone = Console.ReadLine();

            Console.WriteLine(" - Enter address of the new friend.");
            string address = Console.ReadLine();

            Friend friend = new Friend(0, name, nameGuardian, telephone, address);
            string response = controllerFriend.CreateEntity(friend);

            if (response != "OP_SUCCESS")
                DisplayErrorText(response);
            else
            {
                DisplaySuccessText("Register Operation Sucessful");
                Console.ReadLine();
                return;

            }
        }

        public void VisualizeAllElements()
        {
            object[] friends = controllerFriend.SelectAllEntities();
            DisplayerHeader("REGISTERED FRIEDS");
            foreach (Friend f in friends)
            {
                Console.WriteLine($"  - Friend {f.Id}: {f.Name}, {f.NameGuardian}, {f.Telephone}, {f.Address}");
            }
        }

        public void ModifyElement()
        {
            VisualizeAllElements();

            DisplayerHeader("MODIFY FRIEND");

            Console.WriteLine(" - Enter id of the friend to Modify.");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter name of the existing friend.");
            string name = Console.ReadLine();

            Console.WriteLine(" - Enter name of the legal guardian of the existing friend.");
            string nameGuardian = Console.ReadLine();

            Console.WriteLine(" - Enter telephone of the existing friend.");
            string telephone = Console.ReadLine();

            Console.WriteLine(" - Enter address of the existing friend.");
            string address = Console.ReadLine();

            Friend friend = new Friend(id, name, nameGuardian, telephone, address);
            string response = controllerFriend.CreateEntity(friend);

            if (response != "OP_SUCCESS")
                DisplayErrorText(response);
            else
            {
                DisplaySuccessText("Modify Operation Sucessful");
                Console.ReadLine();
                return;
            }
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
                return;
            }
            else
            {
                DisplayErrorText("Delete operation failed. Element not found.");
                Console.ReadLine();
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
