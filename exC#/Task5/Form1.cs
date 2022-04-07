using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        BookList bkList;
        public Form1()
        {
            InitializeComponent();
            bkList = new BookList();

            // 데이터 동적생성문제 해결
            bkList.addBook("윈도우즈 프로그래밍", "홍길동", "경성출판사");
            bkList.addBook("자바 프로그래밍", "이둘둘", "남구출판사");

            foreach (Book i in bkList)
            {
                listBox1.Items.Add(i.Title);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int index = listBox1.SelectedIndex;

            if (index > -1 && index < bkList.Count)
            {
                Book b = (Book)bkList[index];
                listBox2.Items.Add("저자 : " + b.Author);
                listBox2.Items.Add("출판사 : " + b.Publisher);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   // 도서추가버튼
            Book b = new Book(textBox1.Text, textBox2.Text, textBox3.Text);
            bkList.addBook(textBox1.Text, textBox2.Text, textBox3.Text); // == bkList.Add(b);
            listBox1.Items.Add(b.Title);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {   // 도서삭제버튼
            int index = listBox1.SelectedIndex;
            if (index > -1)
            {
                bkList.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
                listBox2.Items.Clear();
            }
        }
    }

    class BookList : ArrayList
    {
        public int addBook(string inTitle, string inAuthor, string inPublisher)
        {
            return base.Add(new Book(inTitle, inAuthor, inPublisher));
        }
    }

    class Book
    {
        private string title;       //도서명
        private string author;      //저자명
        private string publisher;   //출판사

        //생성자의 선언: 객체를 초기화하는 목적.
        public Book(string title, string author, string publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public String Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
    }
}
