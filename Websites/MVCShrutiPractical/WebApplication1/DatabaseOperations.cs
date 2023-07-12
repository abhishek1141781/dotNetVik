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
            cn = new SqlConnection(" Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = acts; Integrated Security = True;");
           
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
        
        
        //for getting details of all users in the list
        public List<CreateUser> GetUsers() 
        { 
        SqlCommand cmd = new SqlCommand("select * from [dbo].getAllUsers()",cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<CreateUser> users = new List<CreateUser>();
            if(dr!=null) 
            {
                DataTable dt = new DataTable();
                dt.Load(dr);

                for(int i=0; i<dt.Rows.Count; i++) 
                {   
                    CreateUser user = new CreateUser();
                    user.AadharId= dt.Rows[i]["AadharId"].ToString();
                    user.Email = dt.Rows[i]["Email"].ToString();
                    user.Name = dt.Rows[i]["Name"].ToString();
                    user.Password = dt.Rows[i]["Password"].ToString();
                    users.Add(user);
                }
            }
            cn.Close();
            cn.Dispose();
            return users;
        }


        //Get single user details by Aadhar Number
        public CreateUser GetSingleUser(string userid)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].FindUser(@AadharId)", cn);
            cmd.Parameters.AddWithValue("@AadharId", userid);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            CreateUser user = new CreateUser();

            if(dr!=null)
            {
                dr.Read();
                user.AadharId = dr["AadharId"].ToString();
                user.Name = dr["Name"].ToString();
                user.Email = dr["Email"].ToString();
                user.Password= dr["Password"].ToString();
            }
           
            cn.Close();
            cn.Dispose();
            return user;
        }


        public void UpdateUser(string id, CreateUser user)
        {
            SqlCommand cmd = new SqlCommand("[dbo].UpdateUserData", cn);
            cmd.Parameters.AddWithValue("@AadharId", id);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();       
            cmd.ExecuteNonQuery();
            cn.Close() ;
            cn.Dispose() ;
          

        }


        public void DeleteUser(string id)
        {
            SqlCommand cmd = new SqlCommand("[dbo].DeleteUserData", cn);
            cmd.Parameters.AddWithValue("@AadharId", id);
            cmd.CommandType= CommandType.StoredProcedure;   

            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();

        }
    }
}
