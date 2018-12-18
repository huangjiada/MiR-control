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

        //bool timer1state;//timer1是否运转的状态表示
        bool timer2state;//标志定时器是取新值还是对旧值暂停
                         // DateTime initdt = DateTime.Parse("00:01:10");//初始化时间
        DateTime zerodt = DateTime.Parse("00:00:00");//结束时间为00:00:00 所以倒计时最大计时为23:59:59
        DateTime dt;
        string dttext;
        //string h;
        //string m;
        //string s;
        public Form1()
        {
            InitializeComponent();
           
            //dt = initdt;
            timer1.Interval = 1000;//计时器间隔1s
            timer2state = true;
            //label1.Text = DateTime.Now.Second.ToString();
            DateTime.Now.Hour.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//tick事件是用来计时的，隔一秒执行一次减时间的操作，在这里判断计时到0的时候执行特定操作
         //感觉也不大好，要开新线程专门用来发送接收，比较不耗时间

            if (dt != zerodt)//如何单独对分钟判零
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
                MessageBox.Show("fuck you time arrive");//感觉messagebox是开了新线程，然后旧线程就一直没停止，如果放在time1.stop()之前就会出现多个框现象
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {//按下开始暂停按钮

            if (HourTextBox.Text != "" && MinuteTextBox.Text != "" && SecondTextBox.Text != "")
            {
                dttext = HourTextBox.Text + ":" + MinuteTextBox.Text + ":" + SecondTextBox.Text;
            }
            else
                MessageBox.Show("no zero please");

            if (timer2state)
            {//timer2state 
                dt = DateTime.Parse(dttext);//将string形式时间转换为datatime形式
                //每次按暂停都会取一遍倒计时时间，那么暂停就等于是重设了呗？
                TimeLab.Text = dt.ToLongTimeString().ToString();
                timer2state = false;//第一次的时候让标志位置反，在倒计时为零时才标志位为正
            }

            if (!timer1.Enabled)
            {//若按下按钮计时器未开始则令计时器开始，若计时器已开始则令计时器停止
                timer1.Start();
                StartButton.Text = "stop";
            }
            else
            {
                timer1.Stop();
                StartButton.Text = "start";
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
