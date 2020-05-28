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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //ส่งคำขอ
        {
            
            string sql = "INSERT INTO admin (ad_user , ad_pass , ad_name) VALUES ('"+textBox1.Text.Trim()+"','"+textBox2.Text.Trim()+"','"+textBox3.Text.Trim()+"')";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear(); 
            MessageBox.Show("คุณได้ส่งคำขอเรียบร้อยแล้ว");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 llog = new Form1();
            llog.Show();
        }
    }
}
