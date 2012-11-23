using CommsLib.Interfaces;
using CommsLib.Classes;
using CommsLib.Enums;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;

namespace ObjectLib.Classes
{
    public class BaseObject : iMessageable
    {
        protected MessageQueue _messageQueue;
        protected iMessage _lastMessage;
        private Thread _messageProcessor;
        protected List<EnumMessageType> _acceptedMessageTypes = new List<EnumMessageType>();

        public BaseObject()
        {
        }

        public BaseObject(MessageQueue messageQueue)
        {
            setMessageQueue(messageQueue);
        }


        public bool recieveMessage(iMessage message)
        {
            if (_lastMessage == null && _acceptedMessageTypes.Contains(message.getMessageType()))
            {
                _lastMessage = message;
                _messageProcessor = new Thread(new ThreadStart(processMessage));
                _messageProcessor.Start();
                return true;
            }

            return false;
        }

        public virtual void processMessage()
        {
             _lastMessage = null;
        }



        public void setMessageQueue(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
            _messageQueue.registerMessageHandler(recieveMessage);
        }
    }
}
