using b3.Models;
using Microsoft.Data.SqlClient;

namespace b3
{
    public class DbOperations
    {
        private static SqlConnection Connection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b3;Integrated Security=True;";
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
                    StudentNo = (int)dr["StudentNo"],
                    Name = (String)dr["Name"],
                    Section = (String)dr["Section"],
                    Branch = (String)dr["Branch"],
                    EmailId = (String)dr["EmailId"]
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
            cmd.CommandText = "select * from Students where StudetNo=@StudentNo";
            cmd.Parameters.AddWithValue("@StudentNo", id);

            cn.Open();
            Student s = null;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                s = new Student
                {
                    StudentNo = (int)dr["StudentNo"],
                    Name = (String)dr["Name"],
                    Section = (String)dr["Section"],
                    Branch = (String)dr["Branch"],
                    EmailId = (String)dr["EmailId"]
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
            cmd.CommandText = "insert into Students(Name,Section,Branch,EmailId) values(@Name,@Section,@Branch,@EmailId)";

            //cmd.Parameters.AddWithValue("@StudentNo", student.StudentNo);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Section", student.Section);
            cmd.Parameters.AddWithValue("@Branch", student.Branch);
            cmd.Parameters.AddWithValue("@EmailId", student.EmailId);
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
            cmd.CommandText = "update Students set Name=@Name,Section=@Section,Branch=@Branch, EmailId=@EmailId where StudentNo=@StudentNo";

            cmd.Parameters.AddWithValue("@StudentNo", student.StudentNo);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Section", student.Section);
            cmd.Parameters.AddWithValue("@Branch", student.Branch);
            cmd.Parameters.AddWithValue("@EmailId", student.EmailId);

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
            cmd.CommandText = "Delete from Students where StudentNo=@StudentNo";

            cmd.Parameters.AddWithValue("@StudentNo", id);

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
