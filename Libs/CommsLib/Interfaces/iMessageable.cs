using CommsLib.Enums;
using CommsLib.Classes;
using System.Collections.Generic;

namespace CommsLib.Interfaces
{
    public interface iMessageable
    {
        bool recieveMessage(iMessage message);
        void setMessageQueue(MessageQueue messageQueue);
    }
}
