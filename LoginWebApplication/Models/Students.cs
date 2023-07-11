using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginWebApplication.Models
{
    public class Students
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public int DeptNo { set; get; }
        public string? Password { set; get; }

        public static Students GetSingleEmployee(int id)
        {
            Students obj = new Students();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Prajwal;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Students where Id=@EmpNo ";
            cmd.Parameters.AddWithValue("@EmpNo", id);
            

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj.Id = (int)dr["Id"];
                    obj.Name = (string)dr["Name"];
                    obj.Password = (string)dr["Password"];
                    obj.DeptNo = (int)dr["DeptNo"];
                    Console.WriteLine(obj);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


            return obj;
        }


        public static Students GetSingleEmployee(StudentLogin std)
        {
            Students obj = new Students();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Prajwal;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Students where Id=@EmpNo and Password=@Password";
            cmd.Parameters.AddWithValue("@EmpNo", std.Id);
            cmd.Parameters.AddWithValue("@Password", std.Password);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj.Id = (int)dr["Id"];
                    obj.Name = (string)dr["Name"];
                    obj.Password = (string)dr["Password"];
                    obj.DeptNo = (int)dr["DeptNo"];
                    Console.WriteLine(obj);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


            return obj;
        }

    }
}
