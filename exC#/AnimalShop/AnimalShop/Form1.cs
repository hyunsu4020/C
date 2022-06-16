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

namespace AnimalShop
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
            string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C#\\AnimalShop\\AnimalShop\\AnimalShop.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(conStr);
            GridRetrival();
        }

        private void GridRetrival()
        {
            sql = "select * from tbShop";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table.DefaultView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'animalShopDataSet3.tbShop' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbShopTableAdapter2.Fill(this.animalShopDataSet3.tbShop);
            // TODO: 이 코드는 데이터를 'animalShopDataSet2.tbShop' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbShopTableAdapter1.Fill(this.animalShopDataSet2.tbShop);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string col = e.ColumnIndex.ToString();

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   //등록버튼
            string value1, value2, value3;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "insert into tbShop " +
                " values ( '" + value1 + "', N'" + value2 + "', '" + value3 + "' )";
            cmd.ExecuteNonQuery();      // insert, update, delete문에 사용합니다.
            GridRetrival();             // DataGridView에 새로 입력된 데이터를 반영하기 위한 조회 함수입니다.

            MessageBox.Show("등록되었습니다.", "신규등록", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            textBox1_Click(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {   //수정버튼
            string value1, value2, value3;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "update tbShop " +
                " set id = '" + value1 + "', " +
                " name = N'" + value2 + "', " +
                " price = '" + value3 + "' " + //컴마 (,)없음. 주의할것!!
                " where id = '" + value1 + "' ";
            cmd.ExecuteNonQuery();  //insert, update, delete문에 사용하는 메소드
            GridRetrival();

            MessageBox.Show("수정되었습니다.", "변경확인", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            textBox1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {   //삭제버튼
            string value1 = textBox1.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "delete from tbShop " +
                " where id = '" + value1 + "' ";
            cmd.ExecuteNonQuery();
            GridRetrival();

            MessageBox.Show("삭제되었습니다.", "삭제", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            textBox1_Click(sender, e);
        }

        private void 애완동물정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(con);
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {    // 조회 버튼
            sql = "select * from tbShop " +
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
            }
            MessageBox.Show("조회되었습니다.", "조회", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private void 구매내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(con);
            frm3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {   // 종료 버튼
            this.Close();
        }
    }
}
