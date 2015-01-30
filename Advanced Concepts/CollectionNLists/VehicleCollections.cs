using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionNLists
{
    //VehicleCollection class implementing IEnumerable 
    class VehicleCollections : IEnumerable
    {
        //collection of vehicle objects
        List<Vehicle> vehicles;

        //count variable to see the number of vehicle objects in the collection
        public int Count
        {
            get { return vehicles.Count; }
        }

        //public property to access the vehicles using index
        public Vehicle this[int index]
        {
            get { return vehicles[index]; }
        }

        //parametric constructor to store vehicles in list and create a new object of VehicleCollection
        public VehicleCollections(Vehicle[] vehicles)
        {
            this.vehicles = new List<Vehicle>(vehicles);
        }
        
        //implementation of the GetEnumerator methods 
        //namespace => System.Collections
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.vehicles.GetEnumerator();
        }
        
        //method to add a new vehicle
        public void Add(Vehicle newVehicle)
        {
            vehicles.Add(newVehicle);
        }

        //method to remove any vehicle from the list
        public void Remove(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

    }
}
