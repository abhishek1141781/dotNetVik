using AbhishekBasicMVC.Models;
using Microsoft.Data.SqlClient;

namespace AbhishekBasicMVC
{
    public class DatabaseOperations
    {
        private static SqlConnection Connection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;";
            return cn;
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();

            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Students";
            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Student
                {
                    StudId = (int)dr["StudId"],
                    Name = (String)dr["Name"],
                    Email = (String)dr["Email"],
                    City = (String)dr["City"]
                });
            }
            return list;
        }

        public static Student GetStudent(int id)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Students where StudId=@StudId";
            cmd.Parameters.AddWithValue("@StudId", id);

            cn.Open();
            Student s = null;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                s = new Student
                {
                    StudId = (int)dr["StudId"],
                    Name = (String)dr["Name"],
                    Email = (String)dr["Email"],
                    City = (String)dr["City"]
                };
            }
            return s;
        }

        public static void AddStudent(Student student)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Students values(@StudId,@Name,@Email,@City)";

            cmd.Parameters.AddWithValue("@StudId", student.StudId);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@City", student.City);

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

        public static void EditStudent(Student student)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Students set Name=@Name,City=@City,Email=@Email where StudId=@StudId";

            cmd.Parameters.AddWithValue("@StudId", student.StudId);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@City", student.City);

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

        public static void DeleteStudent(int id)
        {
            SqlConnection cn = Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete from Students where StudId=@StudId";

            cmd.Parameters.AddWithValue("@StudId", id);

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
