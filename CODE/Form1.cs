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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection SqlConnection()
        {
            string StrConnect = "Server=DESKTOP-6SMEV2F\\SQLEXPRESS;Database=HistoryDB;User ID=sa;Password=sql";
            SqlConnection SqlConnection;
            SqlConnection = new SqlConnection(StrConnect);
            return SqlConnection;
        }

        public bool addHistory(string id, string firstName, string lastName, int codeProvince)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "INSERT INTO [History] ([id], [firstName], [lastName], [codeProvince]) VALUES (@id, @firstName, @lastName, @codeProvince)";
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Parameters.AddWithValue("@firstName", firstName);
            SqlCommand.Parameters.AddWithValue("@lastName", lastName);
            SqlCommand.Parameters.AddWithValue("@codeProvince", codeProvince);
            SqlCommand.Connection = SqlConnection;
            try
            {
                SqlConnection.Open();
                SqlCommand.ExecuteNonQuery();
                SqlConnection.Close();
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.addHistory(textBox1.Text, textBox2.Text,textBox3.Text,int.Parse(textBox4.Text))){
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
            }else{
                MessageBox.Show("เพิ่มข้อมูลล้มเหลว");
            }

        }
    }
}
