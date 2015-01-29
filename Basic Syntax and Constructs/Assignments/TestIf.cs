using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    //class for assignment 1
    class TestIf
    {
        //a static method for the assignment 1
        internal static void IfElseMethod()
        {
            string choice; //variable to store the user choice
            Console.WriteLine("Please enter a choice for language e.g. VB, C# ");//instruction for the user 
            choice = Console.ReadLine(); // to read the choice of user through console

            if (choice.ToUpper().Equals("VB")) // if user writes VB
            {
                Console.WriteLine("VB .NET: OOP, multithreading and more!"); //write a line to the console
            }
            else if (choice.ToUpper().Equals("C#")) //if user writes C#
            {
                Console.WriteLine("Good choice, C# is a fine language."); //write a line to the console
            }
            else //if user writes language other than VB and C#
            {
                Console.WriteLine("Well...good luck with that!"); //write a line to the console
            }
            //end of if-else

        }
    }
}
