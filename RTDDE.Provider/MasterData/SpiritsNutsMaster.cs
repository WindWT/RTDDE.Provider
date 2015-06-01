using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsNutsMaster
    {
        [DALColumn(PrimaryKey = true)]
        public uint nuts_id;
        public string resource_name;
        public string name;
        public byte nuts_r;
        public byte nuts_g;
        public byte nuts_b;
    }
}
