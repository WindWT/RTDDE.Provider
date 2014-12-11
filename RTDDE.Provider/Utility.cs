using RTDDE.Provider.Enums;
using RTDDE.Provider.MasterData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace RTDDE.Provider
{
    public struct EnemyEffectAssign
    {
        public short m_EffectIndex;
        public string m_MainAtkEffectName;
        public string m_SubAtkEffectName;
        public EnemyEffectAssign(short id, string mainName, string subName)
        {
            this.m_EffectIndex = id;
            this.m_MainAtkEffectName = mainName;
            this.m_SubAtkEffectName = subName;
        }
    }
    public class OpenType
    {
        public string Type { get; set; }
        public string Param { get; set; }
        public int Group { get; set; }
        public OpenType()
        {
            Type = "未知";
            Param = string.Empty;
        }
        public OpenType(string type, string param, int group)
        {
            Type = type;
            Param = param;
            Group = group;
        }
    }
    public class Utility
    {
        public static bool UseLocalTime { get; set; }
        public static OpenType ParseOpentype(string type, string param, int group)
        {
            OpenType result = new OpenType();
            result.Group = group;
            switch (type)
            {
                case "0":
                    {
                        result.Type = string.Empty;
                        result.Param = string.Empty;
                        break;
                    }
                case "1":
                    {
                        result.Type = "每周";
                        switch (param)
                        {
                            case "0": result.Param = "日"; break;
                            case "1": result.Param = "一"; break;
                            case "2": result.Param = "二"; break;
                            case "3": result.Param = "三"; break;
                            case "4": result.Param = "四"; break;
                            case "5": result.Param = "五"; break;
                            case "6": result.Param = "六"; break;
                            case "7": result.Param = "日一二三四五六"; break;
                            default: break;
                        }
                        break;
                    }
                case "2":
                    {
                        result.Type = "完成关卡";
                        string sql = @"SELECT name FROM quest_master WHERE id={0}";
                        result.Param = param + "|" + DAL.Get<string>(String.Format(sql, param));
                        break;
                    }
                case "3":   //not used
                    {
                        result.Type += "3";
                        result.Param += param;
                        break;
                    }
                case "4":
                    {
                        result.Type = "开始日期";
                        result.Param = ParseRTDDate(param);
                        break;
                    }
                case "5":
                    {
                        result.Type = "结束日期";
                        result.Param = ParseRTDDate(param);
                        break;
                    }
                case "6":
                    {
                        result.Type = "是否关闭";
                        result.Param = param;
                        break;
                    }
                case "7":
                    {
                        result.Type = "完成关卡";
                        string sql = @"SELECT name FROM quest_master WHERE id={0}";
                        result.Param = param + "|" + DAL.Get<string>(String.Format(sql, param));
                        break;
                    }
                case "8":
                    {
                        result.Type = "支线任务";
                        result.Param = param;
                        break;
                    }
                case "9":
                    {
                        result.Type = "不完成关卡";
                        string sql = @"SELECT name FROM quest_master WHERE id={0}";
                        result.Param = param + "|" + DAL.Get<string>(String.Format(sql, param));
                        break;
                    }
                case "10":
                    {
                        result.Type = "自身等级大于等于";
                        result.Param = param;
                        break;
                    }
                case "11":
                    {
                        result.Type = "自身等级小于等于";
                        result.Param = param;
                        break;
                    }
                case "12":
                    {
                        result.Type = "教程通过";
                        result.Param = param;
                        break;
                    }
                case "13":
                    {
                        result.Type = "教程未通过";
                        result.Param = param;
                        break;
                    }
                case "14":
                    {
                        result.Type = "队长限定";
                        //result.OpentypeParam = opentypeParam + "|" + ParseUnitName(opentypeParam);
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("角色组|" + param);
                        sb.Append(ParseUnitGroupName(param));
                        result.Param = sb.ToString();
                        break;
                    }
                default:
                    {
                        result.Type += type;
                        result.Param += param;
                        break;
                    }
            }
            return result;
        }
        public static string ParsePresenttype(string presenttype)
        {
            switch (presenttype)
            {
                case "0": return "无";
                case "1": return "COIN";
                case "2": return "FP";
                case "3": return "STONE";
                case "4": return "UNIT";
                default: return "未知" + presenttype.ToString();
            }
        }
        public static string ParseBonustype(string bonustype)
        {
            switch (bonustype)
            {
                case "0":
                    {
                        return "无";
                    }
                case "1":
                    {
                        return "体力半减";
                    }
                case "2":
                    {
                        return "双倍钱";
                    }
                case "3":
                    {
                        return "双倍经验";
                    }
                case "4":
                    {
                        return "双倍魂?";
                    }
                case "5":
                    {
                        return "双倍掉落";
                    }
                default: return "未知" + bonustype.ToString();
            }
        }
        public static string ParseAttributetype(int attributetype)
        {
            return attributetype <= 5 ? ParseRealAttributetype(attributetype).ToString() : attributetype.ToString();
        }

        private static UnitAttribute ParseRealAttributetype(int attributetype)
        {
            switch (attributetype)
            {
                case 1:
                    return UnitAttribute.NONE;
                case 2:
                    return UnitAttribute.FIRE;
                case 3:
                    return UnitAttribute.WATER;
                case 4:
                    return UnitAttribute.LIGHT;
                case 5:
                    return UnitAttribute.DARK;
                default:
                    return UnitAttribute.NONE;
            }
        }
        public static string ParseStyletype(int styletype)
        {
            return styletype == 0 ? "NONE" : ParseRealStyletype(styletype).ToString();
        }

        private static Class ParseRealStyletype(int styletype)
        {
            switch (styletype)
            {
                case 1:
                    return Class.KNIGHT;
                case 2:
                    return Class.LANCER;
                case 3:
                    return Class.ARCHER;
                case 4:
                    return Class.WIZARD;
                default:
                    return Class.KNIGHT;
            }
        }
        #region AssignID

        public static readonly EnemyEffectAssign[] m_EffectList = new EnemyEffectAssign[]	{
		new EnemyEffectAssign(1, "ef_atk_blade_01", null),
		new EnemyEffectAssign(2, "ef_atk_blade_02", null),
		new EnemyEffectAssign(101, "ef_atk_spear_01", null),
		new EnemyEffectAssign(102, "ef_atk_spear_02", null),
		new EnemyEffectAssign(201, "ef_atk_arrow_01", null),
		new EnemyEffectAssign(202, "ef_atk_arrow_02", null),
		new EnemyEffectAssign(301, "ef_atk_magic_01", null),
		new EnemyEffectAssign(302, "ef_atk_magic_03", null),
		new EnemyEffectAssign(303, "ef_atk_magic_04", null),
		new EnemyEffectAssign(3, "ef_atk_blade_03", null),
		new EnemyEffectAssign(103, "ef_atk_spear_03", null),
		new EnemyEffectAssign(203, "ef_atk_arrow_03", null),
		new EnemyEffectAssign(4, "ef_atk_blade_01", null),
		new EnemyEffectAssign(204, "ef_atk_arrow_02", null),
		new EnemyEffectAssign(104, "ef_atk_spear_02", null),
		new EnemyEffectAssign(304, "ef_atk_magic_03", null),
		new EnemyEffectAssign(205, "ef_atk_arrow_01", null),
		new EnemyEffectAssign(105, "ef_atk_spear_04", null),
		new EnemyEffectAssign(106, "ef_atk_spear_05", null),
		new EnemyEffectAssign(305, "ef_atk_magic_01", null),
		new EnemyEffectAssign(107, "ef_atk_spear_06", null),
		new EnemyEffectAssign(5, "ef_atk_blade_04", null),
		new EnemyEffectAssign(6, "ef_atk_blade_02", null),
		new EnemyEffectAssign(206, "ef_atk_arrow_04", null),
		new EnemyEffectAssign(7, "ef_atk_blade_02", null),
		new EnemyEffectAssign(306, "ef_atk_magic_03", null),
		new EnemyEffectAssign(8, "ef_atk_blade_05", null),
		new EnemyEffectAssign(207, "ef_atk_arrow_03", null),
		new EnemyEffectAssign(108, "ef_atk_spear_06", null),
		new EnemyEffectAssign(9, "ef_atk_blade_06", null),
		new EnemyEffectAssign(109, "ef_atk_spear_07", null),
		new EnemyEffectAssign(208, "ef_atk_arrow_06", null),
		new EnemyEffectAssign(307, "ef_atk_magic_05", null),
		new EnemyEffectAssign(209, "ef_atk_arrow_05", null),
		new EnemyEffectAssign(308, "ef_atk_magic_04", null),
		new EnemyEffectAssign(309, "ef_atk_magic_03", null),
		new EnemyEffectAssign(210, "ef_atk_arrow_06", null),
		new EnemyEffectAssign(310, "ef_atk_magic_03", null),
		new EnemyEffectAssign(10, "ef_atk_blade_07", null),
		new EnemyEffectAssign(110, "ef_atk_spear_08", null),
		new EnemyEffectAssign(11, "ef_atk_blade_08", null),
		new EnemyEffectAssign(211, "ef_atk_arrow_07", null),
		new EnemyEffectAssign(212, "ef_atk_arrow_05", null),
		new EnemyEffectAssign(12, "ef_atk_blade_09", null),
		new EnemyEffectAssign(311, "ef_atk_magic_03", null),
		new EnemyEffectAssign(312, "ef_atk_magic_03", null)
	};
        #endregion
        public static AssignID ParseUnitKind(int kind)
        {
            AssignID assignId = AssignID.SWORD;
            int length = m_EffectList.Length;
            for (int index = 0; index < length; ++index)
            {
                EnemyEffectAssign enemyEffectAssign = m_EffectList[index];
                if (kind == (int)enemyEffectAssign.m_EffectIndex)
                    assignId = (AssignID)index;
            }
            return assignId;
        }
        public static int ParseAssignID(AssignID category)
        {
            int num = 1;
            int index = (int)category;
            int length = m_EffectList.Length;
            if (index >= 0 && index < length)
                num = (int)m_EffectList[index].m_EffectIndex;
            return num;
        }
        public static string ParseQuestKind(int kind)
        {
            switch (kind)
            {
                case 0: return "NORMAL";
                case 1000: return "EVENT";
                case 1010: return "RUINS";
                case 1011: return "CAVE";
                case 1020: return "SP_EVENT";
                default: return "UNKNOWN_" + kind.ToString();
            }
        }
        [Obsolete]
        public static string ParseZBTNKind(int kind)
        {
            switch (kind)
            {
                case 0: return "NORMAL";
                case 1: return "EVENT";
                case 2: return "LARGE_EVENT";
                case 3: return "SPECIAL";
                default: return "UNKNOWN_" + kind.ToString();
            }
        }
        public static string ParseSkillType<T>(T skillType)
        {
            return skillType.ToString();
        }
        public static string ParseAccessoryType(int type)
        {
            return ((AccessoryType)type).ToString();
        }
        public static string ParseEnemyType(int type)
        {
            return ((ENEMY_TYPE)type).ToString();
        }
        public static string ParseAttackPattern(int type)
        {
            return ((AttackPattern)type).ToString();
        }
        public static string ParseMessageName(int type)
        {
            return ((Message_Name)type).ToString();
        }
        public static string ParseRTDDate(string rtdDate)
        {
            return ParseRTDDate(rtdDate, false);
        }
        public static string ParseRTDDate(string rtdDate, bool isUtcDate)
        {
            if (string.IsNullOrWhiteSpace(rtdDate))
            {
                return string.Empty;
            }
            int i = int.Parse(rtdDate);
            if (i == 0)
            {
                return string.Empty;
            }
            int hour = i % 100;
            i /= 100;
            int day = i % 100;
            i /= 100;
            int month = i % 100;
            i /= 100;
            int year = i % 10000;
            DateTime t = new DateTime(year, month, day, hour, 0, 0, isUtcDate ? DateTimeKind.Utc : DateTimeKind.Unspecified);
            TimeZoneInfo jpZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            if (isUtcDate)
            {
                t = UseLocalTime ? t.ToLocalTime() : TimeZoneInfo.ConvertTime(t, jpZone);
            }
            else
            {
                t = UseLocalTime ? TimeZoneInfo.ConvertTime(t, jpZone, TimeZoneInfo.Local) : t;
            }
            return t.ToString("yyyy-MM-dd HH:mm ddd");
        }
        public static string ParseUnitName(string unitId)
        {
            string sql = @"SELECT name FROM unit_master WHERE id={0}";
            return DAL.Get<string>(String.Format(sql, unitId));
        }
        public static string ParseUnitGroupName(string unitUiId)
        {
            string sql = @"SELECT id,name FROM unit_master WHERE ui_id={0}";
            DataTable dt = DAL.GetDataTable(String.Format(sql, unitUiId));
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendFormat("{0}|{1}", dr["id"].ToString(), dr["name"].ToString());
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }

        private static readonly Regex RichTextRegex = new Regex(@"(\[[a-zA-Z0-9]{6}\])(.*?)(\[-\])", RegexOptions.Compiled);

        static Utility()
        {
            UseLocalTime = false;
        }

        public static string ParseText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return String.Empty;
            }
            text = text.Replace(@"\n", "\n");
            return RichTextRegex.Replace(text, new MatchEvaluator(ParseTextEvaluator));
        }
        public static string ParseTextEvaluator(Match m)
        {
            string color = m.Groups[1].Value.Trim(new char[] { '[', ']' });
            //return String.Format("<span style='color:#{0}'>{1}</span>", color, m.Groups[2].Value);
            return m.Groups[2].Value;
        }
        public static int RealCalc(int baseAttr, int up, int lv)
        {
            return (int)Math.Round(baseAttr * ((lv - 1) * (up * 0.01) + 1));
        }
        public static string ParseBgmFileName(int no)
        {
            return "bgm_rtd_" + no.ToString("D2");
        }
        public static bool IsUnitEnemy(int num)
        {
            switch (num)
            {
                case 30:
                    return true;
                case 31:
                    return true;
                case 33:
                    return true;
                case 37:
                    return true;
                default:
                    switch (num - 22)
                    {
                        case 0:
                            return true;
                        case 2:
                            return true;
                        default:
                            return num == 45;
                    }
            }
        }
    }
}
