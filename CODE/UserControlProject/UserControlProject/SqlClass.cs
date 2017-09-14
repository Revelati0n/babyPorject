using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace WindowsFormsApplication1
{
    class SqlClass
    {
        private SqlConnection SqlConnection()
        {
            //string StrConnect = "Server=DESKTOP-6SMEV2F\\SQLEXPRESS;Database=HistoryDB;User ID=sa;Password=sql";
            string StrConnect = "Server=(local);Database=HistoryDB;User ID=sa;Password=sql";
            SqlConnection SqlConnection;
            SqlConnection = new SqlConnection(StrConnect);
            return SqlConnection;
        }

        /*
         @return true/false
        */

        public bool addUserToDatabse(string id, string Password, string FirstName, string LastName, int Province)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "INSERT INTO [History] ([id], [passWord], [firstName], [lastName], [codeProvince]) VALUES (@id, @Password, @FirstName, @LastName, @Province)";
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Parameters.AddWithValue("@Password", Password);
            SqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            SqlCommand.Parameters.AddWithValue("@LastName", LastName);
            SqlCommand.Parameters.AddWithValue("@Province", (Province + 1));
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

        /*
         @return true/false
        */

        public bool checkUserLogin(string id, string Password)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT * FROM [History] WHERE [id] = @id AND [Password] = @Password";
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Parameters.AddWithValue("@Password", Password);
            SqlCommand.Connection = SqlConnection;
            try
            {
                SqlConnection.Open();
                int num = 0;                
                num = Convert.ToInt32(SqlCommand.ExecuteScalar());
                SqlConnection.Close();
                if (num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {              
                Console.WriteLine(Ex.ToString());
                return false;
            }
        }

        /*
         @return sqlDataReader
        */

        public SqlDataReader getUserInfo(string id)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT [id], [FirstName] ,[LastName], [codeProvince] FROM [History] WHERE [id] = @id";
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Connection = SqlConnection;
            SqlConnection.Open();
            SqlDataReader SqlDataReader = SqlCommand.ExecuteReader();
            SqlDataReader.Read();
            return SqlDataReader;
        }
        
        public SqlDataReader getProvinces()
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT [nameProvince] FROM [Provinces]";
            SqlCommand.Connection = SqlConnection;
            SqlConnection.Open();
            SqlDataReader SqlDataReader = SqlCommand.ExecuteReader();
           
            return SqlDataReader;
        }
        /*
         @return true/false
        */

        public bool userChangePassword(string id, string oldPassword, string newPassword)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "UPDATE [History] SET [Password] = @newPassword WHERE [id] = @id AND [Password] = @oldPassword";
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Parameters.AddWithValue("@newPassword", newPassword);
            SqlCommand.Parameters.AddWithValue("@oldPassword", oldPassword);
            SqlCommand.Connection = SqlConnection;
            SqlConnection.Open();            
            if (SqlCommand.ExecuteNonQuery() > 0)
            {
                SqlConnection.Close();
                return true;
            }
            else
            {
                SqlConnection.Close();
                return false;
            }
        }
        public bool userChangeProfile(string id, string FirstName, string LastName, int Province)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "UPDATE [History] SET [firstName] = @FirstName, [lastName] = @LastName, [codeProvince] = @Province WHERE [id] = @id";
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            SqlCommand.Parameters.AddWithValue("@LastName", LastName);
            SqlCommand.Parameters.AddWithValue("@Province", (Province + 1));
            SqlCommand.Connection = SqlConnection;
            SqlConnection.Open();
            if (SqlCommand.ExecuteNonQuery() > 0)
            {
                SqlConnection.Close();
                return true;
            }
            else
            {
                SqlConnection.Close();
                return false;
            }
        }
    }
}