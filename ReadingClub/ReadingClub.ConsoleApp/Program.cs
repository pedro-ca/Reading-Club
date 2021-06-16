using ReadingClub.ConsoleApp.View;
using System;

namespace ReadingClub.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu(ConsoleColor.Cyan);
            menu.ShowMenu();
        }
    }
}
