using CommsLib.Enums;
using CommsLib.Interfaces;


namespace CommsLib.Classes
{
    public class Message : iMessage
    {

        private EnumMessageType _enumMessageType;
        private object _payLoad;
        private object _origin;

        public Message(EnumMessageType enumMessageType, object payLoad, object origin)
        {
            _enumMessageType = enumMessageType;
            _payLoad = payLoad;
            _origin = origin;
        }

        public EnumMessageType getMessageType()
        {
            return _enumMessageType;
        }

        public object getPayLoad()
        {
            return _payLoad;
        }

        public object getOrigin()
        {
            return _origin;
        }


    }
}
