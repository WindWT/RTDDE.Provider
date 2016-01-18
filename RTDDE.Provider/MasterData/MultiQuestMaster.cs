using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider.MasterData
{
    [Serializable]
    public class MultiQuestMaster
    {
        public uint id;
        public int host_ticket;
        public int guest_ticket;
        public uint reward_id;
        public uint medal00_id;
        public uint medal01_id;
        public uint medal02_id;
        public uint medal03_id;
        public uint medal04_id;
        public uint medal05_id;
        public uint medal06_id;
        public uint medal07_id;
        public uint medal08_id;
        public uint medal09_id;
        public int footprint_exp;

        public uint[] GetMedals() {
            return new uint[]
            {
                this.medal00_id,
                this.medal01_id,
                this.medal02_id,
                this.medal03_id,
                this.medal04_id,
                this.medal05_id,
                this.medal06_id,
                this.medal07_id,
                this.medal08_id,
                this.medal09_id
            };
        }
    }
}
