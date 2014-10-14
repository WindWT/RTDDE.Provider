﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class QuestCategoryMaster
    {
        public int id;
        public int kind;
        public int zbtn_kind;
        public int pt_num;
        public string icon;
        public string name;
        public string text;
        public int display_order;
        public string banner;
        public uint talk_dialog_id;
    }
}
