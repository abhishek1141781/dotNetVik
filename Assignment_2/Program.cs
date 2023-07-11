using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading.Channels;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Let's start the employee program..............");
            Employee e1 = new Employee();
            //console

            Console.WriteLine("Enter Emp Name: ");
            e1.Name = Console.ReadLine().Trim();

            Console.WriteLine("Enter Basic Salary: ");
            e1.BasicSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Deptno: ");
            e1.DeptNo = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("e1.EmpNo: " + e1.EmpNo);
            Console.WriteLine("e1.Name: " + e1.Name);
            Console.WriteLine("e1.BasicSalary: " + e1.BasicSalary);
            Console.WriteLine("e1.DeptNo: " + e1.DeptNo);
            Console.WriteLine("e1.GetNetsalary: " + e1.GetNetsalary());

            //Employee o1 = new Employee("Amol", 123465, 10);
            //Employee o2 = new Employee("Amol", 123465);
        }
    }

    public class Employee
    {
        private String? name;
        //private int empNo = 0;
        //private int empNo;
        private decimal basicSalary;
        private short deptNo;
        private static int idCounter = 0;

        //Parameterized constructor

        public Employee(String? name=null, decimal basicSalary=0, short deptNo=0)
        {
            this.name = name;
            this.basicSalary = basicSalary;
            this.deptNo = deptNo;
            this.EmpNo = ++idCounter;
        }


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

        //public Employee()
        //{
        //    Console.WriteLine("Inside default constructor: ");
        //}

        public int EmpNo
        {
            get;
        }

        public decimal BasicSalary
            {
            set
            {
                if (value > 30000)
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
                if (value <= 0)
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
            Console.WriteLine("Final salary is BasicSalary * 1.5");
            return basicSalary * (decimal)1.5;
        }
    }
}


