using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsTreeMaster
    {
        [DALColumn(PrimaryKey = true)]
        public ushort level;
        public uint unit_id_0;
        public uint unit_id_1;
        public uint unit_id_2;
        public uint unit_id_3;
        public uint unit_id_4;
        public uint unit_id_5;
        public uint unit_id_6;
        public uint unit_id_7;
        public uint unit_id_8;
        public uint unit_id_9;
        public string name;
        public ushort create_nuts_num;
        public ushort spirits_num;
        public uint create_nuts_sec;
    }
}
