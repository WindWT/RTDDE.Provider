﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RTDDE.Provider.MasterData;
using System.Collections.Generic;
using System.IO;

namespace RTDDE.Provider
{
    public static class JSON
    {
        /// <summary>
        /// 将JSON转换为实体List
        /// </summary>
        /// <typeparam name="T">JSON对应的MDB实体</typeparam>
        /// <param name="json">JSON</param>
        /// <returns></returns>
        public static List<T> ToList<T>(string json)
        {
            json = json.Replace(@"\uA0", string.Empty);  //temp fix!
            JObject jo = JObject.Parse(json);
            JToken jt = jo["result"][0]["data_list"];   //只有MDB能这么玩，LDB不行
            return JsonConvert.DeserializeObject<List<T>>(jt.ToString());
        }
        public static T ToSingle<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}