using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSaver.DAL
{
    public class Connection
    {
        SqlConnection con = new SqlConnection();

        public Connection()
        {
            con.ConnectionString = @"Data Source=DESKTOP-F35GA6E\SQLEXPRESS;Initial Catalog=ProjetoLogin;Integrated Security=True";
        }

        public SqlConnection Connect()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
