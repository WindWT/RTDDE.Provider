using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable InconsistentNaming

namespace RTDDE.Provider.Enums
{
    public enum MASTERDB
    {
        UNIT_MASTER = 10,
        PARTY_SKILL_MASTER = 11,
        PARTY_SKILL_RANK_MASTER = 12,
        ACTIVE_SKILL_MASTER = 13,
        ACTIVE_SKILL_RANK_MASTER = 14,
        UNIT_TALK_MASTER = 15,  //not exist
        PANEL_SKILL_MASTER = 16,
        PANEL_SKILL_RANK_MASTER = 17,
        ACCESSORY_MASTER = 18,
        MAX = 19,   //not exist, used for default
        ENEMY_UNIT_MASTER = 20,
        ENEMY_TABLE_MASTER,  //not exist
        ENEMY_DROP_MASTER = 22,  //not exist
        QUEST_MASTER = 30,
        //QUEST_CATEGORY_MASTER = 31,   //not exist after 5.1
        QUEST_CHALLENGE_MASTER = 32,
        QUEST_CHALLENGE_REWARD_MASTER = 33,
        SP_EVENT_MASTER = 34,
        QUEST_AREA_MASTER = 37,
        QUEST_FIELD_MASTER = 38,
        QUEST_WORLD_MASTER = 39,
        GACHA_ITEM_MASTER = 40,
        GACHA_TABLE_MASTER = 41,  //not exist
        SHOP_PRODUCT_MASTER = 42,   //exist in iOS only
        SHOP_PRODUCT_MASTER_ANDROID = 43,
        LOGIN_BONUS_MASTER = 51,
        SEQUENCE_LOGIN_BONUS_MASTER = 52,
        USER_RANK_MASTER = 60,
        LEVELDATA_LIST_MASTER = 70,  //not exist
        TALK_DIALOG_MASTER = 80,
        GLOBAL_PARAM_MASTER = 90,
        LIMIT_SKILL_MASTER = 91,
        LIMIT_SKILL_RANK_MASTER = 92,
        MAP_EVENT_MASTER = 95,
        MAIN_ASSET_BUNDLE_MASTER = 121,
        QUEST_ASSET_BUNDLE_MASTER = 122,
        SPIRITS_TREE = 150,
        SPIRITS_TREE_NUTS = 151,
        SPIRITS_TREE_NUTS_POS = 152,
        SPIRITS_TREE_ADD = 153,
        SPIRITS_TREE_COLLECTION = 154,
        SPIRITS_TREE_ACTION = 155,
        SPIRITS_TREE_CHIBI_POS = 156,
        SPIRITS_TREE_PARAM = 158,
        SPIRITS_TREE_NUTS_QUEUE = 159,
        LEVEL_DATA_MASTER = 999,  //not exist after 1.8?
    }
}