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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        string sql;
        public Form2(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            lblDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void GridRetrival()
        {
            sql = "select * from tbAnimal";
            cmd = new SqlCommand(sql, con);
            adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table.DefaultView;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'animalShopDataSet4.tbShop' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbShopTableAdapter.Fill(this.animalShopDataSet4.tbShop);
            // TODO: 이 코드는 데이터를 'animalShopDataSet1.tbAnimal' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbAnimalTableAdapter.Fill(this.animalShopDataSet1.tbAnimal);

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            lblDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {   // 가격보기 버튼
            string value1 = comboBox1.SelectedValue.ToString();

            sql = " select * from tbShoes " +        // * => id, name, price
                " where id = '" + value1 + "' ";
            cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtPrice.Text = reader[2].ToString();
            }

            int price = Int32.Parse(txtCnt.Text) * Int32.Parse(txtPrice.Text);
            lblSum.Text = price.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {    // 등록버튼
            string value1, value2, value3, value4, value5, value6;

            value1 = textBox1.Text;
            value2 = comboBox1.Text;
            value3 = txtCnt.Text;
            value4 = lblSum.Text;
            value5 = comboBox2.Text;
            value6 = lblDate.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "insert into tbAnimal " +
                " values ( '" + value1 + "', N'" + value2 + "', '" + value3 + "', '" + value4 + "', N'" + value5 + "', '" + value6 + "' ) ";
            cmd.ExecuteNonQuery();

            GridRetrival();
            MessageBox.Show("등록되었습니다.");
            textBox1_Click(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; comboBox1.Text = "";
            txtCnt.Text = ""; txtPrice.Text = ""; lblSum.Text = ""; comboBox2.Text = "";
            pictureBox1.Load("blank.jpg");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCnt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblSum.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            // dataGridView1 선택시 이미지 연결하기
            string index = textBox1.Text.Trim();
            pictureBox1.Load(index + ".jpg");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = ""; txtCnt.Text = ""; lblSum.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {   //수정버튼
            string value1, value2, value3, value4, value5, value6;

            value1 = textBox1.Text;
            value2 = comboBox1.Text;
            value3 = txtCnt.Text;
            value4 = lblSum.Text;
            value5 = comboBox2.Text;
            value6 = lblDate.Text;

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            cmd.CommandText = "update tbAnimal " +
                " set id = '" + value1 + "', " +
                " name = N'" + value2 + "', " +
                " cnt = '" + value3 + "', " +
                " amount = '" + value4 + "', " +
                " paycode = '" + value5 + "', " +
                " orderDate = '" + value6 + "' " + //컴마 (,)없음. 주의할것!!
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

            cmd.CommandText = "delete from tbAnimal " +
                " where id = '" + value1 + "' ";
            cmd.ExecuteNonQuery();
            GridRetrival();

            MessageBox.Show("삭제되었습니다.", "삭제", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            textBox1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {   // 조회 버튼
            sql = "select * from tbShop " +
                " where id = '" + textBox1.Text + "' ";
            cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["id"].ToString();
                comboBox1.Text = reader["name"].ToString();
                txtPrice.Text = reader["price"].ToString();
            }
            MessageBox.Show("조회되었습니다.", "조회", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private void button6_Click(object sender, EventArgs e)
        {   // 종료 버튼
            this.Close();
        }
    }
}
