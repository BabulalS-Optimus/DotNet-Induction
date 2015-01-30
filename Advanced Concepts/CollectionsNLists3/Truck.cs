using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsNLists3
{
    class Truck : Vehicle
    {
        // private attributes for Truck class
        private int weightCapacity;
        private float mileage;

        //public properties for private attributes
        #region PublicProperties
        public int WeightCapacity
        {
            get { return weightCapacity; }
            set { weightCapacity = value; }
        }
        public float Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        #endregion

        //parametric constructor to create a new object for Truck
        public Truck(string make, int yearOfManufacture, string model,  int weightCapacity, float mileage, float maxSpeed)
            : base(make, yearOfManufacture, model,  maxSpeed)
        {
            this.weightCapacity = weightCapacity;
            this.mileage = mileage;
        }


        //method to display details of bike
        public  void ShowDetails()
        {
            //call for ShowDetails method of base class which displays basic details of the vehicle
            base.ShowDetails();
            Console.WriteLine("\nOther details about the truck : \n");
            Console.WriteLine("Weight Capacity(CC) : {0} ", this.weightCapacity);
            Console.WriteLine("Mileage : {0} ", this.mileage);
        }

        //overridden ToString()
        public override string ToString()
        {
            return "Truck : " + base.ToString();
        }
    

    }
}
