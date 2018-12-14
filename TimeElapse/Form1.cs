using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeElapse
{
    public partial class Form1 : Form
    {

        bool timer1state;//鏍囧織鐫€瀹氭椂鍣ㄦ槸鍚﹀紑鍚殑鍒ゆ柇
        bool timer2state;//鏍囧織鐫€瀹氭椂鍣ㄦ槸鍙栨柊鍊艰繕鏄鏃у€艰繘琛屾殏鍋?
                         // DateTime initdt = DateTime.Parse("00:01:10");//鍒濆鍖栨椂闂?
        DateTime zerodt = DateTime.Parse("00:00:00");//23:59:59
        DateTime dt;
        string dttext;
        //string h;
        //string m;
        //string s;
        public Form1()
        {
            InitializeComponent();
            //timer1.Enabled = true;
            //dt = initdt;
            timer1.Interval = 1000;
            timer1state = false;
            timer2state = true;
            //label1.Text = DateTime.Now.Second.ToString();
            DateTime.Now.Hour.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//tick浜嬩欢鏄敤鏉ヨ鏃剁殑锛岄殧涓€绉掓墽琛屼竴娆″噺鏃堕棿鐨勬搷浣滐紝鍦ㄨ繖閲屽垽鏂鏃跺埌0鐨勬椂鍊欐墽琛岀壒瀹氭搷浣?
         //鎰熻涔熶笉澶уソ锛岃寮€鏂扮嚎绋嬩笓闂ㄧ敤鏉ュ彂閫佹帴鏀讹紝姣旇緝涓嶈€楁椂闂?

            if (dt != zerodt)//鍒嗛挓濡備綍鍒ら浂锛燂紵
            {
                dt = dt.AddSeconds(-1);
                TimeLab.Text = dt.ToLongTimeString().ToString();
            }
            else
            {
                timer1.Stop();
                StartButton.Text = "start";
                timer1state = false;
                timer2state = true;
                MessageBox.Show("fuck you time arrive");//鎰熻messagebox鏄紑浜嗘柊绾跨▼锛岀劧鍚庢棫绾跨▼灏变竴鐩存病鍋滄锛屽鏋滄斁鍦╰ime1.stop()涔嬪墠灏变細鍑虹幇澶氫釜妗嗙幇璞?
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {//寮€濮嬫寜閽寜涓嬪悗瀛楀彉涓哄仠姝㈡寜閽紝鍚屾椂鎺у埗瀹氭椂鍣ㄧ殑寮€鍏?

            if (HourTextBox.Text != "" && MinuteTextBox.Text != "" && SecondTextBox.Text != "")
            {
                dttext = HourTextBox.Text + ":" + MinuteTextBox.Text + ":" + SecondTextBox.Text;
            }
            else
                MessageBox.Show("no zero please");
            if (timer2state)
            {
                dt = DateTime.Parse(dttext);//姣忔鎸夋殏鍋滈兘浼氬彇涓€閬嶅€掕鏃舵椂闂达紝閭ｄ箞鏆傚仠灏辩瓑浜庢槸閲嶈浜嗗憲锛?
                TimeLab.Text = dt.ToLongTimeString().ToString();
                timer2state = false;//绗竴娆＄殑鏃跺€欒鏍囧織浣嶇疆鍙嶏紝鍦ㄥ€掕鏃朵负闆舵椂鎵嶆爣蹇椾綅涓烘
            }


            if (!timer1state)
            {
                timer1.Start();
                StartButton.Text = "stop";//鏈変釜bug锛屼负浣曞仠姝簡浠ュ悗鍐嶅紑濮嬩細鍥炲埌绗竴娆″仠姝㈢殑鏃堕棿锛?
                timer1state = true;
            }
            else
            {
                timer1.Stop();
                StartButton.Text = "start";
                timer1state = false;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (HourTextBox.Text != "" && MinuteTextBox.Text != "" && SecondTextBox.Text != "")
            {
                dttext = HourTextBox.Text + ":" + MinuteTextBox.Text + ":" + SecondTextBox.Text;
            }
            else
                MessageBox.Show("no zero please");

            dt = DateTime.Parse(dttext);

            //dt = initdt;
            TimeLab.Text = dt.ToLongTimeString().ToString();
        }
    }
}
