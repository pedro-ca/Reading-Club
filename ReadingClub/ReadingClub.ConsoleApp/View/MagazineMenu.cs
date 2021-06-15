using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class MagazineMenu : Menu, IRegistrable
    {
        MagazineController controllerMagazine;
        StorageBoxController controllerStorageBox;

        public MagazineMenu(MagazineController controllerMagazine, StorageBoxController controllerStorageBox, ConsoleColor fontColor)
        {
            this.controllerMagazine = controllerMagazine;
            this.controllerStorageBox = controllerStorageBox;
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
            DisplayerHeader("REGISTER MAGAZINE");

            Console.WriteLine(" - Enter collection of the new magazine");
            string magazineCollection = Console.ReadLine();

            Console.WriteLine(" - Enter edition number of the new magazine");
            string editionNumberTxt = Console.ReadLine();

            if (!int.TryParse(editionNumberTxt, out int editionNumber))
            {
                DisplayErrorText("Attribute edition number must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter release year of the new magazine ");
            string releaseYearTxt = Console.ReadLine();

            if (!DateTime.TryParse(releaseYearTxt, out DateTime releaseYear))
            {
                DisplayErrorText("Attribute release year of the storage box must a valid date.");
                return;
            }

            Console.WriteLine(" - Enter id of the storage box of the new magazine ");
            string storageboxIdTxt = Console.ReadLine();

            if (!int.TryParse(storageboxIdTxt, out int storageboxId))
            {
                DisplayErrorText("Attribute id of the storage box must a valid integer.");
                return;
            }

            StorageBox storageBox = (StorageBox)controllerStorageBox.SelectEntityById(storageboxId);

            Magazine magazine = new Magazine(0, magazineCollection, editionNumber, releaseYear, storageBox);
            string response = controllerMagazine.CreateMagazine(magazine);

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
            object[] magazines = controllerMagazine.SelectAllEntities();
            DisplayerHeader("REGISTERED MAGAZINES");
            foreach (Magazine m in magazines)
            {
                Console.WriteLine($"  - Magazine {m.Id}: {m.MagazineCollection}, {m.EditionNumber}, {m.ReleaseYear}. {m.BoxStored.Tag}");
            }
        }

        public void ModifyElement()
        {
            VisualizeAllElements();

            DisplayerHeader("MODIFY MAGAZINE");

            Console.WriteLine(" - Enter id of the magazine to Modify ");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter collection of the magazine to Modify");
            string magazineCollection = Console.ReadLine();

            Console.WriteLine(" - Enter edition number of the magazine to Modify");
            string editionNumberTxt = Console.ReadLine();

            if (!int.TryParse(editionNumberTxt, out int editionNumber))
            {
                DisplayErrorText("Attribute edition number must a valid integer.");
                return;
            }

            Console.WriteLine(" - Enter release date of the magazine to Modify");
            string releaseYearTxt = Console.ReadLine();

            if (!DateTime.TryParse(releaseYearTxt, out DateTime releaseYear))
            {
                DisplayErrorText("Attribute id of the storage box must a valid DateTime.");
                return;
            }

            Console.WriteLine(" - Enter id of the storage box of the magazine to Modify");
            string storageboxIdTxt = Console.ReadLine();

            if (!int.TryParse(storageboxIdTxt, out int storageboxId))
            {
                DisplayErrorText("Attribute id of the storage box must a valid integer.");
                return;
            }

            StorageBox storageBox = (StorageBox)controllerStorageBox.SelectEntityById(storageboxId);

            Magazine magazine = new Magazine(id, magazineCollection, editionNumber, releaseYear, storageBox);
            string response = controllerMagazine.CreateMagazine(magazine);

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

            DisplayerHeader("REMOVE BOX");

            Console.WriteLine(" - Enter id of the box to remove");
            string idTxt = Console.ReadLine();

            if (!int.TryParse(idTxt, out int id))
            {
                DisplayErrorText("Attribute id must a valid integer");
                return;
            }

            if (controllerMagazine.DeleteEntity(id))
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
            Console.WriteLine(" - Enter 1 to insert a new Magazine.");
            Console.WriteLine(" - Enter 2 to visualize existing Magazine.");
            Console.WriteLine(" - Enter 3 to modify an existing Magazine.");
            Console.WriteLine(" - Enter 4 to remove an existing Magazine.");
            Console.WriteLine(" - Enter Q to quit.");

            string option = Console.ReadLine();

            return option;
        }
    }
}
