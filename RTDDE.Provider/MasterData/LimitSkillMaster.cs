using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class LimitSkillMaster
    {
        public int id;
        public string name;
        public string general_text;
        public int skill_id_00;
        public int limit_pt_00;
        public string text_00;
        public int skill_id_01;
        public int limit_pt_01;
        public string text_01;
        public int skill_id_02;
        public int limit_pt_02;
        public string text_02;
        public int coefficient;
    }
}
