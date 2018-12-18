using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "server=ASM-PC;database=SQLtest;Trusted_Connection=SSPI;Integrated Security=true";//连接属性
                String query = "select * from Task";
                SqlConnection con = new SqlConnection(str); //建立连接
                SqlCommand cmd = new SqlCommand(query, con);//命令
                con.Open();//打开数据库
                SqlDataAdapter myda = new SqlDataAdapter(query, str);//过滤器，sql语句+创造连接属性
                DataSet ds = new DataSet();//创建容器ds
                myda.Fill(ds, "test");//填入容器
                dataGridView1.DataSource = ds.Tables["test"];
                MessageBox.Show("connect with sql server");

                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
