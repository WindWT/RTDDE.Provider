using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsCollectionMaster
    {
        [DALColumn(PrimaryKey = true)]
        public ushort g_id;
        public uint unit_id;
        public byte energy_lv;
        public byte intelli_lv;
        public byte personality_lv;
        public byte luck_lv;
        public byte guts_lv;
        public ushort weight;
        public ushort unit_r;
        public ushort unit_g;
        public ushort unit_b;
        public ushort event_0;
        public ushort event_1;
        public uint acce_id;
        public byte acce_r;
        public byte acce_g;
        public byte acce_b;
        public string story;
        public string memo;
    }
}
