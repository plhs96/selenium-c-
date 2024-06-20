using FinalTest.Json;
using FinalTest.Object;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Final.Json
{
    public class ReadJson
    {
        

        /// <summary>
        /// Get data and read it from first object
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataForTC1()
        {
            var filePath = @"..\..\..\Datas\data.json";
            var json = File.ReadAllText(filePath);
            var jobject = JObject.Parse(json);
            var datas = jobject["TestCase1"]?.ToObject<IEnumerable<DataObject>>();
            foreach (var data in datas ?? Enumerable.Empty<DataObject>())
            {
                yield return new[] { data };
            }
        }
        /// <summary>
        /// Get data and read it from second object
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataForTC2()
        {
            var filePath = @"..\..\..\Datas\data.json";
            var json = File.ReadAllText(filePath);
            var jobject = JObject.Parse(json);
            var datas = jobject["TestCase2"]?.ToObject<IEnumerable<DataObject>>();
            foreach (var data in datas ?? Enumerable.Empty<DataObject>())
            {
                yield return new[] { data };
            }
        }
        /// <summary>
        /// Get data and read it from third object
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataForTC3()
        {
            var filePath = @"..\..\..\Datas\data.json";
            var json = File.ReadAllText(filePath);
            var jobject = JObject.Parse(json);
            var datas = jobject["TestCase3"]?.ToObject<IEnumerable<DataObject>>();
            foreach (var data in datas ?? Enumerable.Empty<DataObject>())
            {
                yield return new[] { data };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>GetDataConfig</returns>
        public static string GetDataConfig()
        {
            var filePath = @"..\..\..\Datas\app.json";
            var json = File.ReadAllText(filePath);
            var jobject = JObject.Parse(json);
            var configs = jobject["config"]?.ToObject<IEnumerable<Browsers>>();
            return configs.First().browser;
        }
    }
}
