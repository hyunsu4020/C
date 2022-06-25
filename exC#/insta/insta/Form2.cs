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

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'instaDataSet1.tbProfile' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbProfileTableAdapter.Fill(this.instaDataSet1.tbProfile);

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            lblDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {   // 회원정보 보기 버튼
            string value1 = comboBox1.SelectedValue.ToString();

            sql = " select * from tbMember " +        // * => id, name, pwd, email
                " where id = '" + value1 + "' ";
            cmd = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Open) con.Close();
            if (con.State == ConnectionState.Closed) con.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtPrize.Text = reader[2].ToString();
            }

            int price = Int32.Parse(txtCnt.Text) * Int32.Parse(txtPrize.Text);
            lblSum.Text = price.ToString();
        }
    }
}
