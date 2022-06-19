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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        string sql;
        public Form2(SqlConnection con)
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

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'bookDBDataSet.tbBook' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.tbBookTableAdapter.Fill(this.bookDBDataSet.tbBook);

        }

        private void button1_Click(object sender, EventArgs e)
        {   // 조회 버튼
            string value1 = comboBox1.Text + "%";
            sql = "select * from tbBook " +
                " where class like N'" + value1 + "' ";
            GridRetrival(sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string col = e.ColumnIndex.ToString();
            string image = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            try
            {
                pictureBox1.Load(image + ".jpg");  //project폴더/bin/debug

            }
            catch (Exception ex)
            {
                pictureBox1.Load("blank.jpg");
            }
        }
    }
}
