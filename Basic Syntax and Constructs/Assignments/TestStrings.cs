using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    //class for assignment 4 and 5
    class TestStrings
    {
        //a static method for the assignment 4
        internal static void StringOperationsMethod()
        {
            Console.WriteLine("Enter your full name."); //instruction for the user to enter his/her name

            String fullName; //object of String type to store full name of the user

            fullName=Console.ReadLine(); //to read full name of the user

            //use of insert operation
            Console.WriteLine("Your name after inserting 'Hello' at index '4' : {0}", fullName.Insert(4, "Hello"));

            //use of Length
            Console.WriteLine("Length of your name : {0}", fullName.Length);

            //use of Left padding
            Console.WriteLine("Your name by using Left padding : {0}", fullName.PadLeft(20, '$'));

            //use of Right padding
            Console.WriteLine("Your name by using Right padding : {0}", fullName.PadRight(20, '$'));

            //use of Replace
            Console.WriteLine("Your name after replacing 'a' with 'x': {0}", fullName.Replace('a', 'x'));

            //use of Substring
            Console.WriteLine("Taking substring from your name from index '4' : {0}", fullName.Substring(4));

            //use of ToLower
            Console.WriteLine("Your name in lower case  : {0}", fullName.ToLower());

            //use of ToUpper
            Console.WriteLine("Your name in upper case  : {0}", fullName.ToUpper());

        }

        //a static method for the assignment 5
        internal static string[] GetStringArray()
        {
            //array of string to store 5 string elements
            string[] names=new string[5];

            Console.WriteLine("Enter 5 names : "); //instruction for the user
            
            //loop to read 5 names through console
            for (int i = 0; i < 5; i++)
            {
                names[i] = Console.ReadLine(); //reading names 
            }
            
            return names; //returning the string array 
        }
    }
}
