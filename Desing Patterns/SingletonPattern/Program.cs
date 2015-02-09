using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an object of Utility class and set some value to Name
            Utility util = Utility.GetInstance;
            util.Name = "ABC";

            //Create another object of Utility and access Name
            Utility util2 = Utility.GetInstance;
            Console.Write(util2.Name);

        }
    }
}
