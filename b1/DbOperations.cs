using b1.Models;
using Microsoft.Data.SqlClient;

namespace b1
{
    public class DbOperations
    {
        private static SqlConnection Connection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db;Integrated Security=True;";
            return cn;
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees";
            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                list.Add(new Employee
                {
                    Id = (int)dr["Id"],
                    Name = (String)dr["Name"],
                    City = (String)dr["City"],
                    Address = (String)dr["Address"]
                });
            }
            
            return list;
        }

        public static void EditEmployee(Employee employee)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Employees set Name=@Name,City=@City,Address=@Address where Id=@Id";

            cmd.Parameters.AddWithValue("@Id", employee.Id);
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@City", employee.City);
            cmd.Parameters.AddWithValue("@Address", employee.Address);

            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            { 
                cn.Close();
                cn.Dispose();
            }
        }

        public static Employee GetEmployee(int id)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cn.Open();
            Employee s = null;
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                s = new Employee
                {
                    Id = (int)dr["Id"],
                    Name = (String)dr["Name"],
                    City = (String)dr["City"],
                    Address = (String)dr["Address"]
                };
            }
            return s;
        }
    }
}
