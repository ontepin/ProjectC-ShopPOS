using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//ปุ่มล็อกอิน
        {
            string sql = "SELECT * FROM admin WHERE ad_user = '" + textBox1.Text + "' AND ad_pass = '" + textBox2.Text+ "'";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                this.Hide();//ปิดแท็บปัจจุบัน
                Form4 sale = new Form4();
                sale.Show();//โชว์ฟอร์ม4หน้าขายสินค้า
                MessageBox.Show("เข้าสู่ระบบเรียบร้อย");
             
            }
         }

        private void label3_Click(object sender, EventArgs e)//ไปหน้าลงทะเบียน
        {
            this.Hide();
            Form3 newadmin = new Form3();
            newadmin.Show();
        }

        private void button7_Click(object sender, EventArgs e)//ออกโปรแกรม
        {
            Application.Exit();
        }
    }
}
