using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class MagazineController : Controller
    {
        public string CreateMagazine(Magazine magazine)
        {
            int position;
            string operationMessage;

            try
            {
                if (magazine.Id == 0)
                {
                    magazine.Id = GenerateId();
                    position = this.SelectVacantPosition();
                }
                else
                {
                    position = this.SelectPositionById(magazine.Id);
                }

                registeredEntities[position] = magazine;
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
