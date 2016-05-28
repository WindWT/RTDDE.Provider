using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class TalkDialogHeaderMaster
    {
        public uint id;
        public ushort flag_no;
        public byte type;
        public uint param;
        public byte again;
        public string title;
        public string icon_00;
        public string icon_01;
        public string icon_02;
        public string icon_03;
        public string icon_04;
        public string icon_05;
    }
}
