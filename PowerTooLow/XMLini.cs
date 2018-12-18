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

namespace PowerTooLow
{
    public class XMLini
    {
        
        static public Setting infoset ()
        {
            Setting getset = new Setting();
            if (File.Exists("setting.xml"))
            {

                using (StreamReader sr = new StreamReader("setting.xml"))
                {
                    getset = (new XmlSerializer(typeof(Setting))).Deserialize(sr) as Setting;
                }
            }
            else
            {
                InitializeXml(getset);
            }
            return getset;

        }

        static public void InitializeXml(Setting getset)
        {
            Setting settingInit = new Setting
            {
                InitPulse = DateTime.Parse("00:05:00"),
                InitZero = DateTime.Parse("00:00:00"),

            };
            getset = settingInit;
            using (StreamWriter sw = File.CreateText(@"setting.xml"))
            {
                (new XmlSerializer(typeof(Setting))).Serialize(sw, settingInit);
            }
        }
        public class Setting
        {
            public DateTime InitPulse { get; set; }
            public DateTime InitZero { get; set; }
        }

    }


}
