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
    public partial class Form6 : Form
    {
        public Form6()//หน้าบุคลากร
        {
            InitializeComponent();
        }
        //ปุ่มปิดโปรแกรม
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //ปุ่มฟอร์มค้นหา
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 sh = new Form7();
            sh.Show();
        }
        //ปุ่มฟอร์มขายสินค้า
        private void button4_Click(object sender, EventArgs e)
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

        private void Form6_Load(object sender, EventArgs e)//เชื่อมฐานข้อมูล
        {
            string sql = "";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            showdatacostumer();
            showdatamember();
        }
        private void clearcostumer()//เคลียร์ข้อมูลลูกค้า
        {
            textBox11.Clear();
            textBox9.Clear();
            maskedTextBox2.Clear();
            maskedTextBox4.Clear();
        }
        private void clearmember()//เคลียร์ข้อมูลพนักงาน
        {
            textBox1.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox3.Clear();
        }
        private void showdatacostumer() //ฟังก์ชั่นแสดงข้อมูลลูกค้า
        {
            string sql = "SELECT* FROM costumer";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql,con);
            da.Fill(ds, "costumer");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "costumer";
        }
        private void showdatamember() //ฟังก์ชั่นแสดงข้อมูลพนักงาน
        {
            string sql = "SELECT* FROM memberpro";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "memberpro");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "memberpro";
        }

        private void button13_Click(object sender, EventArgs e) //ปุ่มบันทึกข้อมูลลูกค้า
        {
            string sql = "INSERT INTO costumer ( c_id , c_name , c_IDcard , c_phone ) VALUES ('" + textBox11.Text.Trim() + "' , '" + textBox9.Text.Trim() + "','" + maskedTextBox2.Text.Trim() + "','" + maskedTextBox4.Text.Trim() + "')";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql,con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdatacostumer();
            clearcostumer();

            MessageBox.Show("คุณได้เพิ่มข้อมูลเรียบร้อยแล้ว");
        }

        private void button14_Click(object sender, EventArgs e)//ปุ่มเคลียร์ข้อมูลลูกค้า
        {

        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//ส่งค่าข้อมูลลูกค้าไปที่เครื่องมือแก้ไข
        {
            if (e.RowIndex == -1) return;
            textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            maskedTextBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            maskedTextBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox11.Enabled = false;
            maskedTextBox2.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)//ปุ่มแก้ไขข้อมูลลูกค้า
        {
            string sql = "UPDATE costumer SET c_name = '"+textBox9.Text.Trim()+"',c_phone = '"+maskedTextBox4.Text.Trim()+"' WHERE c_id = '" +textBox11.Text.Trim()+"' ";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdatacostumer();
            clearcostumer();

            MessageBox.Show("คุณได้แก้ไขข้อมูลเรียบร้อยแล้ว");
        }

        private void button12_Click(object sender, EventArgs e) //ปุ่มลบข้อมูลลูกค้า
        {
            string sql = "DELETE FROM costumer WHERE c_id ='"+textBox11.Text.Trim()+"'";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdatacostumer();
            clearcostumer();

            MessageBox.Show("คุณได้ลบข้อมูลเรียบร้อยแล้ว");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e) //ปุ่มบันทึกข้อมูลพนักงาน
        {
            string sql = "INSERT INTO memberpro ( m_name , m_IDcard , m_phone , m_status ) VALUES ('" + textBox4.Text.Trim() + "' , '" + maskedTextBox1.Text.Trim() + "','" + maskedTextBox3.Text.Trim() + "','" + comboBox1.Text.Trim() + "')";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdatamember();
            clearmember();
            MessageBox.Show("คุณได้เพิ่มข้อมูลเรียบร้อยแล้ว");
        }

        private void button10_Click(object sender, EventArgs e)//ปุ่มแก้ไขข้อมูลพนักงาน
        {
            string sql = "UPDATE memberpro SET m_name = '" + textBox4.Text.Trim() + "',m_phone = '" + maskedTextBox1.Text.Trim() + "' , m_status = '" +comboBox1.Text.Trim()+"'  WHERE m_id = '" + textBox1.Text.Trim() + "' ";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdatamember();
            clearmember();
            MessageBox.Show("คุณได้แก้ไขข้อมูลเรียบร้อยแล้ว");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) //ส่งข้อมูลพนักงานไปปุ่มแก้ไข
        {
            if (e.RowIndex == -1) return;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            maskedTextBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            maskedTextBox1.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM memberpro WHERE m_id ='" + textBox1.Text.Trim() + "'";


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();

            showdatamember();
            clearmember();
            MessageBox.Show("คุณได้ลบข้อมูลเรียบร้อยแล้ว");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 stork = new Form5();
            stork.Show();
        }
    }
   

}
