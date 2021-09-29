using System;
using System.Text.RegularExpressions;

namespace Employee
{
    public class Employees
    {
        private String EmpName;
        private String EmpID;
        private double hrsWorked;
        private double HourlyRate=9.50;


        public Employees()
        {

        }
        public Employees(string empName, string empID, double hrsWorked, double hourlyRate)
        {
            EmpName = empName;
            EmpID = empID;
            this.hrsWorked = hrsWorked;
            HourlyRate = hourlyRate;
        }

        public String CalcWage(Double hrs)
        {
            if (hrs > 40)
            {
                Double wage = ((HourlyRate * 40) + (14.25 * (hrs - 40)));
                wage = Math.Round(wage, 4, MidpointRounding.AwayFromZero);
                String result = string.Format("{0:F2}", wage);
                return result;
            }
            else
            {
                Double wage = hrs * HourlyRate;
                wage = Math.Round(wage, 4, MidpointRounding.AwayFromZero);
                String result = string.Format("{0:F2}", wage);
                return result;
            }
        }
        // validations

        public bool isValid(string name)
        {
            if (name.Length >= 1 && name.Length <= 50)
                return true;
            return false;
        }
        public string Getname()
        {
            Boolean res;
            do
            {
                Console.WriteLine("Enter the Employee Name: ");
                EmpName = Console.ReadLine();
                res = isValid(EmpName);
                if (res == true)
                {
                    return EmpName;
                }
                else
                {
                    Console.WriteLine("Entered name is not valid , please re-enter:  ");
                    Console.ReadLine();

                }
            } while (res != true);
            return "";
        }

        public bool isvalidEmpID(String id)
        {
            {
                if (string.IsNullOrEmpty(id))
                    return false;
                else if (id.Length == 3)
                {
                    //converting string to char[]
                    char[] char_arr = id.ToCharArray();
                    if(Char.IsLetter(char_arr[0]) == true && char.IsDigit(char_arr[1]) == true && char.IsDigit(char_arr[2]) == true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public string Getid()
        {
            Boolean res;
            do
            {
                Console.WriteLine("Enter the Employee ID: (e.g. D54) :  ");
                EmpID = Console.ReadLine();
                res = isvalidEmpID(EmpID);
                if (res == true)
                {
                    return EmpID;
                }
                else
                {
                    Console.WriteLine("Entered Id is not valid , please re-enter:  ");
                    Console.ReadLine();

                }
            } while (res != true);
            return "";
        }

        public bool isvalidWorkingHrs(double hrs)
        {
            if (hrs < 0 && hrs > 100)
            {
                return false;
            }
            return true;
        }
        public double Gethrsworked()
        {
            Boolean res;
            do
            {
                Console.WriteLine("Enter the staff hours Worked in a week :  "); // if staff hours are more than 40 hrs , they will get an increment of £14.24 for extra hour
                hrsWorked = double.Parse(Console.ReadLine());
                res = isvalidWorkingHrs(hrsWorked);
                if (res == true)
                {
                    return hrsWorked;
                }
                else
                {
                    Console.WriteLine("Entered Id is not valid , please re-enter:  ");
                    Console.ReadLine();

                }
            } while (res != true);
            return 0;
        }

      
        public void ToString(string result)
        {
            String ans = ("Emplyee " + this.EmpName + " with Employee ID " + this.EmpID + " weekely wage is £:" + result);
            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }


    class EmployeeManager 
    {

        public static void Main(string[] args)
        {
            Employees emp = new Employees();
            Console.WriteLine("Staff's infomation");
            String name = emp.Getname();
            String id = emp.Getid();
            Double hrs = emp.Gethrsworked();
            String res = emp.CalcWage(hrs);
            emp.ToString(res);
        }
    }
}
