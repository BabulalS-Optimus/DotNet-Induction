using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsNLists3
{
    class Vehicle : IComparable<Vehicle>, IEquatable<Vehicle>
    {
        // private attributes for Vehicle class
        #region Attributes
        private string make;
        private int yearOfManufacture;
        private string model;
        private float maxSpeed;
        #endregion

        //public properties for private attributes
        #region PublicProperties
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public int YearOfManufacture
        {
            get { return yearOfManufacture; }
            set { yearOfManufacture = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public float MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }
        #endregion

        //parametric constructor to create a new object
        public Vehicle(string make, int yearOfManufacture, string model, float maxSpeed)
        {
            this.make = make;
            this.yearOfManufacture = yearOfManufacture;
            this.model = model;
            this.maxSpeed = maxSpeed;
        }

        //method to display details of Vehicle
        public void ShowDetails()
        {
            Console.WriteLine("\nBasic details about the Vehicle : \n");
            Console.WriteLine("Make : {0} ", this.Make);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Model : {0} ", this.Model);
            Console.WriteLine("Maximum Speed : {0} ", this.maxSpeed);
        }


        //overridden ToString()
        public override string ToString()
        {
            return this.make.ToString() + ":" + this.model.ToString() + " , " + this.maxSpeed.ToString();
        }
       
        //method to compare two objects of Vehicle class with Vehicle type input parameter
        int IComparable<Vehicle>.CompareTo(Vehicle other)
        {
            //if both have same speed [then sort with make]
            if (this.maxSpeed == other.maxSpeed)
            {
                //to sort with make [A to Z]
                return this.make.CompareTo(other.make);
                
                //to sort with make[Z to A]
                //return other.make.CompareTo(this.make);
            }
            //sort with maxSpeed [ High to Low ]
            return other.maxSpeed.CompareTo(this.maxSpeed);
            
            //to sort with maxSpeed [ Low to High ]
            //return this.maxSpeed.CompareTo(other.maxSpeed);
        }


        //overridden Equals()
        bool IEquatable<Vehicle>.Equals(Vehicle vehicleObj)
        {
            bool result;
            if (vehicleObj == null)
            {
                return false;
            }
            result = this.make.Equals(vehicleObj.make) && this.maxSpeed == vehicleObj.maxSpeed && this.model.Equals(vehicleObj.model) && this.yearOfManufacture == vehicleObj.yearOfManufacture;

            return result;
        }
    }
}
