using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormEx1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   // 주문하기 버튼
            int sum = 0;
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            if (rb1.Checked == true)
            {
                listBox1.Items.Add("불고기 피자");
                listBox2.Items.Add("30000");
                sum += 30000;
            }
            if (rb2.Checked == true)
            {
                listBox1.Items.Add("콤비네이션 피자");
                listBox2.Items.Add("35000");
                sum += 35000;
            }
            if (cb1.Checked == true)
            {
                listBox1.Items.Add("콜 라");
                listBox2.Items.Add("1000");
                sum += 1000;
            }
            if (cb2.Checked == true)
            {
                listBox1.Items.Add("쥬 스");
                listBox2.Items.Add("2000");
                sum += 2000;
            }
            if (cb3.Checked == true)
            {
                listBox1.Items.Add("커 피");
                listBox2.Items.Add("3000");
                sum += 3000;
            }
            lblSum.Text = sum.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
