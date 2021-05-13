using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    class StorageBox : Entity
    {
        private string color;
        private string tag;
        private int number;
        private Magazine[] mazines;

        public StorageBox(string color, string tag, int number, Magazine[] mazines)
        {
            this.color = color;
            this.tag = tag;
            this.number = number;
            this.mazines = mazines;
        }

        public string Color { get => color; }
        public string Tag { get => tag;}
        public int Number { get => number;}
        internal Magazine[] Mazines { get => mazines;}
    }
}
