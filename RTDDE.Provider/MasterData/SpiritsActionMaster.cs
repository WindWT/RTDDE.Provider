using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsActionMaster
    {
        [DALColumn(PrimaryKey = true)]
        public uint action_id;
        public string action_name;
        public string anim;
        public uint use_nuts_id;
        public ushort use_nuts_num;
        public uint param_up_sec;
        public uint action_sec;
        public ushort energy_ps;
        public ushort intelli_ps;
        public ushort personality_ps;
        public ushort luck_ps;
        public ushort guts_ps;
        public ushort weight_ps;
        public ushort sleep_ps;
    }
}
