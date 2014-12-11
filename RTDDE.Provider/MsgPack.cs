using MsgPack;
using MsgPack.Serialization;
using System.IO;

namespace RTDDE.Provider
{
    public static class MsgBytes
    {
        public static string ToJson(Stream msgPackStream)
        {
            var msg = MessagePackSerializer.Get<MessagePackObject>();
            return msg.Unpack(msgPackStream).ToString();
        }
    }
}
