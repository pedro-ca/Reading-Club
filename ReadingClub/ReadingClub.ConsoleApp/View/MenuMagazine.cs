using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class MenuMagazine : MenuBase, IRegistrable
    {
        ControllerMagazine controllerMagazine;

        public string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to insert a new Magazine.");
            Console.WriteLine(" - Enter 2 to visualize existing Magazine.");
            Console.WriteLine(" - Enter 3 to modify an existing Magazine.");
            Console.WriteLine(" - Enter 4 to remove an existing Magazine.");
            Console.WriteLine(" - Enter S to exit;");

            string option = Console.ReadLine();

            return option;
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
    }
}
