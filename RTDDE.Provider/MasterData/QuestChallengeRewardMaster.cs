using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class QuestChallengeRewardMaster
    {
        public int id;
        public int category;
        public int point;
        public int present_type;
        public int present_param_0;
        public int present_param_1;
    }
}
