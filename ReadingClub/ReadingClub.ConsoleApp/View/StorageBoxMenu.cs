using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class StorageBoxMenu : Menu, IRegistrable
    {
        StorageBoxController controllerStorageBox;

        public override void ShowMenu()
        {
            throw new NotImplementedException();
        }

        public void RegisterElement(int id)
        {
            throw new NotImplementedException();
        }

        public void ModifyElement()
        {
            throw new NotImplementedException();
        }

        public void VisualizeElement()
        {
            throw new NotImplementedException();
        }

        public void RemoveElement()
        {
            throw new NotImplementedException();
        }

        protected override string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to insert a new Storage Box.");
            Console.WriteLine(" - Enter 2 to visualize existing Storage Boxes.");
            Console.WriteLine(" - Enter 3 to modify an existing Storage Box.");
            Console.WriteLine(" - Enter 4 to remove an existing Storage Box.");
            Console.WriteLine(" - Enter S to exit;");

            string option = Console.ReadLine();

            return option;
        }
    }
}
