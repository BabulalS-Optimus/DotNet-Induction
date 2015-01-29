using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    //class containing solution for assignment 3
    class TestEnum
    {
        //declaring an enum for weekDays
        enum weekDays
        {
            Sunday,
            Monday,
            Tuesday,
            Wedneday,
            Thursday,
            Friday,
            Saturday
        }
        //a static method for the assignment 3
        internal static void EnumMethod()
        {
            //some week day messages using enum
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Sunday, (int)weekDays.Sunday); //write a line to the console
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Monday, (int)weekDays.Monday); //write a line to the console
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Tuesday, (int)weekDays.Tuesday); //write a line to the console
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Wedneday, (int)weekDays.Wedneday); //write a line to the console
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Thursday, (int)weekDays.Thursday); //write a line to the console
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Friday, (int)weekDays.Friday); //write a line to the console
            Console.WriteLine("Day number for {0} is {1} ", weekDays.Saturday, (int)weekDays.Saturday); //write a line to the console

        }
    }
}
