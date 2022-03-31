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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = comboBox1.SelectedIndex.ToString();
            if (index == "0")
                webBrowser1.Navigate("http://www.kyobobook.co.kr/");
            else if (index == "1")
                webBrowser1.Navigate("https://www.naver.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {   // 종료버튼
            this.Close();
        }
    }
}
