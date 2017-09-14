using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        SqlClass SqlFucntion = new SqlClass();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            SqlClass SqlFucntion = new SqlClass();

            if (SqlFucntion.checkUserLogin(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ", "ดำเนินการสำเร็จ");
                Userinformation Userinformation = new Userinformation();
                Userinformation.ID = textBox1.Text;
                Userinformation.loadInfo();
                Userinformation.Show();
                button2.Enabled = true;
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("เข้าสู่ระบบล้มเหลว", "ดำเนินการล้มเหลว");
                button2.Enabled = true;
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new Form1()).Show();
        }

    }
}
