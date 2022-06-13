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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        string sql;
        public Form1()
        {
            InitializeComponent();
            string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C#\\shoes\\shoes\\shoes.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(conStr);
            GridRetrival();
        }

        private void GridRetrival()
        {
            sql = "select * from tbShoes";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table.DefaultView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'shoesDataSet3.tbShoes' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbShoesTableAdapter1.Fill(this.shoesDataSet3.tbShoes);

        }

        private void button4_Click(object sender, EventArgs e)
        {   // 조회 버튼
            sql = "select * from tbShoes " +
                " where id = '" + textBox1.Text + "' ";
            cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["id"].ToString();
                textBox2.Text = reader["name"].ToString();
                textBox3.Text = reader["price"].ToString();
                txtGender.Text = reader["gender"].ToString();
            }
            MessageBox.Show("조회되었습니다.", "조회", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {   //등록버튼
            string value1, value2, value3, value4;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;
            value4 = txtGender.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "insert into tbShoes " +
                " values ( '" + value1 + "', N'" + value2 + "', '" + value3 + "', '" + value4 + "' )";
            cmd.ExecuteNonQuery();      // insert, update, delete문에 사용합니다.
            GridRetrival();             // DataGridView에 새로 입력된 데이터를 반영하기 위한 조회 함수입니다.

            MessageBox.Show("등록되었습니다.", "신규등록", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            textBox1_Click(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false; radioButton2.Checked = false;
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; txtGender.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {   //수정버튼
            string value1, value2, value3, value4;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;
            value4 = txtGender.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "update tbShoes " +
                " set id = '" + value1 + "', " +
                " name = N'" + value2 + "', " +
                " price = '" + value3 + "', " + 
                " gender = '" + value4 + "' " + //컴마 (,)없음. 주의할것!!
                " where id = '" + value1 + "' ";
            cmd.ExecuteNonQuery();  //insert, update, delete문에 사용하는 메소드
            GridRetrival();

            MessageBox.Show("수정되었습니다.", "변경확인", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            textBox1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {    //삭제버튼
            string value1 = textBox1.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "delete from tbShoes " +
                " where id = '" + value1 + "' ";
            cmd.ExecuteNonQuery();
            GridRetrival();

            MessageBox.Show("삭제되었습니다.", "삭제", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            textBox1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {   // 종료 버튼
            this.Close();
        }

        private void 주문ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtGender.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtGender.Text = radioButton2.Text;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string col = e.ColumnIndex.ToString();

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGender.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void 주문하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(con);
            frm2.Show();
        }

        private void 구매내역ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(con);
            frm3.Show();
        }

        private void eventToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(con);
            frm4.Show();
        }
    }
}
