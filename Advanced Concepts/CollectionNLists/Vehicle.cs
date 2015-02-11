using System;

namespace CollectionNLists
{
    /// <summary>
    /// Class to hold vehicle details
    /// </summary>
    class Vehicle : IComparable
    {
        /// <summary>
        /// Private attributes
        /// </summary>
        #region Attributes
        private string make;
        private int yearOfManufacture;
        private string model;
        private float maxSpeed;
        #endregion

        /// <summary>
        /// Public properties for private members
        /// </summary>
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

        /// <summary>
        /// Parametric constructor for Vehicl class
        /// </summary>
        /// <param name="make">MAke of the vehicle</param>
        /// <param name="yearOfManufacture"> Year of manufacturing for the vehicle</param>
        /// <param name="model">Model of the vehicle</param>
        /// <param name="maxSpeed">Maximum Speed of the vehicle</param>
        public Vehicle(string make, int yearOfManufacture, string model, float maxSpeed)
        {
            this.make = make;
            this.yearOfManufacture = yearOfManufacture;
            this.model = model;
            this.maxSpeed = maxSpeed;
        }

        /// <summary>
        /// Method to display the vehicle
        /// </summary>
        public void ShowDetails()
        {
            Console.WriteLine("\nDetails about the Vehicle : \n");
            Console.WriteLine("Make : {0} ", this.Make);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Model : {0} ", this.Model);
            Console.WriteLine("Maximum Speed : {0} ", this.maxSpeed);
        }

        /// <summary>
        /// Overridden ComapreTo method
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Result of comparison</returns>
        int IComparable.CompareTo(object obj)
        {
            Vehicle other = (Vehicle)obj;
            //if both have same speed [then sort with make]
            if (this.maxSpeed == other.maxSpeed)
            {
                return this.make.CompareTo(other.make);
            }
            //sort with maxSpeed [ High to Low ]
            return other.maxSpeed.CompareTo(this.maxSpeed);
            ///to sort with maxSpeed [ Low to High ]
            ///return this.maxSpeed.CompareTo(other.maxSpeed);
        }

        /// <summary>
        /// Overriden ToString() method
        /// </summary>
        /// <returns>String to be printed</returns>
        public override string ToString()
        {
            return this.make.ToString() + " , " + this.model.ToString() + " , " + this.maxSpeed.ToString();
        }

        /// <summary>
        /// Overridden Equals method to compare two objects
        /// </summary>
        /// <param name="obj">Object to be compared with</param>
        /// <returns>Result of the comparison</returns>
        public override bool Equals(Object obj)
        {
            //Type cast the object
            Vehicle vehicleObj = (Vehicle)obj;
            bool result;
            //Compare the objects and return result
            if (obj == null)
            {
                return false;
            }
            result = this.make.Equals(vehicleObj.make) && this.maxSpeed == vehicleObj.maxSpeed && this.model.Equals(vehicleObj.model) && this.yearOfManufacture == vehicleObj.yearOfManufacture;

            return result;
        }

    }
}
