using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsNLists3
{
    class Program
    {
        static void Main(string[] args)
        {
            //list to store vehicles
            List<Vehicle> vehiclesList = new List<Vehicle>();

            //defining Vehicle objects
            Vehicle marutiQwe = new Vehicle("MARUTI SUZUKI", 2013, "QWE-004", 140);
            Vehicle mercedesOpr = new Vehicle("MERCEDES", 2014, "OPR56G", 160);

            //defining Car objects
            Car marutiAbh = new Car("MARUTI SUZUKI", 2011, "ABH_JKL", true, 22, 4, 140);

            //defining a bike object
            Bike bajajPulsar = new Bike("BAJAJ", 2013, "PULSUR", 250, 67, 140);

            //defining a truck object
            Truck ashokAbc = new Truck("Ashok Leyland", 2012, "ABC-001", 1200, 7, 50);

            //adding all the objects to the vehicle list
            vehiclesList.Add(marutiQwe);
            vehiclesList.Add(mercedesOpr);
            vehiclesList.Add(marutiAbh);
            vehiclesList.Add(bajajPulsar);
            vehiclesList.Add(ashokAbc);

            //displaying List items before sorting
            Console.WriteLine("\n Before sorting : \n");
            for (int i = 0; i < vehiclesList.Count; i++)
            {
                Vehicle item = vehiclesList[i];
                Console.WriteLine(item);
            }
            //sorting the list items as per MaxSpeed [ High to Low] and Make [A to Z]
            vehiclesList.Sort();

            //displaying items after sorting
            Console.WriteLine("\n After sorting : \n");
            for (int i = 0; i < vehiclesList.Count; i++)
            {
                Vehicle item = vehiclesList[i];
                Console.WriteLine(item);
            }

            
            //testing Equals() on different type of Vehicle objects
            Console.WriteLine("\n\nComparing similar type of objects : {0} ", marutiAbh.Equals(mercedesOpr));
            Console.WriteLine("Comparing two different type of objects : {0} ", marutiQwe.Equals(ashokAbc));
            

        }
    }
}
