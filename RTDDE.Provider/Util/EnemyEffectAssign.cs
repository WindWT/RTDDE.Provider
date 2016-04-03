namespace RTDDE.Provider.Util
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
}