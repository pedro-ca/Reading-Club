using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class StorageBoxController : Controller
    {
        public string CreateStorageBox(int index, string color, string tag, int number)
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

                StorageBox box = new StorageBox(index, color, tag, number);
                registeredEntities[position] = box;
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
