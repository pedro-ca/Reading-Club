using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    abstract class Menu
    {
        protected ConsoleColor fontColor;

        public abstract void ShowMenu();
        protected abstract string SelectOption();

        protected void DisplayerHeader(string text)
        {
            Console.ForegroundColor = fontColor;
            Console.WriteLine($"=-=-=-=-=-=- {text} -=-=-=-=-=-=");
        }

        protected void DisplayErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"!!! {text} !!!");
            Console.ForegroundColor = fontColor;
        }
    }
}
