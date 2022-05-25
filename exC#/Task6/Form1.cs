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

namespace exDB1
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
            // DB 연결
            string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\exCS\\myDB1.mdf;Integrated Security=True;Connect Timeout=30";
            
            con = new SqlConnection(conStr);
            cmd = new SqlCommand(sql, con);
            GridRetrival();
        }

        public void GridRetrival()
        {
            sql = "select * from TBstudent ";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table.DefaultView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'myDBDataSet.TBstudent' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tBstudentTableAdapter.Fill(this.myDBDataSet.TBstudent);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 조회 버튼
            sql = "select * from TBstudent  " +
                " where id = '" + textBox1.Text + "' ";
            cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();
            
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["id"].ToString();
                textBox2.Text = reader["name"].ToString();
                textBox3.Text = reader["score"].ToString();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();       // 아래와 같은 코드
            textBox2.Text = ""; textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 종료 버튼
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string col = e.ColumnIndex.ToString();

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 등록버튼
            string value1, value2, value3;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "insert into TBstudent    " +
                " values ( '" + value1 + "', N'" + value2 + "', '" + value3 + "' )";

            cmd.ExecuteNonQuery(); // insert, update, delete문에 사용하기 위한 메소드
            GridRetrival();

            MessageBox.Show("등록 되었습니다.");
            textBox1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 삭제버튼
            string value1;
            value1 = textBox1.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "delete from TBstudent " + 
                " where id = '" + value1 + "' ";

            cmd.ExecuteNonQuery(); // insert, update, delete문에 사용하기 위한 메소드
            GridRetrival();

            MessageBox.Show("삭제 되었습니다.");
            textBox1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {   // 수정버튼
            string value1, value2, value3;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "update TBstudent " +
                " set id = '" + value1 + "', " +
                " name = N'" + value2 + "', " +
                " score = '" + value3 + "' " + // 컴마(,) 없음. 주의할 것!
                " where id = '" + value1 + "' ";

            cmd.ExecuteNonQuery(); // insert, update, delete문에 사용하기 위한 메소드
            GridRetrival();

            MessageBox.Show("수정 되었습니다.");
            textBox1_Click(sender, e);
        }
    }
}
