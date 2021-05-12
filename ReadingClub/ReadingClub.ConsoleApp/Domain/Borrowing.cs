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
            if (!IsValidMagazine(magazine))
                throw new ArgumentException("Magazine property cannot be set instantiated as a null value.");
            if (!isValidFriend(friend))
                throw new ArgumentException("Friend property cannot be set instantiated as a null value.");
            if (!IsValidDateTime(borrowingDate))
                throw new ArgumentException("BorrowingDate property cannot be set as a date from the future.");
            if (!IsValidDateTime(returnDate))
                throw new ArgumentException("ReturnDate property cannot be set as a date from the future.");

            this.magazine = magazine;
            this.friend = friend;
            this.borrowingDate = borrowingDate;
            this.returnDate = returnDate;
        }

        public Magazine Magazine { get => magazine; }
        public Friend Friend { get => friend;}
        public DateTime BorrowingDate { get => borrowingDate;}
        public DateTime ReturnDate { get => returnDate;}

        private bool isValidFriend(Friend friend)
        {
            return friend != null;
        }

        private bool IsValidMagazine(Magazine magazine)
        {
            return magazine != null;
        }
        private bool IsValidDateTime(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
