using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommsLib.Classes;
using CommsLib.Enums;
using InputLib.Enums;
using Microsoft.Xna.Framework.Input;

namespace InputLib.Classes
{
    class GamePadController
    {
        
        private MessageQueue _messageQueue;

        public GamePadController(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public void processKeyState(GamePadState gamePadState)
        {
            
        }


    }
}
