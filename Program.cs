using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Employee
{
    public class Employees
    {
        public String EmpName { get; set; }
        public String EmpID { get; set; }
        public double hrsWorked { get; set; }
        public String weeklywage { get; set; }
        public double HourlyRate = 9.50;


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
            double wage;
            if (hrs > 40)
            {
                wage = ((HourlyRate * 40) + (14.25 * (hrs - 40)));
            }
            else
            {
                wage = hrs * HourlyRate;
            }
            wage = Math.Round(wage, 4, MidpointRounding.AwayFromZero);
            String result = string.Format("{0:F2}", wage);
            return result;
        }
        // validations
        
        public bool isValid(string name)
        {
            if (name.Length >= 1 && name.Length <= 50 && name.Substring(0,1).Any(ch => Char.IsLetterOrDigit(ch)))
                return true;
            return false;
        }
        public string Getname()
        {
            Boolean res;
            Console.WriteLine("Enter the Employee Name: ");

            do
            {
                EmpName = Console.ReadLine();
                res = isValid(EmpName);
                if (res == true)
                {
                    return EmpName;
                }
                else
                {
                    Console.WriteLine("Entered name is not valid, please re-enter:  ");
                    //Console.ReadLine();

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
                    if (Char.IsLetter(char_arr[0]) == true && char.IsDigit(char_arr[1]) == true && char.IsDigit(char_arr[2]) == true)
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
            Console.WriteLine("Enter the Employee ID: (e.g. D54) :  ");
            do
            {
               
                EmpID = Console.ReadLine();
                res = isvalidEmpID(EmpID);
                if (res == true)
                {
                    return EmpID;
                }
                else
                {
                    Console.WriteLine("Entered Id is not valid , please reenter:  ");
                    Console.ReadLine();

                }
            } while (res != true);
            return "";
        }

        public bool isvalidWorkingHrs(double hrs)
        {
            if (hrs < 0)
            {
                return false;
            }else if (hrs > 100)
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
                    Console.WriteLine("Entered hours Worked  is not valid , please re-enter:  ");
                    Console.ReadLine();

                }
            } while (res != true);
            return 0;
        }


        public String ToString(string result)
        {
            String ans = "Emplyee " + this.EmpName + " with Employee ID " + this.EmpID + " weekely wage is £:" + result;
            //String ans1 = $"Emplyee {this.EmpName} with Employee ID {this.EmpID } weekely wage is £:{result}";


            return ans;
        }
    }



    class EmployeeManager
    {
        static List<Employees> empDetail = new List<Employees>();

        static void Main(string[] args)
        {
            Int32 option1 = DisplayMainMenu();
            MainCall(option1);
            Console.Read();
        }
        /// <summary>
        /// Containing switch to handle which method to execute
        /// <param name="option">Option to Add\Delete\Update Employee Information</param>
        /// </summary>
        private static void MainCall(Int32 option)
        {

            switch (option)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    DisplayList();
                    Int32 option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 3:
                    Console.WriteLine("Enter the position of Employee you want to delete:");
                    int pos = int.Parse(Console.ReadLine());
                    int result = DeleteEmployee(pos);
                    if (result == 1)
                        Console.WriteLine("Employee deleted");
                    else
                        Console.WriteLine("Employee with ID:" + empDetail[pos].EmpID + " not found");
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
                case 4:
                    Console.WriteLine("BYEEEEEEEEEEEEEEEEEEEEE!!!!!!!!!!!!!!!!!!!");
                    break;
                default:
                    Console.WriteLine("Invalid Input!!!!!!Re-Enter");
                    option1 = DisplayMainMenu();
                    MainCall(option1);
                    break;
            }
        }

        /// <summary>
        /// Display Main menu
        /// </summary>
        private static int DisplayMainMenu()
        {
            Console.WriteLine("\nSelect any option:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Exit");

            Int32 option = 0;
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Some Error Occured");
            }
            return option;
        }

        /// <summary>
        /// Add New Employee
        /// </summary>
        public static List<Employees> AddEmployee()
        {

            Employees emp = new Employees();


            try
            {
                Console.WriteLine("Enter following information to add new Employee:");
                emp.EmpName = emp.Getname();
                emp.EmpID = emp.Getid();
                emp.hrsWorked = emp.Gethrsworked();
                emp.weeklywage = emp.CalcWage(emp.hrsWorked);
                if (empDetail.Count > 0)
                {
                    foreach (Employees empd in empDetail)
                    {
                        if (empd.EmpID.Equals(emp.EmpID))
                            Console.WriteLine("This Employee already exists in the list !!");
                        break;
                    }
                }
                else
                {
                    empDetail.Add(emp);
                    Console.WriteLine("Employee Weeky Wage :£{0}", emp.weeklywage);
                }

                Console.WriteLine("Press Enter to proceed!!");
                Console.ReadKey();
                Console.WriteLine("Employee successfully Added");
                Console.ReadLine();

                Console.WriteLine(@"Do you want to add more Employee? Y\N");
                char choice = Console.ReadKey().KeyChar;
                Console.ReadLine();


                switch (Char.ToUpper(choice))
                {
                    case 'Y':
                        AddEmployee();
                        break;
                    case 'N':
                        Int32 option1 = DisplayMainMenu();
                        MainCall(option1);
                        break;
                    default:
                        Console.WriteLine("Some Error Occured!! Please select right option");
                        Console.WriteLine("-----------------------------------------------");
                        option1 = DisplayMainMenu();
                        MainCall(option1);
                        break;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some Error Occured!! Please select right option");
                Console.WriteLine("-----------------------------------------------");
                Int32 option1 = DisplayMainMenu();
                MainCall(option1);
            }
            return empDetail;
        }

        /// <summary>
        /// Display Employee List
        /// </summary>
        private static void DisplayList()
        {
            int pos = 0;
            Console.WriteLine("");
            Console.WriteLine("-----------------------------Employee Detail---------------------------------------");
            foreach (Employees emp in empDetail)
            {
                Console.WriteLine(pos + ". Employee ID:" + emp.EmpID + " Name:" + emp.EmpName + " Weekly Wage is £:" + emp.weeklywage);
                pos++;
            }
        }
        /// <summary>
        /// Delete Existing Employee
        /// <param name="empid">Which Employee Id to delete</param>
        /// </summary>
        private static int DeleteEmployee(int pos)
        {
            if (empDetail.Count > pos && empDetail[pos] != null)
            {
                empDetail.RemoveAt(pos);
                return 1;
            }
            return 0;
        }
    }



}