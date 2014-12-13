using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTDDE.Provider.MasterData;

namespace RTDDE.Provider.Enums
{
    public static class Converter
    {
        private static readonly Dictionary<MASTERDB, Type> MasterdbEnumTypeDictionary=new Dictionary<MASTERDB, Type>()
        {
            {MASTERDB.USER_RANK_MASTER,typeof(UserRankMaster)},
            {MASTERDB.UNIT_MASTER,typeof(UnitMaster)},
            {MASTERDB.PARTY_SKILL_MASTER,typeof(PartySkillMaster)},
            {MASTERDB.PARTY_SKILL_RANK_MASTER,typeof(PartySkillRankMaster)},
            {MASTERDB.ACTIVE_SKILL_MASTER,typeof(ActiveSkillMaster)},
            {MASTERDB.ACTIVE_SKILL_RANK_MASTER,typeof(ActiveSkillRankMaster)},
            {MASTERDB.ENEMY_UNIT_MASTER,typeof(EnemyUnitMaster)},
            {MASTERDB.ENEMY_TABLE_MASTER,typeof(EnemyTableMaster)},
            {MASTERDB.ENEMY_DROP_MASTER,typeof(EnemyDropMaster)},   //not exist
            {MASTERDB.QUEST_MASTER,typeof(QuestMaster)},
            //{MASTERDB.QUEST_CATEGORY_MASTER,typeof(QuestCategoryMaster)},
            {MASTERDB.SHOP_PRODUCT_MASTER,typeof(ShopProductMaster)},
            {MASTERDB.SHOP_PRODUCT_MASTER_ANDROID,typeof(ShopProductMasterAndroid)},
            {MASTERDB.LOGIN_BONUS_MASTER,typeof(MonthlyLoginBonusMaster)},
            {MASTERDB.SEQUENCE_LOGIN_BONUS_MASTER,typeof(SequenceLoginBonusMaster)},
            {MASTERDB.LEVELDATA_LIST_MASTER,typeof(LevelDataListMaster)},
            {MASTERDB.UNIT_TALK_MASTER,typeof(UnitTalkMaster)},
            {MASTERDB.GLOBAL_PARAM_MASTER,typeof(GlobalParamsMaster)},
            {MASTERDB.QUEST_CHALLENGE_MASTER,typeof(QuestChallengeMaster)},
            {MASTERDB.QUEST_CHALLENGE_REWARD_MASTER,typeof(QuestChallengeRewardMaster)},
            {MASTERDB.SP_EVENT_MASTER,typeof(SpEventMaster)},
            {MASTERDB.PANEL_SKILL_MASTER,typeof(PanelSkillMaster)},
            {MASTERDB.PANEL_SKILL_RANK_MASTER,typeof(PanelSkillRankMaster)},
            {MASTERDB.ACCESSORY_MASTER,typeof(AccessoryMaster)},
            {MASTERDB.TALK_DIALOG_MASTER,typeof(TalkDialogHeaderMaster)},
            {MASTERDB.LIMIT_SKILL_MASTER,typeof(LimitSkillMaster)},
            {MASTERDB.LIMIT_SKILL_RANK_MASTER,typeof(LimitSkillRankMaster)},
            {MASTERDB.QUEST_AREA_MASTER,typeof(QuestAreaMaster)},
            {MASTERDB.QUEST_FIELD_MASTER,typeof(QuestFieldMaster)},
            {MASTERDB.QUEST_WORLD_MASTER,typeof(QuestWorldMaster)},
            {MASTERDB.LEVEL_DATA_MASTER,typeof(LevelDataMaster)},
        };

        public static MASTERDB Type2Enum(Type type)
        {
            return MasterdbEnumTypeDictionary.ContainsValue(type) ? MasterdbEnumTypeDictionary.First(o => o.Value == type).Key : MASTERDB.MAX;
        }

        public static Type Enum2Type(MASTERDB mdb)
        {
            Type type;
            return MasterdbEnumTypeDictionary.TryGetValue(mdb, out type) ? type : null;
        }
    }
}
