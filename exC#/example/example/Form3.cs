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
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        string sql;
        public Form3(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            sql = "select * from tbBook";
            GridRetrival(sql);
        }

        private void GridRetrival(string sql)
        {
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table.DefaultView;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   // 조회
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;

            string sql = "select * from tbBook " +
                " where price >= '" + value1 + "' and " +
                "price <= '" + value2 + "' ";

            GridRetrival(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {   // 오름차 순
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;

            string sql = "select * from tbBook " +
                " where price >= '" + value1 + "' and " +
                " price <= '" + value2 + "' " +
                " order by price asc";      // asc: ascending sort 오름차 순 정렬: 작은값 -> 큰값순으로 정렬

            GridRetrival(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {   // 내림차 순
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;

            string sql = "select * from tbBook " +
                " where price >= '" + value1 + "' and " +
                "price <= '" + value2 + "' " +
                " order by price desc";      // desc: descending sort 내림차순 정렬: 큰값 -> 작은값으로 정렬

            GridRetrival(sql);
        }
    }
}
