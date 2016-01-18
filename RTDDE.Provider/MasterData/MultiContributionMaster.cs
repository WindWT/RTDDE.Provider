using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class MultiContributionMaster
    {
        public uint id;
        public int type;
        public uint param_0;
        public uint param_1;
        public uint param_2;
        public int point;
        public string text;
        public string cutin_text;
    }
}
