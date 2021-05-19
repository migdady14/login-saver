using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSaver.DAL
{
    class LoginDaoCommands
    {
        public bool valid = false;
        public String message = "";
        SqlCommand cmd = new SqlCommand();
        Connection con = new Connection();
        SqlDataReader dr;

        public bool VerifyLogin(String login, String password)
        {
            // SQL method to verify if data is inside the bank
            cmd.CommandText = "SELECT * FROM userData WHERE email = @login AND password = @password";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                cmd.Connection = con.Connect();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    valid = true;
                }
                con.Disconnect();
                dr.Close();
            }
            catch (SqlException)
            {
                this.message = "Data Bank Error!";
            }
            return valid;
        }

        public String Register(String email, String password, String confPass)
        {
            valid = false;

            // SQL Method to add new data to the bank
            if (password.Equals(confPass))
            {
                cmd.CommandText = "INSERT INTO userData values (@e, @p);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", password);

                try
                {
                    cmd.Connection = con.Connect();
                    cmd.ExecuteNonQuery();
                    con.Connect();
                    this.message = "Successful Registration!";
                    valid = true;
                }
                catch (SqlException)
                {
                    this.message = "Data Bank error!";
                }
            }
            else
            {
                this.message = "Passwords do not match!";
            }
            return message;
        }

    }
}
