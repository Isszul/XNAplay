using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommsLib.Classes;
using CommsLib.Enums;
using System.Threading;
using Microsoft.Xna.Framework.Input;

namespace ObjectLib.Classes
{
    public class ControllListeningObject:BaseObject
    {

        public ControllListeningObject(MessageQueue messageQueue)
        {
            setMessageQueue(messageQueue);
            _acceptedMessageTypes.Add(EnumMessageType.CONTROLLER_MESSAGE);
        }

        public override void processMessage()
        {
            System.Console.Out.WriteLine(_lastMessage.getPayLoad().ToString());
            _lastMessage = null;
        }

    }
}
