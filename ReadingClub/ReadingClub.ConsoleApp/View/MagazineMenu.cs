using ReadingClub.ConsoleApp.Control;
using ReadingClub.ConsoleApp.Domain;
using System;

namespace ReadingClub.ConsoleApp.View
{
    class MagazineMenu : MenuRegistrable<Magazine>, IRegistrable
    {
        StorageBoxController controllerStorageBox;

        public MagazineMenu(MagazineController controllerMagazine, StorageBoxController controllerStorageBox, ConsoleColor fontColor)
        {
            MenuTypeTitle = "magazine";
            mainController = controllerMagazine;
            this.controllerStorageBox = controllerStorageBox;
            this.fontColor = fontColor;
        }

        public override void RegisterElement()
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
            string response = mainController.CreateEntity(magazine);

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
            string response = mainController.CreateEntity(magazine);

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
