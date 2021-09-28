using System;

namespace Employee
{
    class Program
    {


        public static String staff_increment(Double hrs)
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

         public static void weekly_wage_calculator(Double hrs)
        {
            Double wage = hrs * 9.50;
            wage = Math.Round(wage, 4, MidpointRounding.AwayFromZero);
            String result = string.Format("{0:F2}", wage);
            Console.WriteLine("Your weekely wage is £: {0} ", result);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the hours Worked in a week:  "); // or Console.Write("Type any number:  "); to enter number in the same line
            Double x = double.Parse(Console.ReadLine());
            weekly_wage_calculator(x);

            Console.WriteLine("Enter the staff hours Worked in a week :  "); // if staff hours are more than 40 hrs , they will get an increment of £14.24 for extra hour
            Double y = double.Parse(Console.ReadLine());
            String result = staff_increment(y);
            Console.WriteLine("Staff's weekely wage is £: {0} ", result);
            Console.ReadKey();



        }
    }
}
