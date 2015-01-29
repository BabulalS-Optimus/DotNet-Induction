using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Car : Vehicle
    {

        // private attributes for Car class
        private bool isCNG;
        private float mileage;
        private int seatCount;

        //public properties for private attributes
        #region PublicProperties
        public bool IsCNG
        {
            get { return isCNG; }
            set { isCNG = value; }
        }
        public float Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public int SeatCount
        {
            get { return seatCount; }
            set { seatCount = value; }
        }
        #endregion

        public Car(string make, int yearOfManufacture, string model, float speed, bool isCNG, float mileage, int seatCount,float maxSpeed)
            : base(make, yearOfManufacture, model, speed,maxSpeed)
        {
            this.isCNG = isCNG;
            this.mileage = mileage;
            this.seatCount = seatCount;
        }
        //method to display details of a car
        public void ShowDetails()
        {
            Console.WriteLine("\nDetails about the Car : \n");
            Console.WriteLine("Make : {0} ", this.Make);
            Console.WriteLine("Year of Manufacture : {0} ", this.YearOfManufacture);
            Console.WriteLine("Is CNG ?  : {0} ", this.isCNG);
            Console.WriteLine("Total number of seats : {0} ", this.SeatCount);
            Console.WriteLine("Mileage : {0} ", this.Mileage);
            Console.WriteLine("Model : {0} ", this.Model);
            Console.WriteLine("Speed : {0} ", this.Speed);
            Console.WriteLine("Is Moving : {0} ", this.IsMoving());
        }
    }
}
