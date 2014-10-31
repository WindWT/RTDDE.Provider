using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class QuestFieldMaster
    {
        public uint id;
        public uint parent_world_id;
        public ushort flag_no;
        public string name;
        public string name_short;
        public string map_texture;
        public string icon_texture;
        public int icon_pos_x;
        public int icon_pos_y;
        public int icon_col_ofs_x;
        public int icon_col_ofs_y;
        public int icon_col_w;
        public int icon_col_h;
        public byte arrow_type;
        public int arrow_pos_x;
        public int arrow_pos_y;
        public int arrow_rotate;
        public byte arrow_reverse;
    }
}
