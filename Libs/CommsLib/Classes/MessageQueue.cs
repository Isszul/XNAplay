using CommsLib.Enums;
using CommsLib.Interfaces;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;


namespace CommsLib.Classes
{
    public class MessageQueue : iMessageQueue
    {
        public delegate bool ProcessMessageHandler(iMessage message);
        private List<ProcessMessageHandler> _processMessageHandlers;
        private List<iMessage> _messageList = new List<iMessage>();
        private bool _running;
        private Thread _messageQueueThread;

        public const long MAX_MESSAGES_PER_ORIGIN = 1L;

        public MessageQueue()
        {
            _running = true;
            _processMessageHandlers = new List<ProcessMessageHandler>();
            _messageQueueThread = new Thread(new ThreadStart(processQueue));
            _messageQueueThread.Start();
        }

        ~MessageQueue()
        {
            _running = false;
        }

        public void addMessage(iMessage newMessage)
        {
            lock (_messageList)
            {
                long messageCount = 0L;
                foreach (iMessage message in _messageList)
                {
                    if(message.getOrigin().Equals(newMessage.getOrigin()))
                    {
                        messageCount++;
                    }
                }
                if (messageCount < MAX_MESSAGES_PER_ORIGIN)
                {
                    _messageList.Add(newMessage);
                }
            }
        }


        public void registerMessageHandler(ProcessMessageHandler processMessageHandler)
        {
            lock (_processMessageHandlers)
            {
                _processMessageHandlers.Add(processMessageHandler);
            }
        }

        public void processQueue()
        {
            while (_running)
            {
                List<iMessage> recievedMessages = new List<iMessage>();
                lock (_messageList)
                {
                    lock (_processMessageHandlers)
                    {
                        foreach (iMessage message in _messageList)
                        {
                            foreach (ProcessMessageHandler processMessageHandler in _processMessageHandlers)
                            {
                                if (processMessageHandler(message))
                                {
                                    recievedMessages.Add(message);
                                }
                            }
                        }

                        foreach (iMessage message in recievedMessages)
                        {
                            _messageList.Remove(message);
                        }

                        recievedMessages.Clear();
                    }
                }
                Thread.Sleep(0);
            }
        }
    }
}
