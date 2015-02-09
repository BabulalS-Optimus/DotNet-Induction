using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        /// <summary>
        /// Abstract class for Designation
        /// </summary>
        abstract class Designation
        {
            public abstract string Title { get; }
        }

        /// <summary>
        /// Manager class inheriting Designation with title = "Manager"
        /// </summary>
        class Manager : Designation
        {
            public override string Title
            {
                get
                {
                    return "Manager";
                }
            }
        }

        /// <summary>
        /// Clerk class inheriting Designation with title = "Clerk"
        /// </summary>
        class Clerk : Designation
        {
            public override string Title
            {
                get
                {
                    return "Clerk";
                }
            }
        }

        /// <summary>
        /// Programmer class inheriting Designation with title = "Programmer"
        /// </summary>
        class Programmer : Designation
        {
            public override string Title
            {
                get
                {
                    return "Programmer";
                }
            }
        }

        /// <summary>
        /// The factory class that decides which class to instantiate
        /// </summary>
        static class Factory
        {
            /// <summary>
            /// Method to decide which class to instantiate.
            /// </summary>
            /// <param name="id">a numerical value</param>
            /// <returns>Instance of the Class</returns>
            public static Designation Get(int id)
            {
                #region Decide Class to instantiate
                switch (id)
                {
                    case 0:
                        return new Manager();
                    case 1:
                        return new Clerk();
                    default:
                        return new Programmer();
                }
                #endregion
            }
        }

        /// <summary>
        /// Main method definintion
        /// </summary>
        static void Main()
        {
            //Create instances of each class using Factory class
            for (int i = 0; i < 3; i++)
            {
                Designation employee = Factory.Get(i);
                Console.WriteLine("id = {0} =>> designation = {1} ", i, employee.Title);
            }
        }
    }
}
