using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class MagazineController : Controller
    {
        public string CreateMagazine(int index, string magazineCollection, int editionNumber, DateTime releaseYear, StorageBox boxStored)
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

                Magazine magazine = new Magazine(index, magazineCollection, editionNumber, releaseYear, boxStored);
                registeredEntities[position] = magazine;
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
