using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1
{
    public class DatabaseOperations
    {
        SqlConnection cn = null;
        public DatabaseOperations()
        {
            cn = new SqlConnection(" Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ActsJune23; Integrated Security = True;");
        }

        public void InsertUser(CreateUser user)
        {
            SqlCommand cmd = new SqlCommand("[dbo].AddUserData", cn);
            cmd.Parameters.AddWithValue("@AadharId", user.AadharId);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }
    }
}
