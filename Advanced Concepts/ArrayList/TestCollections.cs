using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsNLists2
{
    //VehicleCollection class
    class TestCollection
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

            //adding all the objects to the vehicle list
            vehiclesList.Add(marutiQwe);
            vehiclesList.Add(mercedesOpr);
            vehiclesList.Add(marutiAbh);
            vehiclesList.Add(bajajPulsar);

            Console.WriteLine("\nDetails using foreach : \n ");
            //enumerating through the list contents
            foreach (Vehicle item in vehiclesList)
            {
                //printing the result of ToString() method
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nDetails using for : \n ");
            //travesring each item using index
            for (int i = 0; i < vehiclesList.Count; i++)
            {

                //printing the result of ToString() method
                Console.WriteLine(vehiclesList[i].ToString());

                //checking for maximum speed of vehicle
                if (vehiclesList[i].MaxSpeed > 150)
                {
                    //modifying maximum speed of the vehicle to 150
                    vehiclesList[i].MaxSpeed = 150;

                    //printing the result of ToString() method
                    Console.WriteLine("<changed> {0}", vehiclesList[i].ToString());
                }
            }
        }
    }
}
