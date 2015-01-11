using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using MsgPack;
using MsgPack.Serialization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RTDDE.Provider
{
    public static class MsgBytes
    {
        public static string ToJson(Stream msgPackStream)
        {
            var msg = MessagePackSerializer.Get<MessagePackObject>();
            return msg.Unpack(msgPackStream).ToString();
        }
        public static List<T> ToList<T>(Stream msgPackStream)
        {
            Type wrapperType = GetWrapperType<T>();
            var msg = MessagePackSerializer.Get(wrapperType);
            var response = msg.Unpack(msgPackStream);
            MethodInfo getMasterMethodInfo = wrapperType.GetMethod("GetMaster");
            return (getMasterMethodInfo.Invoke(response, null) as IList<T>).ToList<T>();
        }
        private static readonly string Template = @"using System;
using System.Collections.Generic;
using RTDDE.Provider.MasterData;
using RTDDE.Provider.MasterData.Wrapper;

    [Serializable]
    public class {0}Wrapper : WrapperBase
    {{
        [Serializable]
        public class MasterData
        {{
            public int type;
            public string hash;
            public bool changed;
            public {0}[] data_list;
        }}
        public MasterData[] result;
        public List<Byte> quest_clear_flags;
        public List<Byte> quest_new_flags;
        public QuestChallengeState[] quest_challenge_state;
        public QuestChallengeRewardState[] quest_challenge_reward_state;
        public {0}[] GetMaster()
        {{
            return this.result[0].data_list;
        }}
    }}
";
        private static Type GetWrapperType<T>()
        {
            var typeName = typeof (T).Name;
            var provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("RTDDE.Provider.dll");
            CompilerResults generated = provider.CompileAssemblyFromSource(parameters, string.Format(Template, typeName));
            return generated.CompiledAssembly.GetType(string.Format("{0}Wrapper", typeName));
        }
    }
}
