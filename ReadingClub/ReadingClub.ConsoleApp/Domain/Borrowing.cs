using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    class Borrowing
    {
        Magazine magazine;
        Friend friend;
        DateTime borrowingDate;
        DateTime returnDate;

        public Borrowing(Magazine magazine, Friend friend, DateTime borrowingDate, DateTime returnDate)
        {
            this.magazine = magazine;
            this.friend = friend;
            this.borrowingDate = borrowingDate;
            this.returnDate = returnDate;
        }
    }
}
