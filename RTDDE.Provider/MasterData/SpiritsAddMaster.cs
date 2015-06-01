using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsAddMaster
    {
        public uint id;
        public uint nuts_id_0;
        public ushort num_0;
        public uint nuts_id_1;
        public ushort num_1;
        public uint nuts_id_2;
        public ushort num_2;
        public uint nuts_id_3;
        public ushort num_3;
        public ushort energy;
        public ushort add_energy;
        public ushort intelli;
        public ushort add_intelli;
        public ushort personality;
        public ushort add_personality;
        public ushort luck;
        public ushort add_luck;
        public ushort guts;
        public ushort add_guts;
        public ushort weight;
        public ushort add_weight;
        public ushort sleep;
        public ulong life_time;
        public ulong add_life_time;
    }
}
