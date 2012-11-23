using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommsLib.Classes;
using CommsLib.Enums;
using Microsoft.Xna.Framework;
using System.Threading;

namespace ObjectLib.Classes
{
    public class SystemMessageListener : BaseObject
    {
        public SystemMessageListener(MessageQueue messageQueue)
        {
            setMessageQueue(messageQueue);
            _acceptedMessageTypes.Add(EnumMessageType.SYSTEM_MESSAGE);

        }

        public override void processMessage()
        {
            System.Console.Out.WriteLine(((GameTime)_lastMessage.getPayLoad()).TotalGameTime.ToString());
            _lastMessage = null;

        }
    }
}
