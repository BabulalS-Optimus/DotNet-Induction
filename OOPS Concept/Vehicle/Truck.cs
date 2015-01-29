using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
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
        public Truck(string make, int yearOfManufacture, string model, float speed, int weightCapacity, float mileage,float maxSpeed)
            : base(make, yearOfManufacture, model, speed,maxSpeed)
        {
            this.weightCapacity = weightCapacity;
            this.mileage = mileage;
        }
        
        
        //method to display the details of a truck
        public void ShowDetails()
        {
            Console.WriteLine("\nDetails about the truck : \n");
            Console.WriteLine("Make : {0} ", this.Make);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Weight Capacity : {0} ", this.WeightCapacity);
            Console.WriteLine("Mileage : {0} ", this.Mileage);
            Console.WriteLine("Model : {0} ", this.Model);
            Console.WriteLine("Speed : {0} ", this.Speed);
            Console.WriteLine("Is Moving : {0} ", this.IsMoving());
        }
    }
}
