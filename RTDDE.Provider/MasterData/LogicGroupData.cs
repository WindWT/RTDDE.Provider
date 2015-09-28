namespace RTDDE.Provider.MasterData
{
    public class LogicGroupData
    {
        [DALColumn(PrimaryKey = true)]
        public uint logic_group_id;
        [DALColumn(SaveAsJson = true)]
        public LogicData[] logic_data;
    }
}