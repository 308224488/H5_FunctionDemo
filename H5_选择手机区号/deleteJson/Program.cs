using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace deleteJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 读取原始的JSON文件
            string rawData = File.ReadAllText("/Users/cailuoxiong/Desktop/deleteJson/Json/countryCode_en.json");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(rawData);

            // 在每个数组元素中删除"name_cn"属性
            foreach (var obj in data)
            {
                obj.Remove("name_cn");
            }
            //将修改后的数据写回到文件中
            string modifiedData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("countryCode_en.json", modifiedData);
            Console.WriteLine(data);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.ReadKey();
        }
    }
}
