using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    class Borrowing
    {
        private Magazine magazine;
        private Friend friend;
        private DateTime borrowingDate;
        private DateTime returnDate;

        public Borrowing(Magazine magazine, Friend friend, DateTime borrowingDate, DateTime returnDate)
        {
            this.magazine = magazine;
            this.friend = friend;
            this.borrowingDate = borrowingDate;     //must not be future
            this.returnDate = returnDate;       //must not be future
        }

        public Friend Friend { get => friend;}
        public DateTime BorrowingDate { get => borrowingDate;}
        public DateTime ReturnDate { get => returnDate;}
        internal Magazine Magazine { get => magazine;}
    }
}
