using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class StorageBoxMenu : Menu, IRegistrable
    {
        StorageBoxController controllerStorageBox;

        public StorageBoxMenu(StorageBoxController controllerStorageBox, ConsoleColor fontColor)
        {
            this.controllerStorageBox = controllerStorageBox;
            this.fontColor = fontColor;
        }

        public override void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayerHeader("MANAGE BOXES");

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

            string response = controllerStorageBox.CreateStorageBox(0, color, tag, number);

            if (response != "OP_SUCcESS")
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
            object[] storageBoxes = controllerStorageBox.SelectAllEntities();
            DisplayerHeader("REGISTERED BOXES");
            foreach (StorageBox s in storageBoxes)
            {
                Console.WriteLine($"  - Storage Box {s.Id}: {s.Color}, {s.Tag}, {s.Number}");
            }
        }

        public void ModifyElement()
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

            string response = controllerStorageBox.CreateStorageBox(id, color, tag, number);

            if (response != "OP_SUCcESS")
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

            DisplayerHeader("REMOVE BOX");

            Console.WriteLine(" - Enter id of the box to remove");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer");
                return;
            }

            if (controllerStorageBox.DeleteEntity(id))
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
            Console.WriteLine(" - Enter 1 to insert a new Storage Box.");
            Console.WriteLine(" - Enter 2 to visualize existing Storage Boxes.");
            Console.WriteLine(" - Enter 3 to modify an existing Storage Box.");
            Console.WriteLine(" - Enter 4 to remove an existing Storage Box.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }
    }
}
