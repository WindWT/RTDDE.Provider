using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class SpiritsParamMaster
    {
        [DALColumn(PrimaryKey = true)]
        public ushort level;
        public ushort min;
        public ushort max;
        public string text;
    }
}
