using RTDDE.Provider.MasterData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using MsgPack;
using MsgPack.Serialization;

namespace RTDDE.Provider
{
    public static class MsgBytes
    {
        public static string ToJson(Stream MsgPackStream)
        {
            var msg = MessagePackSerializer.Get<MessagePackObject>();
            return msg.Unpack(MsgPackStream).ToString();
        }
    }
}
