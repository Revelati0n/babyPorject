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
    public partial class Userinformation : Form
    {
        SqlClass SqlFucntion = new SqlClass();
        public string ID, FirstName, LastName;
        public int Province;
        public Userinformation()
        {
            InitializeComponent();
        }

        public void loadInfo()
        {            
            SqlDataReader UserDataReader = SqlFucntion.getUserInfo(ID);
            SqlDataReader Provinces = SqlFucntion.getProvinces();
            while (Provinces.Read())
            {
                comboBox1.Items.Add(Provinces["nameProvince"].ToString());
            }
            textBox1.Text = FirstName;
            textBox2.Text = LastName;
            FirstName = UserDataReader["firstName"].ToString();
            LastName = UserDataReader["lastName"].ToString();
            Province = int.Parse(UserDataReader["codeProvince"].ToString());
            textBox1.Text = FirstName;
            textBox2.Text = LastName;
            comboBox1.SelectedIndex = (Province - 1);
            label1.Text = "ID: " + ID;

        }

        private void Userinformation_Load(object sender, EventArgs e)
        {

        }

        bool isEdit = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {                
                textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = true;
                button1.Text = "Save";
                button2.Text = "Cancel";
            }
            else
            {
                if (SqlFucntion.userChangeProfile(ID, textBox1.Text, textBox2.Text, comboBox1.SelectedIndex))
                {
                    loadInfo();
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "ดำเนินการสำเร็จ");
                    textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = false;
                    button1.Text = "Edit";
                    button2.Text = "Logout";
                }
                else
                {
                    MessageBox.Show("แก้ไขข้อมูลล้มเหลว", "ดำเนินการล้มเหลว");
                }
            }
            isEdit = !isEdit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = false;
                button1.Text = "Edit";
                button2.Text = "Logout";
                isEdit = !isEdit;
            }
            else
            {
                this.Close();
                (new Form1()).Show();
            }
        }
    }
}
