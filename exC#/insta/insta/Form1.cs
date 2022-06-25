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

namespace insta
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
            //DB연결
            string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C#\\insta\\insta\\insta.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(conStr);
            GridRetrival();
        }

        private void GridRetrival()
        {
            sql = "select * from tbMember";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table.DefaultView;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'instaDataSet.tbMember' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbMemberTableAdapter.Fill(this.instaDataSet.tbMember);

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

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {   //등록버튼
            string value1, value2, value3;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "insert into tbMember " +
                " values ( '" + value1 + "', N'" + value2 + "', '" + value3 + "' )";
            cmd.ExecuteNonQuery();      // insert, update, delete문에 사용합니다.
            GridRetrival();             // DataGridView에 새로 입력된 데이터를 반영하기 위한 조회 함수입니다.

            MessageBox.Show("등록되었습니다.", "신규등록", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            textBox1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {   //수정버튼
            string value1, value2, value3;
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            value3 = textBox3.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "update tbMember " +
                " set id = '" + value1 + "', " +
                " name = N'" + value2 + "', " +
                " pwd = '" + value3 + "', " +
                " email = '" + value4 + "' " + //컴마 (,)없음. 주의할것!!
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

            cmd.CommandText = "delete from tbMember " +
                " where id = '" + value1 + "' ";
            cmd.ExecuteNonQuery();
            GridRetrival();

            MessageBox.Show("삭제되었습니다.", "삭제", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            textBox1_Click(sender, e);
        }

        private void 회원정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(con);
            frm2.Show();
        }
    }
}
