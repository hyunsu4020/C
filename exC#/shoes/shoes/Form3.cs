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

namespace shoes
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        string sql;
        public Form3(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "select sum(amount), avg(amount), max(amount), min(amount), count(amount)  " +
               " from tbOrder ";

            cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                listBox1.Items.Add("총 합계 : " + reader[0].ToString());     //sum출력  
                listBox1.Items.Add("평균 : " + reader[1].ToString());
                listBox1.Items.Add("제일 비싼 내역(최대값) : " + reader[2].ToString());
                listBox1.Items.Add("제일 싼 내역(최소값) : " + reader[3].ToString());
                listBox1.Items.Add("구매내역 갯수 : " + reader[4].ToString());
            }
        }
    }
}
