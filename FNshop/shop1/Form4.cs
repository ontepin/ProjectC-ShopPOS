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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)//ปุ่มปิดโปรแกรม
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)//ปุ่มออกจากระบบ
        {
            this.Hide();
            Form1 llog = new Form1();
            llog.Show();
        }

        private void button4_Click(object sender, EventArgs e)//ปุ่มบุคลากร
        {
            this.Hide();
            Form6 member = new Form6();
            member.Show();
        }

        private void button5_Click(object sender, EventArgs e)//ปุ่มคลังสินค้า
        {
            this.Hide();
            Form5 stork = new Form5();
            stork.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string sql = "";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            //แสดงข้อมูลในลิสวิว
            listView1.Columns.Add("รหัสสินค้า", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("ชื่อสินค้า", 180, HorizontalAlignment.Center);
            listView1.Columns.Add("ราคาขาย", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("จำนวน", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("รวมเงิน", 80, HorizontalAlignment.Center);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            textBox1.Focus();
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//ป้อนรหัสลูกค้า
        {
            if (e.KeyChar < '0' || e.KeyChar > '9' )
            {
                e.Handled = true;
            }
            string sql = "SELECT c_name , c_phone FROM costumer WHERE c_id = '" + textBox1.Text.Trim() + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "costumer");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "costumer";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)//ส่งข้อมูลชื่อลูกค้ามาtextbox
        {
            if (e.RowIndex == -1) return;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)//ป้อนรหัสสินค้า
        {

            string sql = "SELECT p_name , unitprice , unitinstock FROM product WHERE p_id = '" + textBox3.Text.Trim() + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, "product");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "product";
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)//ส่งข้อมูลไปในส่วนสินค้า
        {
            if (e.RowIndex == -1) return;
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void caluatetotal()
        {
            double total;
            total = (double.Parse(textBox6.Text)) * int.Parse(textBox7.Text);
            textBox8.Text = total.ToString("#,##0.00");
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)//ป้อนจำนวนที่ซื้อแล้วคำนวณราคารวม
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            caluatetotal();
            textBox4.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)//ปุ่มเพิ่มรายการ
        {
            if ((textBox3.Text.Trim() == "") || (textBox5.Text.Trim()== ""))
            {
                textBox3.Focus();
                return;
            }
            if (int.Parse(textBox7.Text)==0)

            {
                textBox7.Focus();
                return;
            }
            int i = 0;
            ListViewItem lvi;
            string tmpproductID ;
            for (i=0;i <= listView1.Items.Count - 1;i++)
            {
                tmpproductID = listView1.Items[i].SubItems[0].Text;
                if(textBox3.Text.Trim() == tmpproductID)
                {
                    MessageBox.Show("คุณเลือกข้อมูลสินค้าซ้ำกัน");
                    textBox3.Focus();
                    textBox3.SelectAll();
                    return;
                }
            }
            string[] anydata;
            anydata = new string[]
            {
                textBox3.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text
            };
            lvi = new ListViewItem(anydata);
            listView1.Items.Add(lvi);
            net();
            button2.Enabled = true;
            textBox3.Focus();
            textBox3.SelectAll();


        }
        private void net()//ฟังชั่นราคารวม
        {
            int i = 0;
            double tmpnettotal = 0;
            for (i=0;i <= listView1.Items.Count - 1;i++)
            {
                tmpnettotal += double.Parse(listView1.Items[i].SubItems[4].Text);
            }
            textBox9.Text = tmpnettotal.ToString("#,##00.00");
        }

        private void button3_Click(object sender, EventArgs e)//ปุ่มเคลียร์
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Clear();
            comboBox1.Text = "";


        }

        private void listView1_DoubleClick(object sender, EventArgs e)//เคลียร์ข้อมูลสินค้าในลิสวิว
        {
            int i = 0;
            for (i=0;i<=listView1.SelectedItems.Count -1;i++)
            {
                ListViewItem lvi;
                lvi = listView1.SelectedItems[i];
                listView1.Items.Remove(lvi);
            }
            net();
            textBox3.Focus();
            textBox5.Clear();
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)//ปุ่มบันทึกข้อมูลการขาย
        {


            MySqlConnection con = new MySqlConnection("host=localhost;username=test;password=0000;database=projectsale1");

            con.Open();

            int i = 0;
            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                string sql = "INSERT INTO orderpro ( c_id , m_name , p_id , p_name , unitprice , unitcount , unittotal ) VALUES ('" + textBox1.Text.Trim() + "' , '" + comboBox1.Text.Trim() + "','" + listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','"+ listView1.Items[i].SubItems[2].Text + "','"+ listView1.Items[i].SubItems[3].Text + "','"+ listView1.Items[i].SubItems[4].Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("บันทึกการขายเรียบร้อย");

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 sh = new Form7();
            sh.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            printDocument1.Print();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("ใบเสร็จรับเงิน", new Font("BoonJot", 20, FontStyle.Bold), Brushes.Gray, new PointF(370, 50));//ข้อความใบเสร็จรับเงิน
            e.Graphics.DrawString(" F N S H O P ", new Font("BoonJot", 40, FontStyle.Italic), Brushes.Gray, new PointF(270, 100));//ชื่อร้าน

            Bitmap objbmp = new Bitmap(this.listView1.Width, this.listView1.Height);//แสดงรายการสินค้า
            listView1.DrawToBitmap(objbmp, new Rectangle(0, 0, this.listView1.Width, this.listView1.Height));
            e.Graphics.DrawImage(objbmp,200, 200);

            e.Graphics.DrawString("ราคารวมทั้งสิ้น", new Font("BoonJot",10, FontStyle.Bold), Brushes.Gray, new PointF(210, 430));//แสดงข้อความ
            e.Graphics.DrawString(textBox9.Text, new Font("BoonJot",10, FontStyle.Bold), Brushes.Gray, new PointF(300, 430));//แสดงราคารวมจากtextbox
            e.Graphics.DrawString("บาท", new Font("BoonJot", 10, FontStyle.Bold), Brushes.Gray, new PointF(380, 430));//บาท
        }
    }
}
