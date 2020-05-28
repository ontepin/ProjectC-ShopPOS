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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 llog = new Form1();
            llog.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 member = new Form6();
            member.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 sale = new Form4();
            sale.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 sh = new Form7();
            sh.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string sql = "";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            showdataproduct();
        }
        private void showdataproduct() //ฟังก์ชั่นแสดงข้อมูลสินค้า
        {
            string sql = "SELECT* FROM product";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "product");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "product";
        }
        private void clearproduct()//เคลียร์ข้อมูล
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button8_Click(object sender, EventArgs e)//ปุ่มบันทึกข้อมูลสินค้า
        {
            string sql = "INSERT INTO product ( p_id , p_name , unitprice , unitinstock ) VALUES ('" + textBox1.Text.Trim() + "' , '" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "')";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdataproduct();
            clearproduct();

            MessageBox.Show("คุณได้เพิ่มข้อมูลเรียบร้อยแล้ว");
        }



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox1.Enabled = false;
        }
        private void button10_Click(object sender, EventArgs e) //ปุ่มแก้ไขข้อมูลสินค้า 
        {
            string sql = "UPDATE product SET p_name = '" + textBox2.Text.Trim() + "' , unitprice = '" + textBox3.Text.Trim() + "' , unitinstock = '" +textBox4.Text.Trim()+"' WHERE p_id = '" + textBox1.Text.Trim() + "' ";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdataproduct();
            clearproduct();

            MessageBox.Show("คุณได้แก้ไขข้อมูลเรียบร้อยแล้ว");
        }

        private void button9_Click(object sender, EventArgs e) //ปุ่มลบข้อมูลสินค้า
        {
            string sql = "DELETE FROM product WHERE p_id ='" + textBox1.Text.Trim() + "'";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdataproduct();
            clearproduct();

            MessageBox.Show("คุณได้ลบข้อมูลเรียบร้อยแล้ว");
        }
    }
}
