using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormEx2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
         //   lblDate.Text = e.Start.Date.ToString();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            lblDate.Text = e.Start.Date.ToShortDateString(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox1.SelectedIndex.ToString(); 
            pictureBox1.Load("pizza" + index + ".jpg");
        }

        private void btnSum_Click(object sender, EventArgs e)
        {   // 합계보기 버튼
            int i, price, sum = 0;
            listBox1.Items.Clear();
            string index = comboBox1.SelectedIndex.ToString();
            if (index == "0")
                listBox1.Items.Add("30000");
            else if (index == "1")
                listBox1.Items.Add("35000");
            else if (index == "2")
                listBox1.Items.Add("40000");

            string[] ArrPrice = { "5000", "3000" };
            for (i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                    listBox1.Items.Add(ArrPrice[i]);
            }

            int count = listBox1.Items.Count;
            for (i = 0; i < count; i++)
            {
                price = Convert.ToInt32(listBox1.Items[i].ToString());
                sum += price;
            }
            maskedTextBox1.Text = sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
