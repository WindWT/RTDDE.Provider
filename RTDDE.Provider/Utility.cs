using RTDDE.Provider.Enums;
using RTDDE.Provider.MasterData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MsgPack.Serialization;
using RTDDE.Provider.Util;

namespace RTDDE.Provider
{
    public class Utility
    {
        public static bool UseLocalTime { get; set; }
        public static readonly List<FontGlyph> FontGlyphs;
        static Utility() {
            UseLocalTime = false;
            using (Stream stream = new MemoryStream(Properties.Resources.FontInfo)) {
                var packer = MessagePackSerializer.Get<List<FontGlyph>>();
                FontGlyphs = packer.Unpack(stream);
            }
        }
        
        public static string ParsePresentType(int type) {
            switch (type) {
                case 0: return "NONE";
                case 1: return "COIN";
                case 2: return "FP";
                case 3: return "STONE";
                case 4: return "UNIT";
                default: return "未知" + type.ToString();
            }
        }
        public static string ParseBonusType(int type) {
            switch (type) {
                case 0: return "NONE";
                case 1: return "体力半减";
                case 2: return "双倍钱";
                case 3: return "双倍经验";
                case 4: return "双倍魂?";
                case 5: return "双倍掉落";
                default: return "未知" + type.ToString();
            }
        }

        public static string ParseAttributeToString(int attribute) {
            return attribute >= 1 && attribute <= 5 ? ParseAttribute(attribute).ToString() : attribute.ToString();
        }

        public static UnitAttribute ParseAttribute(int attribute) {
            switch (attribute) {
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
                    return UnitAttribute.ALL;
            }
        }
        public static string ParseStyletype(int styletype) {
            return styletype >= 1 && styletype <= 4 ? ParseRealStyletype(styletype).ToString() : styletype.ToString();
        }

        private static Class ParseRealStyletype(int styletype) {
            switch (styletype) {
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

        public static readonly EnemyEffectAssign[] m_EffectList = new EnemyEffectAssign[] {
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
            new EnemyEffectAssign(312, "ef_atk_magic_03", null),
            new EnemyEffectAssign(111, "ef_atk_spear_09", null),
            new EnemyEffectAssign(13, "ef_atk_blade_10", null),
            new EnemyEffectAssign(112, "ef_atk_spear_10", null),
            new EnemyEffectAssign(214, "ef_atk_arrow_09", null),
            new EnemyEffectAssign(215, "ef_atk_arrow_09", null),
            new EnemyEffectAssign(313, "ef_atk_magic_06", null),
            new EnemyEffectAssign(213, "ef_atk_arrow_08", null),
            new EnemyEffectAssign(314, "ef_atk_magic_07", null),
            new EnemyEffectAssign(315, "ef_atk_magic_04", null),
            new EnemyEffectAssign(113, "ef_atk_spear_06", null),
            new EnemyEffectAssign(316, "ef_atk_magic_03", null),
            new EnemyEffectAssign(216, "ef_atk_arrow_09", null),
            new EnemyEffectAssign(14, "ef_atk_blade_04", null),
            new EnemyEffectAssign(217, "ef_atk_arrow_08", null),
            new EnemyEffectAssign(218, "ef_atk_arrow_08", null),
            new EnemyEffectAssign(15, null, "ef_snr_atk_blade_01"),
            new EnemyEffectAssign(114, null, "ef_snr_atk_spear_01"),
            new EnemyEffectAssign(115, null, "ef_snr_atk_spear_02"),
            new EnemyEffectAssign(219, null, "ef_snr_atk_arrow_01"),
            new EnemyEffectAssign(220, null, "ef_snr_atk_arrow_02"),
            new EnemyEffectAssign(317, null, "ef_snr_atk_magic_01"),
            new EnemyEffectAssign(318, null, "ef_snr_atk_magic_02"),
            new EnemyEffectAssign(319, null, "ef_snr_atk_magic_03"),
            new EnemyEffectAssign(320, null, "ef_snr_atk_magic_04"),
            new EnemyEffectAssign(321, null, "ef_snr_atk_magic_05"),
            new EnemyEffectAssign(322, null, "ef_snr_atk_magic_06"),
            new EnemyEffectAssign(116, "ef_atk_spear_06", null),
            new EnemyEffectAssign(323, "ef_atk_magic_01", null),
            new EnemyEffectAssign(16, "ef_atk_blade_03", null),
            new EnemyEffectAssign(221, "ef_atk_arrow_10", null),
            new EnemyEffectAssign(117, "ef_atk_spear_11", null),
            new EnemyEffectAssign(222, "ef_atk_arrow_11", null),
            new EnemyEffectAssign(324, "ef_atk_magic_08", null),
            new EnemyEffectAssign(118, "ef_atk_blade_09", null),
            new EnemyEffectAssign(223, "ef_atk_blade_09", null),
            new EnemyEffectAssign(325, "ef_atk_blade_09", null),
            new EnemyEffectAssign(119, "ef_atk_spear_12", null),
            new EnemyEffectAssign(17, "ef_atk_spear_05", null),
            new EnemyEffectAssign(224, "ef_atk_arrow_12", null)
        };
        #endregion
        public static AssignID ParseUnitKind(int kind) {
            AssignID assignId = AssignID.SWORD;
            int length = m_EffectList.Length;
            for (int index = 0; index < length; ++index) {
                EnemyEffectAssign enemyEffectAssign = m_EffectList[index];
                if (kind == (int)enemyEffectAssign.m_EffectIndex)
                    assignId = (AssignID)index;
            }
            return assignId;
        }
        public static int ParseAssignID(AssignID category) {
            int num = 1;
            int index = (int)category;
            int length = m_EffectList.Length;
            if (index >= 0 && index < length)
                num = (int)m_EffectList[index].m_EffectIndex;
            return num;
        }
        public static string ParseQuestKind(int kind) {
            return ((E_QUEST_KIND)kind).ToString();
        }
        public static string ParseChallengeType(int type) {
            return ((ECHALLENGE_TYPE)type).ToString();
        }
        public static string ParseZBTNKind(int kind) {
            switch (kind) {
                case 0: return "NORMAL";
                case 1: return "EVENT";
                case 2: return "LARGE_EVENT";
                case 3: return "SPECIAL";
                default: return "UNKNOWN_" + kind.ToString();
            }
        }
        public static string ParseSkillType<T>(T skillType) {
            return skillType.ToString();
        }
        public static string ParseAccessoryType(int type) {
            return ((AccessoryType)type).ToString();
        }
        public static string ParseEnemyType(int type) {
            return ((ENEMY_TYPE)type).ToString();
        }
        public static string ParseAttackPattern(int type) {
            return ((AttackPattern)type).ToString();
        }
        public static string ParseMultiConditionType(int type) {
            return ((eCondition)type).ToString();
        }
        public static string ParseTriggerType(int type) {
            return ((eTriggerType)type).ToString();
        }
        public static string ParseMessageName(int type) {
            return ((Message_Name)type).ToString();
        }
        public static string ParseOpenType(int type) {
            return ((OpenType)type).ToString();
        }
        private static DateTime ConvertTimeZone(DateTime dateTime, bool isUtc) {
            TimeZoneInfo jpZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            if (isUtc) {
                return UseLocalTime ? dateTime.ToLocalTime() : TimeZoneInfo.ConvertTime(dateTime, jpZone);
            }
            else {
                return UseLocalTime ? TimeZoneInfo.ConvertTime(dateTime, jpZone, TimeZoneInfo.Local) : dateTime;
            }
        }
        public static DateTime ParseRTDTime(int rtdTime, bool isUtc = false) {
            if (rtdTime == 0) {
                return DateTime.MinValue;
            }
            DateTime t = DateTime.MinValue;
            if (DateTime.TryParseExact(rtdTime.ToString("D4"), "HHmm", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out t) == false) {
                return t;
            }
            return ConvertTimeZone(t, isUtc);
        }
        public static DateTime ParseRTDDate(int rtdDate, bool isUtc = false) {
            if (rtdDate == 0) {
                return DateTime.MinValue;
            }
            int hour = rtdDate % 100;
            rtdDate /= 100;
            int day = rtdDate % 100;
            rtdDate /= 100;
            int month = rtdDate % 100;
            rtdDate /= 100;
            int year = rtdDate % 10000;
            DateTime t = new DateTime(year, month, day, hour, 0, 0, isUtc ? DateTimeKind.Utc : DateTimeKind.Unspecified);
            return ConvertTimeZone(t, isUtc);
        }

        public static int ToRTDDate(DateTime time, bool toUtcDate) {
            DateTime utcTime = time.ToUniversalTime();
            TimeZoneInfo jpZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            if (toUtcDate == false) {
                utcTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, jpZone);
            }
            return int.Parse(utcTime.ToString("yyyyMMddHH"));
        }
        public static string ParseUnitName(int unitId) {
            string sql = @"SELECT name FROM unit_master WHERE id={0}";
            return DAL.Get<string>(String.Format(sql, unitId));
        }
        public static string ParseUnitGroupName(int unitUiId) {
            string sql = @"SELECT * FROM unit_master WHERE ui_id={0}";
            List<UnitMaster> unitMasters = DAL.ToList<UnitMaster>(String.Format(sql, unitUiId));
            StringBuilder sb = new StringBuilder();
            foreach (UnitMaster unit in unitMasters) {
                sb.AppendFormat("{0}|{1}", unit.id, unit.name);
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }

        private static readonly Regex RichTextRegex = new Regex(@"(\[[a-zA-Z0-9]{6}\])(.*?)(\[-\])", RegexOptions.Compiled);

        public static string ParseText(string text) {
            if (string.IsNullOrEmpty(text)) {
                return String.Empty;
            }
            text = text.Replace(@"\n", "\n");
            return RichTextRegex.Replace(text, new MatchEvaluator(ParseTextEvaluator));
        }
        public static string ParseTextEvaluator(Match m) {
            string color = m.Groups[1].Value.Trim(new char[] { '[', ']' });
            //return String.Format("<span style='color:#{0}'>{1}</span>", color, m.Groups[2].Value);
            return m.Groups[2].Value;
        }

        public static int RealCalc(int baseAttr, int up, int lv) {
            return (int)((float)baseAttr * (float)((double)(lv - 1) * ((double)up * 0.00999999977648258) + 1.0));
        }

        public static string ParseBgmName(int no) {
            string realBgmName = "";
            switch (no) {
                case 0: realBgmName = "NO BGM"; break;
                case 1: realBgmName = "01 LORD"; break;
                case 2: realBgmName = "03 LIFE"; break;
                case 3: realBgmName = "04 COLLISION"; break;
                case 4: realBgmName = "05 DRAGON"; break;
                case 5: realBgmName = "13 CLEAR"; break;
                case 6: realBgmName = "02 CHOSEN"; break;
                case 7: realBgmName = "14 OVER"; break;
                case 8: realBgmName = "06 SKY HIGH"; break;
                case 9: realBgmName = "07 OUTBREAK"; break;
                case 10: realBgmName = "11 WHITE"; break;
                case 11: realBgmName = "12 BRAVE"; break;
                case 12: realBgmName = "21 OPEN"; break;
                case 13: realBgmName = "22 CLOSE"; break;
                case 14: realBgmName = "18 TREE"; break;
                case 15: realBgmName = "19 CAKE"; break;
                case 16: realBgmName = "20 TART"; break;
                case 17: realBgmName = "???(DSG)"; break;
                case 18: realBgmName = "???(DSG)"; break;
                default: realBgmName = "UNKNOWN"; break;
            }
            return realBgmName + $"({no.ToString("D2")})";
        }

        public static bool IsUnitEnemy(int num) {
            switch (num) {
                case 30:
                    return true;
                case 31:
                    return true;
                case 33:
                    return true;
                case 37:
                    return true;
                default:
                    switch (num - 22) {
                        case 0:
                            return true;
                        case 2:
                            return true;
                        default:
                            switch (num - 45) {
                                case 0:
                                    return true;
                                case 2:
                                    return true;
                                default:
                                    return false;
                            }
                    }
            }
        }
        public static bool IsDvGObject(int num) {
            bool flag = false;
            switch (num) {
                case 48:
                    flag = true;
                    break;
                case 49:
                    flag = true;
                    break;
                case 50:
                    flag = true;
                    break;
            }
            return flag;
        }

        public bool IsExpBall(int num) {
            switch (num) {
                case 52:
                case 53:
                case 54:
                    return true;
                default:
                    return false;
            }
        }

        public bool IsFootPrintExpBall(int num) {
            return num == 54;
        }
    }
}
