using Microsoft.Data.SqlClient;
using MVCFinalBasic.Models;

namespace MVCFinalBasic
{
    public class DatabaseOperations
    {
        private static SqlConnection Connection()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;";
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
                    Divison = (String)dr["Divison"],
                    Branch = (String)dr["Branch"],
                    EmailId = (String)dr["EmailId"],
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
            cmd.CommandText = "select * from Students where StudentNo=@StudentNo";
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
                    Divison = (String)dr["Divison"],
                    Branch = (String)dr["Branch"],
                    EmailId = (String)dr["EmailId"],
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
            cmd.CommandText = "insert into Students(Name,Divison,Branch,EmailId) values(@Name,@Divison,@Branch,@EmailId)";

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Divison", student.Divison);
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
            cmd.CommandText = "update Students set Name=@Name,Divison=@Divison,Branch=@Branch, EmailId=@EmailId where StudentNo=@StudentNo";

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Divison", student.Divison);
            cmd.Parameters.AddWithValue("@Branch", student.Branch);
            cmd.Parameters.AddWithValue("@EmailId", student.EmailId);
            cmd.Parameters.AddWithValue("@StudentNo", student.StudentNo);

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
