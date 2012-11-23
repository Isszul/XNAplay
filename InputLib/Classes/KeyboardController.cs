using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ObjectLib.Classes;
using CommsLib.Classes;
using CommsLib.Enums;
using System.Threading;
using InputLib.Enums;

namespace InputLib.Classes
{
    public class KeyboardController
    {

        private MessageQueue _messageQueue;

        public KeyboardController(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }


        public void processKeyState(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
            {
                _messageQueue.addMessage(new Message(EnumMessageType.CONTROLLER_MESSAGE, EnumDirection.UP, this));
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                _messageQueue.addMessage(new Message(EnumMessageType.CONTROLLER_MESSAGE, EnumDirection.DOWN, this));
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                _messageQueue.addMessage(new Message(EnumMessageType.CONTROLLER_MESSAGE, EnumDirection.LEFT, this));
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                _messageQueue.addMessage(new Message(EnumMessageType.CONTROLLER_MESSAGE, EnumDirection.RIGHT, this));
            }
        }



    }
}
