namespace RTDDE.Provider.Util
{
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
}