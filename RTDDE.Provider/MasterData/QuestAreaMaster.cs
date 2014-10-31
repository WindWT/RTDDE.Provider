using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class QuestAreaMaster
    {
        public uint id;
        public ushort flag_no;
        public uint parent_field_id;
        public string name;
        public string name_short;
        public string text;
        public string banner_texture;
        public string icon_texture;
        public int icon_pos_x;
        public int icon_pos_y;
        public int icon_col_ofs_x;
        public int icon_col_ofs_y;
        public int icon_col_w;
        public int icon_col_h;
        public uint connect_area_id;
        public string banner_bg_texture;
        public short display_order;
        public byte lock_type;
        public int lock_value;
        public string lock_dialog_msg;
        public uint move_field_id;
    }
}
