using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class EnemyUnitMaster
    {
        public int id;
        public int flag;
        public string name;
        public string model;
        public string texture;
        public int icon;
        public int shadow;
        public int chara_kind;
        public int chara_symbol;
        public int chara_flag_no;
        public int type;
        public int attribute;
        public int up;
        public int soul_pt;
        public int gold_pt;
        public int up_life;
        public int up_attack;
        public int up_defense;
        public int life;
        public int attack;
        public int defense;
        public int turn;
        public short turn_wait_sec;
        public int ui;
        public short atk_ef_id;
        public uint logic_group_id;
        public int pat;
        public int p0;
        public int p1;
        public int pat_01;
        public int p0_01;
        public int p1_01;
    }
}
