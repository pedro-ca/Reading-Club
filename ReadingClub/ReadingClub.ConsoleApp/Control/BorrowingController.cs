using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class BorrowingController : Controller
    {
        public string CreateBorrowing(int index, Magazine magazine, Friend friend, DateTime borrowingDate)
        {
            int position;
            string operationMessage;

            try
            {
                if (index == 0)
                {
                    index = GenerateId();
                    position = this.SelectVacantPosition();
                }
                else
                {
                    position = this.SelectPositionById(index);
                }

                Borrowing borrowing = new Borrowing(index, magazine, friend, borrowingDate);
                registeredEntities[position] = borrowing;
                operationMessage = "OP_SUCcESS";
            }
            catch (Exception e)
            {
                operationMessage = "Error: " + e.Message;
            }

            return operationMessage;
        }
    }
}
