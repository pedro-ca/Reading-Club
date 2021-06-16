using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;

namespace ReadingClub.ConsoleApp.View
{
    class FriendMenu : MenuRegistrable<Friend>, IRegistrable
    {
        public FriendMenu(FriendController controllerFriend, ConsoleColor fontColor)
        {
            MenuTypeTitle = "friend";
            mainController = controllerFriend;
            this.fontColor = fontColor;
        }

        public override void RegisterElement()
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
            string response = mainController.CreateEntity(friend);

            if (response != "OP_SUCCESS")
                DisplayErrorText(response);
            else
            {
                DisplaySuccessText("Register Operation Sucessful");
                Console.ReadLine();
                return;

            }
        }

        public override void ModifyElement()
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
            string response = mainController.CreateEntity(friend);

            if (response != "OP_SUCCESS")
                DisplayErrorText(response);
            else
            {
                DisplaySuccessText("Modify Operation Sucessful");
                Console.ReadLine();
                return;
            }
        }
    }
}
