using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading.Channels;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Let's start the employee program");
        }

        Employee e1 = new Employee();
        //public decimal GetNetsalary()
        //public decimal GetNetsalary()
            //decimal sal = 1e1.GetNetSalary();
    }



    public class Employee
    {
        private String? name;
        private int empNo;
        private decimal basicSalary;
        private short deptNo;
        public static int idCounter = 0;

    //Parameterized constructor
        


        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Please enter a Name");

                name = value;
            }
            get
            {
                return name;
            }
        }

        public Employee()
        {
            Console.WriteLine("Inside default constructor: ");
        }

        public int EmpNo
        {
            //set
            //{
            //    if (EmpNo <= 0)
            //        throw new ArgumentOutOfRangeException("Enter empNO greater than 0");

            //    empNo = idCounter++;
            //}
            get
            {
                return empNo;
            }
        }

        public decimal BasicSalary
        {
            set
            {
                if (BasicSalary > 30000)
                    throw new ArgumentOutOfRangeException("Paise thode kam karo, hum par raham karo");

                basicSalary = value;
            }
            get
            {
                return basicSalary;
            }
        }

        public short DeptNo
        {
            set
            {
                if (DeptNo <= 0)
                    throw new ArgumentOutOfRangeException("Enter empNO greater than 0");

                deptNo = value;
            }
            get
            {
                return deptNo;
            }
        }


        public decimal GetNetsalary()
        {
            Console.WriteLine("Final salary is BasicSalary + 10000");
            return basicSalary * (decimal)1.5;
        }
    }
}