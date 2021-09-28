using System;

namespace Employee
{
    class EmployeeManager
    {


        public static String CalcWage(Double hrs)
        {
            if (hrs > 40)
            {
                Double wage = ((9.50 * 40) + (14.25 * (hrs - 40)));
                wage = Math.Round(wage, 4, MidpointRounding.AwayFromZero);
                String result = string.Format("{0:F2}", wage);
                return result;
            }
            else
            {
                Double wage = hrs * 9.50;
                wage = Math.Round(wage, 4, MidpointRounding.AwayFromZero);
                String result = string.Format("{0:F2}", wage);
                return result;
            }
        }

        

        static void Main(string[] args)
        {

            Console.WriteLine("Staff's infomation");
            Console.WriteLine("Enter the staff hours Worked in a week :  "); // if staff hours are more than 40 hrs , they will get an increment of £14.24 for extra hour
            Double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the Employee ID: (e.g. D54) :  ");
            String id = Console.ReadLine();
            String result = CalcWage(y);

            Console.WriteLine("Emplyee {0} with Employee ID {1} weekely wage is £: {2} ",name, id, result);
            Console.ReadKey();




        }
    }
}
