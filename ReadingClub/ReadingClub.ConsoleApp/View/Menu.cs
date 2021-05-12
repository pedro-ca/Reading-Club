using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    abstract class Menu
    {
        protected ConsoleColor fontColor;
        protected string screenType;

        protected void DisplayerHeader(string text)
        {
            Console.Clear();
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
