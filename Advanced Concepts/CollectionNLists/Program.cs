using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionNLists
{
    class Program
    {
        static void Main(string[] args)
        {

            //code for Assignment 12
            
            //defining Vehicle objects
            Vehicle marutiQwe = new Vehicle("MARUTI SUZUKI", 2013, "QWE-004", 140);
            Vehicle marutiErt=new Vehicle("MARUTI SUZUKI", 2011, "ERT-94", 130);
            Vehicle oldVehicle = new Vehicle("MERCEDES", 2014, "OPR56G", 160);
           
            //creating a list to store Vehicle objects
            List<Vehicle> list = new List<Vehicle>();
            //adding vehicle objects to the list
            list.Add(marutiQwe);
            list.Add(marutiErt);
            list.Add(oldVehicle);
            
            //displaying List items before sorting
            Console.WriteLine("\n Before sorting : \n");
            for (int i = 0; i < list.Count; i++)
            {
                Vehicle item = list[i];
                Console.WriteLine(item);
            }
            //sorting the list items as per MaxSpeed [ High to Low] and Make [A to Z]
            list.Sort();
            
            //displaying items after sorting
            Console.WriteLine("\n After sorting : \n");
            for (int i = 0; i < list.Count; i++)
            {
                Vehicle item = list[i];
                Console.WriteLine(item);
            }
            
            //creating a Vehicle object to test Equals() method
            Vehicle newVehicle=new Vehicle("MERCEDES", 2014, "OPR56G", 160);
            
            //testing Equals() on different type of Vehicle objects
            Console.WriteLine("\n\nComparing two equal objects : {0} ", newVehicle.Equals(oldVehicle));
            Console.WriteLine("Comparing two unequal objects : {0} ", marutiQwe.Equals(marutiErt));
            
            //using VehicleCollections
            VehicleCollections vehicleCollection = new VehicleCollections(list.ToArray());
            
            //enumerating vehicleCollection using foreach
            Console.WriteLine("\n\n\t==Vehicle details using IEnumerable implemented Collection Class : \n");
            foreach (Vehicle item in vehicleCollection)
            {
                Console.WriteLine(item);
            }
            
            //showing the number of vehicles in the collection
            Console.WriteLine("\nNumber of vehicles in the collection : {0} ", vehicleCollection.Count);
            
            //adding a new vehicle in the collection using Add() method
            vehicleCollection.Add(new Vehicle("BAJAJ",2014,"Pulsar",140));
            
            //showing the number of vehicles in the collection
            Console.WriteLine("Number of vehicles in the collection : {0} ", vehicleCollection.Count);
            
            
            //showing the vehicle at 2 index in the collection
            Console.WriteLine("\nVehicle at index '2' in the collection : {0} ", vehicleCollection[2]);
        }
    }
}
