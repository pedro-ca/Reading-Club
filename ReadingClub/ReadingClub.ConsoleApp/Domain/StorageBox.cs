using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    class StorageBox
    {
        string color;
        string tag;
        int number;
        Magazine[] mazines;

        public StorageBox(string color, string tag, int number, Magazine[] mazines)
        {
            this.color = color;
            this.tag = tag;
            this.number = number;
            this.mazines = mazines;
        }
    }
}
