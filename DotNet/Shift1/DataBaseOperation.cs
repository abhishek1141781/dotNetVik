using Microsoft.Data.SqlClient;
using Shift1.Models;

namespace Shift1
{
    public class DataBaseOperation
    {
        private static SqlConnection Connection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=shift1;Integrated Security=True;";
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

            while(dr.Read())
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

        public static void AddEmployee(CreateEmployee emp)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Employees values(@Name,@City,@Address)";

           
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Address", emp.Address);

            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteEmployee(int id)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete from Employees where Id=@Id";

            cmd.Parameters.AddWithValue("@Id", id);

            cn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
