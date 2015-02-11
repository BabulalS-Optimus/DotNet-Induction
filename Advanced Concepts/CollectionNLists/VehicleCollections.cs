using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionNLists
{
    /// <summary>
    /// Vehisle class implementing IEnumerable interface
    /// </summary>
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
            return new VehicleEnumerator();
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

    /// <summary>
    /// Class implementing IEnumerable interface
    /// </summary>
    class VehicleEnumerator : IEnumerator
    {
        //collection of vehicle objects
        List<Vehicle> vehicles = new List<Vehicle>();
        int _current;

        /// <summary>
        /// Current property
        /// </summary>
        public object Current
        {
            get { return vehicles.ElementAt(_current); }
        }

        /// <summary>
        /// Method to return whether to move forward or not
        /// </summary>
        /// <returns>Result for moving</returns>
        public bool MoveNext()
        {
            //Compare the current position with the length of the List
            if (vehicles.Count == 0 || vehicles.Count <= _current)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to reset the counter
        /// </summary>
        public void Reset()
        {
            _current = 0;
        }
    }

}
