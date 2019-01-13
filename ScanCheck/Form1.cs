using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace ScanCheck
{
    public partial class Form1 : Form
    {//五秒更新一次status，独占读写currentlocation，利用字符转枚举得到数字，用数字对应字符串数组的kittingbox编码，与扫码枪验证
        //
        
        public enum Location
        {
            工位1 = 1,
            工位2 = 2,
            工位3 = 3,
            工位4 = 4,
            工位5 = 5,
            工位6 = 6,
            工位7 = 7,
            工位8 = 8,
            工位9 = 9,
            工位10 = 10,
        }

        public string[] KittingBoxCode = { "Null", "001", "002", "003", "004", "005", "006", "007", "008", "009", "010" };

        Setting info;
        int CurrentLocation;
        public Form1()
        {//在外部setting文件输出或读取location的信息，看后面老板要不要
            InitializeComponent();

            // 枚举转字符串 string enumStringTwo = Enum.GetName(typeof(Color), color);//推荐
            //枚举转数值int enumValueThree = Convert.ToInt32(color);
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
            this.ControlBox = false;//最大化最小化关闭按钮
            this.MaximizeBox = false;//窗口大小固定
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//固定格式
            this.TopMost = true;//窗口前置
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != KittingBoxCode[CurrentLocation])
                    MessageBox.Show("Error box", "提示"); 
                else
                {
                    //放能重置PLC线圈为1的发送
                }
            }
        }
        private void InitializeXml()
        {
            Setting settingInit = new Setting
            {//这里设置取status和plc的路劲
                UserName = "admin",
                UserPwd = "admin",
                GUID = "xxxx-xxxx-xxxx",
                Authority = MirEncode.Encode("admin", "admin"),
                basicIp = "http://10.15.181.62/api/v2.0.0",
                postIP = "plccore",
                getIP = "missions",
                postBody = "{mission_id=xxxx-xxxx-xxxx}",
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
            string[] Location { get; set; }
            public string getIP { get; set; }
            public string postBody { get; set; }
        }

    }
}
