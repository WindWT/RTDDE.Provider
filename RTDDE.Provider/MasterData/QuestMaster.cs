using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    [DAL(UseProperty = true)]
    public class QuestMaster
    {
        public const int OPEN_CONDITIONS_MAX = 8;
        public int i;
        public string n;
        public string ns;
        public int d;
        public int c;
        public int pai;
        public uint pmei;
        public int m;
        public int s;
        public int so;
        public int k;
        public int z;
        public int p;
        public int kp;
        public int f;
        public int dio;
        public int df;
        public int el;
        public int ds;
        public int sp;
        public int od;
        public int cd;
        public int o1;
        public int op1;
        public int og1;
        public int o2;
        public int op2;
        public int og2;
        public int o3;
        public int op3;
        public int og3;
        public int o4;
        public int op4;
        public int og4;
        public int o5;
        public int op5;
        public int og5;
        public int o6;
        public int op6;
        public int og6;
        public int o7;
        public int op7;
        public int og7;
        public int o8;
        public int op8;
        public int og8;
        public int oi;
        public int op;
        public uint b;
        public uint be;
        public int bt;
        public int ps;
        public int pl;
        public int pa;
        public int pc;
        public int ph;
        public int psp;
        public int r;
        public int re;
        public int rs;
        public int rm;
        public int rl;
        public int ei;
        public string t;
        public int pt;
        public int pp;
        public int pp1;
        public int c0;
        public int c1;
        public int c2;
        public int t0;
        public int ti0;
        public int t1;
        public int ti1;
        public int si;
        public string ba;
        public int bf;
        public int bb;
        public int hi;
        public int hl;
        public int eci;
        public int eef;
        public int fc;
        public int gd0;
        public int ge0;
        public int gl0;
        public int gda0;
        public int gd1;
        public int ge1;
        public int gl1;
        public int gda1;
        public int gd2;
        public int ge2;
        public int gl2;
        public int gda2;
        public uint mq;
        public uint dr;

        public int id {
            get {
                return this.i;
            }
            set {
                this.i = value;
            }
        }

        public string name {
            get {
                return this.n;
            }
            set {
                this.n = value;
            }
        }

        public string name_sub {
            get {
                return this.ns;
            }
            set {
                this.ns = value;
            }
        }

        public int division {
            get {
                return this.d;
            }
            set {
                this.d = value;
            }
        }

        public int parent_area_id {
            get {
                return this.pai;
            }
            set {
                this.pai = value;
            }
        }

        public uint parent_map_event_id {
            get {
                return this.pmei;
            }
            set {
                this.pmei = value;
            }
        }

        public int map {
            get {
                return this.m;
            }
            set {
                this.m = value;
            }
        }

        public int stamina {
            get {
                return this.s;
            }
            set {
                this.s = value;
            }
        }

        public int soul {
            get {
                return this.so;
            }
            set {
                this.so = value;
            }
        }

        public int kind {
            get {
                return this.k;
            }
            set {
                this.k = value;
            }
        }

        public int zbtn_kind {
            get {
                return this.z;
            }
            set {
                this.z = value;
            }
        }

        public int pt_num {
            get {
                return this.p;
            }
            set {
                this.p = value;
            }
        }

        public int kpi_class {
            get {
                return this.kp;
            }
            set {
                this.kp = value;
            }
        }

        public int flag_no {
            get {
                return this.f;
            }
            set {
                this.f = value;
            }
        }

        public int display_order {
            get {
                return this.dio;
            }
            set {
                this.dio = value;
            }
        }

        public int difficulty {
            get {
                return this.df;
            }
            set {
                this.df = value;
            }
        }

        public int quest_difficulty {
            get {
                return this.el;
            }
            set {
                this.el = value;
            }
        }

        public int distance {
            get {
                return this.ds;
            }
            set {
                this.ds = value;
            }
        }

        public int sp_event_id {
            get {
                return this.sp;
            }
            set {
                this.sp = value;
            }
        }

        public int open_date {
            get {
                return this.od;
            }
            set {
                this.od = value;
            }
        }

        public int close_date {
            get {
                return this.cd;
            }
            set {
                this.cd = value;
            }
        }

        public int open_type_1 {
            get {
                return this.o1;
            }
            set {
                this.o1 = value;
            }
        }

        public int open_param_1 {
            get {
                return this.op1;
            }
            set {
                this.op1 = value;
            }
        }

        public int open_group_1 {
            get {
                return this.og1;
            }
            set {
                this.og1 = value;
            }
        }

        public int open_type_2 {
            get {
                return this.o2;
            }
            set {
                this.o2 = value;
            }
        }

        public int open_param_2 {
            get {
                return this.op2;
            }
            set {
                this.op2 = value;
            }
        }

        public int open_group_2 {
            get {
                return this.og2;
            }
            set {
                this.og2 = value;
            }
        }

        public int open_type_3 {
            get {
                return this.o3;
            }
            set {
                this.o3 = value;
            }
        }

        public int open_param_3 {
            get {
                return this.op3;
            }
            set {
                this.op3 = value;
            }
        }

        public int open_group_3 {
            get {
                return this.og3;
            }
            set {
                this.og3 = value;
            }
        }

        public int open_type_4 {
            get {
                return this.o4;
            }
            set {
                this.o4 = value;
            }
        }

        public int open_param_4 {
            get {
                return this.op4;
            }
            set {
                this.op4 = value;
            }
        }

        public int open_group_4 {
            get {
                return this.og4;
            }
            set {
                this.og4 = value;
            }
        }

        public int open_type_5 {
            get {
                return this.o5;
            }
            set {
                this.o5 = value;
            }
        }

        public int open_param_5 {
            get {
                return this.op5;
            }
            set {
                this.op5 = value;
            }
        }

        public int open_group_5 {
            get {
                return this.og5;
            }
            set {
                this.og5 = value;
            }
        }

        public int open_type_6 {
            get {
                return this.o6;
            }
            set {
                this.o6 = value;
            }
        }

        public int open_param_6 {
            get {
                return this.op6;
            }
            set {
                this.op6 = value;
            }
        }

        public int open_group_6 {
            get {
                return this.og6;
            }
            set {
                this.og6 = value;
            }
        }

        public int open_type_7 {
            get {
                return this.o7;
            }
            set {
                this.o7 = value;
            }
        }

        public int open_param_7 {
            get {
                return this.op7;
            }
            set {
                this.op7 = value;
            }
        }

        public int open_group_7 {
            get {
                return this.og7;
            }
            set {
                this.og7 = value;
            }
        }

        public int open_type_8 {
            get {
                return this.o8;
            }
            set {
                this.o8 = value;
            }
        }

        public int open_param_8 {
            get {
                return this.op8;
            }
            set {
                this.op8 = value;
            }
        }

        public int open_group_8 {
            get {
                return this.og8;
            }
            set {
                this.og8 = value;
            }
        }

        public int open_sp_event_id {
            get {
                return this.oi;
            }
            set {
                this.oi = value;
            }
        }

        public int open_sp_event_point {
            get {
                return this.op;
            }
            set {
                this.op = value;
            }
        }

        public uint bonus_start {
            get {
                return this.b;
            }
            set {
                this.b = value;
            }
        }

        public uint bonus_end {
            get {
                return this.be;
            }
            set {
                this.be = value;
            }
        }

        public int bonus_type {
            get {
                return this.bt;
            }
            set {
                this.bt = value;
            }
        }

        public int panel_sword {
            get {
                return this.ps;
            }
            set {
                this.ps = value;
            }
        }

        public int panel_lance {
            get {
                return this.pl;
            }
            set {
                this.pl = value;
            }
        }

        public int panel_archer {
            get {
                return this.pa;
            }
            set {
                this.pa = value;
            }
        }

        public int panel_cane {
            get {
                return this.pc;
            }
            set {
                this.pc = value;
            }
        }

        public int panel_heart {
            get {
                return this.ph;
            }
            set {
                this.ph = value;
            }
        }

        public int panel_sp {
            get {
                return this.psp;
            }
            set {
                this.psp = value;
            }
        }

        public int reward_money {
            get {
                return this.r;
            }
            set {
                this.r = value;
            }
        }

        public int reward_exp {
            get {
                return this.re;
            }
            set {
                this.re = value;
            }
        }

        public int reward_soul {
            get {
                return this.rs;
            }
            set {
                this.rs = value;
            }
        }

        public int reward_money_limit {
            get {
                return this.rm;
            }
            set {
                this.rm = value;
            }
        }

        public int reward_exp_limit {
            get {
                return this.rl;
            }
            set {
                this.rl = value;
            }
        }

        public int enemy_table_id {
            get {
                return this.ei;
            }
            set {
                this.ei = value;
            }
        }

        public string text {
            get {
                return this.t;
            }
            set {
                this.t = value;
            }
        }

        public int present_type {
            get {
                return this.pt;
            }
            set {
                this.pt = value;
            }
        }

        public int present_param {
            get {
                return this.pp;
            }
            set {
                this.pp = value;
            }
        }

        public int present_param_1 {
            get {
                return this.pp1;
            }
            set {
                this.pp1 = value;
            }
        }

        public int challenge_id_0 {
            get {
                return this.c0;
            }
            set {
                this.c0 = value;
            }
        }

        public int challenge_id_1 {
            get {
                return this.c1;
            }
            set {
                this.c1 = value;
            }
        }

        public int challenge_id_2 {
            get {
                return this.c2;
            }
            set {
                this.c2 = value;
            }
        }

        public int tflg_cmd_0 {
            get {
                return this.t0;
            }
            set {
                this.t0 = value;
            }
        }

        public int tflg_idx_0 {
            get {
                return this.ti0;
            }
            set {
                this.ti0 = value;
            }
        }

        public int tflg_cmd_1 {
            get {
                return this.t1;
            }
            set {
                this.t1 = value;
            }
        }

        public int tflg_idx_1 {
            get {
                return this.ti1;
            }
            set {
                this.ti1 = value;
            }
        }

        public int sp_guide_id {
            get {
                return this.si;
            }
            set {
                this.si = value;
            }
        }

        public string banner {
            get {
                return this.ba;
            }
            set {
                this.ba = value;
            }
        }

        public int bgm_f {
            get {
                return this.bf;
            }
            set {
                this.bf = value;
            }
        }

        public int bgm_b {
            get {
                return this.bb;
            }
            set {
                this.bb = value;
            }
        }

        public int h_id {
            get {
                return this.hi;
            }
            set {
                this.hi = value;
            }
        }

        public int h_lv {
            get {
                return this.hl;
            }
            set {
                this.hl = value;
            }
        }

        public int event_cutin_id {
            get {
                return this.eci;
            }
            set {
                this.eci = value;
            }
        }

        public int event_effect_flag {
            get {
                return this.eef;
            }
            set {
                this.eef = value;
            }
        }

        public int field_crash_id {
            get {
                return this.fc;
            }
            set {
                this.fc = value;
            }
        }

        public int gim_distance_0 {
            get {
                return this.gd0;
            }
            set {
                this.gd0 = value;
            }
        }

        public int gim_effect_0 {
            get {
                return this.ge0;
            }
            set {
                this.ge0 = value;
            }
        }

        public int gim_logig_0 {
            get {
                return this.gl0;
            }
            set {
                this.gl0 = value;
            }
        }

        public int gim_damage_0 {
            get {
                return this.gda0;
            }
            set {
                this.gda0 = value;
            }
        }

        public int gim_distance_1 {
            get {
                return this.gd1;
            }
            set {
                this.gd1 = value;
            }
        }

        public int gim_effect_1 {
            get {
                return this.ge1;
            }
            set {
                this.ge1 = value;
            }
        }

        public int gim_logig_1 {
            get {
                return this.gl1;
            }
            set {
                this.gl1 = value;
            }
        }

        public int gim_damage_1 {
            get {
                return this.gda1;
            }
            set {
                this.gda1 = value;
            }
        }

        public int gim_distance_2 {
            get {
                return this.gd2;
            }
            set {
                this.gd2 = value;
            }
        }

        public int gim_effect_2 {
            get {
                return this.ge2;
            }
            set {
                this.ge2 = value;
            }
        }

        public int gim_logig_2 {
            get {
                return this.gl2;
            }
            set {
                this.gl2 = value;
            }
        }

        public int gim_damage_2 {
            get {
                return this.gda2;
            }
            set {
                this.gda2 = value;
            }
        }

        public uint multi_quest_id
        {
            get
            {
                return this.mq;
            }
            set
            {
                this.mq = value;
            }
        }

        public uint damage_rate
        {
            get
            {
                return this.dr;
            }
            set
            {
                this.dr = value;
            }
        }

        public int GetOpenType(int type)
        {
            switch (type) {
                case 0: return this.open_type_1;
                case 1: return this.open_type_2;
                case 2: return this.open_type_3;
                case 3: return this.open_type_4;
                case 4: return this.open_type_5;
                case 5: return this.open_type_6;
                case 6: return this.open_type_7;
                case 7: return this.open_type_8;
                default: return 0;
            }
        }
        public int GetOpenParam(int param)
        {
            switch (param) {
                case 0: return this.open_param_1;
                case 1: return this.open_param_2;
                case 2: return this.open_param_3;
                case 3: return this.open_param_4;
                case 4: return this.open_param_5;
                case 5: return this.open_param_6;
                case 6: return this.open_param_7;
                case 7: return this.open_param_8;
                default: return 0;
            }
        }
        public int GetGroupParam(int group)
        {
            switch (group) {
                case 0: return this.open_group_1;
                case 1: return this.open_group_2;
                case 2: return this.open_group_3;
                case 3: return this.open_group_4;
                case 4: return this.open_group_5;
                case 5: return this.open_group_6;
                case 6: return this.open_group_7;
                case 7: return this.open_group_8;
                default: return 0;
            }
        }
    }
}
