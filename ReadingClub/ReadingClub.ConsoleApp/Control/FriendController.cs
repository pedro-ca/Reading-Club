using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class FriendController : Controller
    {
        public string CreateFriend(int index, string name, string nameGuardian, string telephone, string address)
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

                Friend friend = new Friend(index, name, name, telephone, address);
                registeredEntities[position] = friend;
                operationMessage = "OP_SUCESS";
            }
            catch (Exception e)
            {
                operationMessage = "Error: " + e.Message;
            }

            return operationMessage;
        }
    }
}
