using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRControl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace HttpRequesttest
{
    class Program
    {
        /*
         * type:
         * {"code":0,"data":{"ip":"104.224.132.102","country":"美国","area":"","region":"加利福尼亚","city":"洛杉矶","county":"XX","isp":"XX","country_id":"US","area_id":"","region_id":"US_104","city_id":"US_1018","county_id":"xx","isp_id":"xx"}}
         * 
         * 小车的情况:
         * 1、status会返回正在执行的id和当前电量
         * 2、mission_queue会返回一大列，我感觉有问题，要过滤所有abort，怎么遍历到最后一个呢？jo.count 有计数量
         * 3、put status可以实现状态转换，
         * 
         * */
        struct information
        {
            public string basicIp;
            public string requestIp;
        }
   
        static void Main(string[] args)
        {
            information info;
            info.basicIp = "http://ip.taobao.com/service/getIpInfo.php?ip";
            info.requestIp = "104.224.132.102";
            string url = string.Format("{0}={1}", info.basicIp, info.requestIp);
            RestClient client = new RestClient();
            var retPost = client.GET(url);
            JObject jo = (JObject)JsonConvert.DeserializeObject(retPost);;//jsonreader 读测试
            string location = jo["data"]["city"].ToString();//data下面的country携带的是什么值
            Console.WriteLine(location);
        }
    }
}
