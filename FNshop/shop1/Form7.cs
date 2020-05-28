using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace shop1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e) //ปุ่มปิดโปรแกรม
        {
            Application.Exit();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 sale = new Form4();
            sale.Show();
        }
        private void label10_Click(object sender, EventArgs e) //ปุ่มออกจากระบบ
        {
            this.Hide();
            Form1 llog = new Form1();
            llog.Show();
        }


        private void Form7_Load(object sender, EventArgs e) //เชื่อมต่อฐานข้อมูล
        {
            string sql = "";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 stork = new Form5();
            stork.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 member = new Form6();
            member.Show();
        }

        private void button9_Click(object sender, EventArgs e)//ปุ่มค้นหาลูกค้า
        {
            string sql = "SELECT c_id , c_name , c_IDcard , c_phone FROM costumer WHERE c_id = '" + textBox5.Text.Trim() + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "costumer");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "costumer";
        }

        private void button3_Click(object sender, EventArgs e)//ปุ่มค้นหาพนักงาน
        {
            string sql = "SELECT m_id , m_name , m_IDcard , m_phone , m_status FROM memberpro WHERE m_id = '" + textBox1.Text.Trim() + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "memberpro");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "memberpro";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "SELECT p_id , p_name , unitprice , unitinstock FROM product WHERE p_name = '" + textBox2.Text.Trim() + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "product");
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "product";
        }
    }
}
