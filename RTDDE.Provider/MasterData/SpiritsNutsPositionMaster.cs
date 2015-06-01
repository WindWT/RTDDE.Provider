using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsNutsPositionMaster
    {
        public uint id;
        public ushort level;
        public uint pos_x;
        public uint pos_y;
    }
}
