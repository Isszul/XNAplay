using CommsLib.Enums;

namespace CommsLib.Interfaces
{
    public interface iMessage
    {

        EnumMessageType getMessageType();
        object getPayLoad();
        object getOrigin();

    }
}
