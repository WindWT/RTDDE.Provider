using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class LevelDataMaster
    {
        [DALColumn(PrimaryKey = true)]
        public int level_data_id;
        public int format;
        public int start_x;
        public int start_y;
        public int width;
        public int height;
        public string map_data;
        public string hash;
        [DALColumn(Ignore = true)]
        public EnemyTableMaster enemy_table_master;
        [DALColumn(Ignore = true)]
        public UnitTalkMaster unit_talk_master;
        [DALColumn(Ignore = true)]
        public EventCutinMaster[] event_cutin_master;
        public uint clear_talk_id;
        [DALColumn(Ignore = true)]
        public LogicGroupData[] logic_group_data;
    }
}
