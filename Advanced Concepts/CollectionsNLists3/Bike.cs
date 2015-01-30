using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsNLists3
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

        public Bike(string make, int yearOfManufacture, string model,  int cc, float average, float maxSpeed)
            : base(make, yearOfManufacture, model,  maxSpeed)
        {
            this.cc = cc;
            this.average = average;
        }

        //method to display details of bike
        public  void ShowDetails()
        {
            //call for ShowDetails method of base class which displays basic details of the vehicle
            base.ShowDetails();
            Console.WriteLine("\nOther details about the bike : \n");
            Console.WriteLine("Cubic Capacity(CC) : {0} ", this.CC);
            Console.WriteLine("Average : {0} ", this.Average);
        }

        //overridden ToString()
        public override string ToString()
        {
            return "Bike : " + base.ToString();
        }
    
    }
}
