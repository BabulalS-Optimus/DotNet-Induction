using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Bike : Vehicle
    {
        // private attributes for Bike class
        private int cc;
        private float average;

        //public properties for private attributes
        #region PublicProperties
        public int CC
        {
            get { return cc; }
            set { cc = value; }
        }

        public float Average
        {
            get { return average; }
            set { average = value; }
        }
        #endregion

        public Bike(string make, int yearOfManufacture, string model, float speed, int cc, float average, float maxSpeed)
            : base(make, yearOfManufacture, model, speed, maxSpeed)
        {
            this.cc = cc;
            this.average = average;
        }

        //method to display details of bike
        public void ShowDetails()
        {
            Console.WriteLine("\nDetails about the bike : \n");
            Console.WriteLine("Make : {0} ", this.Make);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Model : {0} ", this.Model);
            Console.WriteLine("Cubic Capacity(CC) : {0} ", this.CC);
            Console.WriteLine("Average : {0} ", this.Average);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Speed : {0} ", this.Speed);
            Console.WriteLine("Is Moving : {0} ", this.IsMoving());
        }
    }
}
