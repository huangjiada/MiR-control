using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Web;
using System.IO;
using MiRControl;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace PowerTooLow
{
    class PowerCheck
    {//该类通过网络请求检查任务队列，无充电任务且电量低于20%，插入充电任务
        public bool chk_mission_queue()
        {
            bool chk;
            RestClient client = new RestClient();
            var retPost = client.GET("192.168.8.1/");//先得任务队列
            JObject jo = (JObject)JsonConvert.DeserializeObject(retPost);//jsonreader 读测试
            string battery = jo["data"]["city"].ToString();//data下面的country携带的是什么值
            if ()
                chk = true;
            //Console.WriteLine(location);
            return chk
        }
    }

}
