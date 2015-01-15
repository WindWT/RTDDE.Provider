using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class MapEventMaster
    {
        public uint id;
        public byte event_type;
        public uint parent_field_id;
        public string name;
        public string text;
        public string banner_bg_texture;
        public string icon_texture;
        public string icon;
        public byte icon_type;
        public int icon_pos_x;
        public int icon_pos_y;
        public byte open_type_01;
        public uint open_param_01;
        public byte open_type_02;
        public uint open_param_02;
        public byte open_type_03;
        public uint open_param_03;
        public byte open_type_04;
        public uint open_param_04;
        public uint open_timezone;
        public uint close_timezone;
        public string dialog_text;
        public string dialog_banner;
        public byte post_type;
        public uint post_param_01;
        public uint post_param_02;
        public uint post_message_id;
        public ushort max_count;
    }
}
