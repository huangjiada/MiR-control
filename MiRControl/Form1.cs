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

namespace MiRControl
{
    /*  20181121
     * 1、更改界面形式，单按钮，仿360加速球模式
     * 2、应当兼容json格式输入，可挑选任务列表
     * 3、增加按键后反馈信息，200确认已上传任务，5秒倒计时防止重按，404等联系制作者
     * 4、
     * 
     * 20181122
     * 1、应当有正确的退出方式，右键菜单如何？
     * 2、
     * 20181204
     * 1、自动更新功能
     * 2、小车电量过低发任务过去，当然任务是要互斥的，检测的条件是电量低且任务列表中无充电任务
     * 
     * */

    public partial class Form1 : Form
    {

        Setting info = new Setting();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("setting.xml"))
            {
                using (StreamReader sr = new StreamReader("setting.xml"))
                {
                    info = (new XmlSerializer(typeof(Setting))).Deserialize(sr) as Setting;
                }
            }
            else
            {
                InitializeXml();
            }
            this.ControlBox= false;//最大化最小化关闭按钮
            this.MaximizeBox = false;//窗口大小固定
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//固定格式
            this.TopMost = true;//窗口前置

        }
        
        private void InitializeXml()
        {
            Setting settingInit = new Setting
            {
                UserName = "admin",
                UserPwd = "admin",
                GUID = "xxxx-xxxx-xxxx",
                Authority = MirEncode.Encode("admin", "admin"),
                basicIp = "http://10.15.181.62/api/v2.0.0",
                postIP = "mission_queue",
                getIP = "missions",
                postBody = "{mission_id=xxxx-xxxx-xxxx",

            };
            info = settingInit;
            using (StreamWriter sw = File.CreateText(@"setting.xml"))
            {
                (new XmlSerializer(typeof(Setting))).Serialize(sw, settingInit);
            }
        }
        public class Setting
        {
            public string UserName { get; set; }
            public string UserPwd { get; set; }
            public string GUID { get; set; }
            public string Authority { get; set; }
            public string basicIp { get; set; }
            public string postIP { get; set; }

            public string getIP { get; set; }
            public string postBody { get; set; }
        }

        private void btn_call_Click(object sender, EventArgs e)
        {
            string url = string.Format("{0}/{1}", info.basicIp, info.postIP);
            RestClient client = new RestClient();
            var retPost = client.POST(info.postBody, url, info.Authority);
            //用正规的时间委托来定返回值比较好，然后messagebox倒计时三秒后关闭
            MessageBox.Show("call success , click to exit");
        }

    }
}
