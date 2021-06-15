using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class StorageBoxController : Controller
    {
        public string CreateStorageBox(StorageBox box)
        {
            int position;
            string operationMessage;

            try
            {
                if (box.Id == 0)
                {
                    box.Id = GenerateId();
                    position = this.SelectVacantPosition();
                }
                else
                {
                    position = this.SelectPositionById(box.Id);
                }

                registeredEntities[position] = box;
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
