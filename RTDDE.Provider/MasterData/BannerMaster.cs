using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class BannerMaster
    {
        public int id;
        public int bundle_id;
        public string url;
        public string texture_name;
        public string start_date;
        public string end_date;
    }
}
