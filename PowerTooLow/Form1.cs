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
    
    public partial class Form1 : Form
    {
        XMLini.Setting set ;//设置一个设定类
        bool timer2state;

        DateTime dt;
        public Form1()
        {
            InitializeComponent();
            set = XMLini.infoset();
            
            timer2state = true;

            timer1.Interval = 1000;//计时器间隔1s
        }
        private void timer1_Tick(object sender, EventArgs e)
        {//tick事件是用来计时的，隔一秒执行一次减时间的操作，在这里判断计时到0的时候执行特定操作
         //感觉也不大好，要开新线程专门用来发送接收，比较不耗时间

            if (dt != set.InitZero)//如何单独对分钟判零
            {//若倒计时没到零，就减一并在label中显示出来
                dt = dt.AddSeconds(-1);//计时器每秒tick一次，那么时间也每秒减1s
                TimeLab.Text = dt.ToLongTimeString().ToString();
            }
            else
            {//倒计时到零，停止计时器，timer1stata=false表示计时器停止了，timer2state表示
                timer1.Stop();
                StartButton.Text = "start";
                //timer1state = false;
                timer2state = true;
                MessageBox.Show("fuck you time arrive");//开新线程进行队列检查
                //将检查放在外部CS

            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {//按下开始暂停按钮

            if (timer2state)
            {//timer2state 
                dt = set.InitPulse;//dt是用来减1s的，介于initpulse 和 initzero的中间态
                //每次按暂停都会取一遍倒计时时间，那么暂停就等于是重设了呗？
                TimeLab.Text = dt.ToLongTimeString().ToString();
                timer2state = false;//第一次的时候让标志位置反，在倒计时为零时才标志位为正
            }

            if (timer1.Enabled)
            {//若按下按钮计时器未开始则令计时器开始，若计时器已开始则令计时器停止
                timer1.Stop();
                StartButton.Text = "start";
            }
            else
            {
                timer1.Start();
                StartButton.Text = "stop";

            }
        }

    }
    


}
