using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsPositionMaster
    {
        public uint id;
        public byte type;
        public uint pos_x;
        public uint pos_y;
    }
}
