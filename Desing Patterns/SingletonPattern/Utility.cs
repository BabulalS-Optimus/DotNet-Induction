using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// Singleton class definition
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Members of the class
        /// </summary>
        public string Name { get; set; }
        private static Utility instance;
        private static object syncRoot = new Object();

        /// <summary>
        /// Private constructor
        /// </summary>
        private Utility()
        {

        }

        /// <summary>
        /// Public property to create single Object of the class
        /// </summary>
        public static Utility GetInstance
        {
            #region Create object of Utility Class
            get
            {
                if (instance == null)
                {
                    instance = new Utility();
                }
                return instance;
            }
            #endregion
        }

        /// <summary>
        /// Method to display some message
        /// </summary>
        public void ShowMessage()
        {
            Console.WriteLine("Hey there...!!!");
        }
    }
}

