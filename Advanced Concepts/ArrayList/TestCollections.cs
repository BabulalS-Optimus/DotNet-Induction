using System;
using System.Collections;

namespace CollectionsNLists2
{
    /// <summary>
    /// Class to use Vehicle class with ArrayList
    /// </summary>
    class TestCollection
    {
        /// <summary>
        /// Definition of main method
        /// </summary>
        /// <param name="args">List of arguments received </param>
        static void Main(string[] args)
        {
            //Create an array List
            ArrayList vehiclesList = new ArrayList();// Array.CreateInstance(typeof(Vehicle), 10);

            #region Define and Add objects to Array List
            Vehicle marutiQwe = new Vehicle("MARUTI SUZUKI", 2013, "QWE-004", 140);
            Vehicle mercedesOpr = new Vehicle("MERCEDES", 2014, "OPR56G", 160);
            Car marutiAbh = new Car("MARUTI SUZUKI", 2011, "ABH_JKL", true, 22, 4, 140);
            Bike bajajPulsar = new Bike("BAJAJ", 2013, "PULSUR", 250, 67, 140);

            vehiclesList.Add(marutiQwe);
            vehiclesList.Add(mercedesOpr);
            vehiclesList.Add(marutiAbh);
            vehiclesList.Add(bajajPulsar);
            #endregion

            Console.WriteLine("\nDetails using foreach : \n ");

            //enumerating through the list contents and use ToString() to deisplay
            foreach (Vehicle item in vehiclesList)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nDetails using for : \n ");
            //travesring each item using index
            for (int i = 0; i < vehiclesList.Count; i++)
            {
                Console.WriteLine(((Vehicle)(vehiclesList[i])).ToString());

                //checking for maximum speed of vehicle and modify it
                if (((Vehicle)(vehiclesList[i])).MaxSpeed > 150)
                {
                    ((Vehicle)(vehiclesList[i])).MaxSpeed = 150;
                    Console.WriteLine("<changed> {0}", ((Vehicle)(vehiclesList[i])).ToString());
                }
            }
        }
    }
}
