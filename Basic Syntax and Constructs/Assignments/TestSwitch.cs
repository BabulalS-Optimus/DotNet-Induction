using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    //class containing solution for Assignment 2
    class TestSwitch
    {
        //a static method for the assignment 2
        internal static void SwitchMethod()
        {
            string choice; //variable to store the user choice
            Console.WriteLine("Please enter a choice for language e.g. VB, C# ");//instruction for the user 
            choice = Console.ReadLine(); // to read the choice of user through console

            switch (choice.ToUpper())
            {
                case "VB": // if user writes VB
                    Console.WriteLine("VB .NET: OOP, multithreading and more!"); //write a line to the console
                    break;

                case "C#": //if user writes C#
                    Console.WriteLine("Good choice, C# is a fine language."); //write a line to the console
                    break;

                default://if user writes language other than VB and C#
                    Console.WriteLine("Well...good luck with that!"); //write a line to the console
                    break;
            }
            //end of switch

        }
    }
}
