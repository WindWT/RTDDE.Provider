using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class MultiRewardMaster
    {
        public uint id;
        public uint unit00_id;
        public byte unit00_lv;
        public byte unit00_rarity;
        public uint unit01_id;
        public byte unit01_lv;
        public byte unit01_rarity;
        public uint unit02_id;
        public byte unit02_lv;
        public byte unit02_rarity;
        public uint unit03_id;
        public byte unit03_lv;
        public byte unit03_rarity;
        public uint unit04_id;
        public byte unit04_lv;
        public byte unit04_rarity;
        public uint unit05_id;
        public byte unit05_lv;
        public byte unit05_rarity;
        public uint unit06_id;
        public byte unit06_lv;
        public byte unit06_rarity;
        public uint unit07_id;
        public byte unit07_lv;
        public byte unit07_rarity;
        public uint unit08_id;
        public byte unit08_lv;
        public byte unit08_rarity;
        public uint unit09_id;
        public byte unit09_lv;
        public byte unit09_rarity;
        public uint rare_unit_id;
        public byte rare_unit_lv;
        public byte rare_unit_rarity;

        public uint GetUnitID(int index) {
            uint[] array = new uint[]
            {
                this.unit00_id,
                this.unit01_id,
                this.unit02_id,
                this.unit03_id,
                this.unit04_id,
                this.unit05_id,
                this.unit06_id,
                this.unit07_id,
                this.unit08_id,
                this.unit09_id,
                this.rare_unit_id
            };
            uint result = 0u;
            if (0 <= index && index < array.Length) {
                result = array[index];
            }
            return result;
        }

        public int GetUnitLv(int index) {
            uint[] array = new uint[]
            {
                (uint)this.unit00_lv,
                (uint)this.unit01_lv,
                (uint)this.unit02_lv,
                (uint)this.unit03_lv,
                (uint)this.unit04_lv,
                (uint)this.unit05_lv,
                (uint)this.unit06_lv,
                (uint)this.unit07_lv,
                (uint)this.unit08_lv,
                (uint)this.unit09_lv,
                (uint)this.rare_unit_lv
            };
            int result = 0;
            if (0 <= index && index < array.Length) {
                result = (int)array[index];
            }
            return result;
        }

        public int GetUnitRarity(int index) {
            uint[] array = new uint[]
            {
                (uint)this.unit00_rarity,
                (uint)this.unit01_rarity,
                (uint)this.unit02_rarity,
                (uint)this.unit03_rarity,
                (uint)this.unit04_rarity,
                (uint)this.unit05_rarity,
                (uint)this.unit06_rarity,
                (uint)this.unit07_rarity,
                (uint)this.unit08_rarity,
                (uint)this.unit09_rarity,
                (uint)this.rare_unit_rarity
            };
            int result = 0;
            if (0 <= index && index < array.Length) {
                result = (int)array[index];
            }
            return result;
        }
    }
}
