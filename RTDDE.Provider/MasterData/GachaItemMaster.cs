using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class GachaItemMaster
    {
        public int id;
        public int type;
        public int count_type;
        public int price;
        public int begin_date;
        public int end_date;
        public int item_type;
        public string name;
        public string information;
        public string bg_color;
        public string dialog_caption;
    }
}
