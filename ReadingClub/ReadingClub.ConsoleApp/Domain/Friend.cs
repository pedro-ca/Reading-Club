using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    public class Friend
    {
        string name;
        string nameGuardian;
        string telephone;
        string address;

        public Friend(string name, string nameGuardian, string telephone, string address)
        {
            this.name = name;
            this.nameGuardian = nameGuardian;
            this.telephone = telephone;
            this.address = address;
        }
    }
}
