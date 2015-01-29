using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Bicycle  :Vehicle
    {
        // private attributes for Bicycle class
        private bool isGear;

        //public properties for private attributes
        public bool IsGear
        {
            get { return isGear; }
            set { isGear = value; }
        }

        public Bicycle(string make, int yearOfManufacture, string model, float speed, bool isGear,float maxSpeed)
            : base(make, yearOfManufacture, model, speed,maxSpeed)
        {
            this.isGear = isGear;            
        }

        //method to show details of a bicycle
        public void ShowDetails()
        {
            Console.WriteLine("\nDetails about the bicycle : \n");
            Console.WriteLine("Make : {0} ", this.Make);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Model : {0} ", this.Model);
            Console.WriteLine("Gears  : {0} ", this.IsGear);
            Console.WriteLine("Speed : {0} ", this.Speed);
            Console.WriteLine("Is Moving : {0} ", this.IsMoving());
        }
    }
}
