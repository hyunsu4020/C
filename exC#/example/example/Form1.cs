using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        string sql;
        public Form1()
        {
            InitializeComponent();
            string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C#\\example\\bookDB.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(conStr);

            sql = "select * from tbBook";
            cmd = new SqlCommand(sql, con);
        }

        private void button1_Click(object sender, EventArgs e)
        {   // 등록 버튼
            string value1, value2, value3, value4;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = comboBox1.Text;
            value4 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "insert into tbBook " +
                " values ( '" + value1 + "', N'" + value2 + "', N'" + value3 + "', '" + value4 + "' )";
            
            cmd.ExecuteNonQuery();

            MessageBox.Show("등록되었습니다.");
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void 도서분류별검색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(con);
            frm2.Show();
        }

        private void 가격순정렬ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(con);
            frm3.Show();
        }
    }
}
