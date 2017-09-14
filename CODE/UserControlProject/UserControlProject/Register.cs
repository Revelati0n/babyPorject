using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Register : Form
    {

        SqlClass SqlFucntion = new SqlClass();

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
            SqlDataReader Provinces = SqlFucntion.getProvinces();
            while (Provinces.Read())
            {
                comboBox1.Items.Add(Provinces["nameProvince"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new Form1()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SqlFucntion.addUserToDatabse(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.SelectedIndex))
            {
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "ดำเนินการสำเร็จ");
            }
            else
            {
                MessageBox.Show("เพิ่มข้อมูลล้มเหลว", "ดำเนินการล้มเหลว");
            }
        }
    }
}
