using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    public abstract class Entity
    {
        protected int id;

        public int Id { get => id;}
    }
}
