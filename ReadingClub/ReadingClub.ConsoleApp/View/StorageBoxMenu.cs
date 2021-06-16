using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;

namespace ReadingClub.ConsoleApp.View
{
    class StorageBoxMenu : MenuRegistrable<StorageBox>, IRegistrable
    {
        public StorageBoxMenu(StorageBoxController controllerStorageBox, ConsoleColor fontColor)
        {
            MenuTypeTitle = "storage box";
            mainController = controllerStorageBox;
            this.fontColor = fontColor;
        }

        public override void RegisterElement()
        {
            DisplayerHeader("REGISTER BOX");

            Console.WriteLine(" - Enter color of the new storage box");
            string color = Console.ReadLine();

            Console.WriteLine(" - Enter tag of the new storage box");
            string tag = Console.ReadLine();

            Console.WriteLine(" - Enter number of the new storage box.");
            string numberTxt = Console.ReadLine();

            if (!int.TryParse(numberTxt, out int number))
            {
                DisplayErrorText("Attribute id must a valid integer.");
                return;
            }
            StorageBox box = new StorageBox(0, color, tag, number);
            string response = mainController.CreateEntity(box);

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

            DisplayerHeader("MODIFY BOX");

            Console.WriteLine(" - Enter id of the new storage box.");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter color of the new storage box");
            string color = Console.ReadLine();

            Console.WriteLine(" - Enter tag of the new storage box");
            string tag = Console.ReadLine();

            Console.WriteLine(" - Enter number of the new storage box.");
            string numberTxt = Console.ReadLine();

            if (!int.TryParse(numberTxt, out int number))
            {
                DisplayErrorText("Attribute id must a valid integer.");
                return;
            }

            StorageBox box = new StorageBox(id, color, tag, number);
            string response = mainController.CreateEntity(box);

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
