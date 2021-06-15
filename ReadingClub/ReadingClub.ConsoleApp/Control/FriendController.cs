using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class FriendController : Controller
    {
        public string CreateFriend(Friend friend)
        {
            int position;
            string operationMessage;

            try
            {
                if (friend.Id == 0)
                {
                    friend.Id = GenerateId();
                    position = this.SelectVacantPosition();
                }
                else
                {
                    position = this.SelectPositionById(friend.Id);
                }

                
                registeredEntities[position] = friend;
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
