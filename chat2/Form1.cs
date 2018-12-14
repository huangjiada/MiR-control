using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;


namespace chat2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //关闭对文本框的非法线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        //创建 1个客户端套接字 和1个负责监听服务端请求的线程
        Thread threadclient = null;
        Socket socketclient = null;
        List<IPEndPoint> mlist = new List<IPEndPoint>();
        private void button1_Click(object sender, EventArgs e)
        {
            //SocketException exception;
            this.button1.Enabled = false;
            //定义一个套接字监听
            socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取文本框中的IP地址
            IPAddress address = IPAddress.Parse(textBox1.Text.Trim());

            //将获取的IP地址和端口号绑定在网络节点上
            IPEndPoint point = new IPEndPoint(address, int.Parse(textBox2.Text.Trim()));

            try
            {
                //客户端套接字连接到网络节点上，用的是Connect
                socketclient.Connect(point);
            }
            catch (Exception)
            {
                //MessageBox.
                MessageBox.Show("连接失败\r\n");
                this.button1.Enabled = true;
                return;
            }

            threadclient = new Thread(recv);

            threadclient.IsBackground = true;

            threadclient.Start();
        }



        // 接收服务端发来信息的方法  
        private void recv()//
        {
            int x = 0;
            while (true)//持续监听服务端发来的消息
            {
                try
                {
                    //定义一个1M的内存缓冲区，用于临时性存储接收到的消息
                    byte[] arrRecvmsg = new byte[1024 * 1024];

                    //将客户端套接字接收到的数据存入内存缓冲区，并获取长度
                    int length = socketclient.Receive(arrRecvmsg);

                    //将套接字获取到的字符数组转换为人可以看懂的字符串
                    string strRevMsg = Encoding.UTF8.GetString(arrRecvmsg, 0, length);
                    if (x == 1)
                    {
                        textBox3.AppendText("服务器:" + GetCurrentTime() + "\r\n" + strRevMsg + "\r\n\n");

                    }
                    else
                    {

                        textBox3.AppendText(strRevMsg + "\r\n\n");
                        x = 1;
                    }
                }
                catch (Exception ex)
                {
                    textBox3.AppendText("远程服务器已经中断连接" + "\r\n");
                    this.button1.Enabled = true;
                    break;
                }
            }
        }

        //获取当前系统时间
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        //发送字符信息到服务端的方法
        private void ClientSendMsg(string sendMsg)
        {
            //将输入的内容字符串转换为机器可以识别的字节数组   
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //调用客户端套接字发送字节数组   
            socketclient.Send(arrClientSendMsg);
            //将发送的信息追加到聊天内容文本框中   
            textBox3.AppendText(this.label4.Text + ": " + GetCurrentTime() + "\r\n" + sendMsg + "\r\n\n");
        }



        //点击按钮button2 向服务端发送信息 
        private void button2_Click(object sender, EventArgs e)
        {
            //调用ClientSendMsg方法 将文本框中输入的信息发送给服务端   
            ClientSendMsg(textBox4.Text.Trim());
            textBox4.Clear();

        }



        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            //当光标位于文本框时 如果用户按下了键盘上的Enter键
            if (e.KeyCode == Keys.Enter)
            {
                //则调用客户端向服务端发送信息的方法  
                ClientSendMsg(textBox4.Text.Trim());
                textBox4.Clear();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？选否,最小化到托盘", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;

            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.Visible = true;
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            //base.Show();
            base.WindowState = FormWindowState.Normal;
        }
    }
}