using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class BorrowingController : Controller
    {
        public string CreateBorrowing(Borrowing borrowing)
        {
            int position;
            string operationMessage;

            try
            {
                if (borrowing.Id == 0)
                {
                    borrowing.Id = GenerateId();
                    position = this.SelectVacantPosition();
                }
                else
                {
                    position = this.SelectPositionById(borrowing.Id);
                }

                
                registeredEntities[position] = borrowing;
                operationMessage = "OP_SUCCESS";
            }
            catch (Exception e)
            {
                operationMessage = "Error: " + e.Message;
            }

            return operationMessage;
        }
    }
}
