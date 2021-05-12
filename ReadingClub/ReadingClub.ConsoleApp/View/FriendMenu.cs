using ReadingClub.ConsoleApp.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    class FriendMenu : Menu, IRegistrable
    {
        FriendController controllerFriend;

        public string SelectOption()
        {
            Console.WriteLine(" - Enter 1 to insert a new Friend.");
            Console.WriteLine(" - Enter 2 to visualize existing Friends.");
            Console.WriteLine(" - Enter 3 to modify an existing Friend.");
            Console.WriteLine(" - Enter 4 to remove an existing Friend.");
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
