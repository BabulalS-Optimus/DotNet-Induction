using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsNLists3
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

        public Car(string make, int yearOfManufacture, string model,  bool isCNG, float mileage, int seatCount,float maxSpeed)
            : base(make, yearOfManufacture, model, maxSpeed)
        {
            this.isCNG = isCNG;
            this.mileage = mileage;
            this.seatCount = seatCount;
        }
        
        //method to display details of a car
        public  void ShowDetails()
        {
            //call for ShowDetails method of base class which displays basic details of the vehicle
            base.ShowDetails();
            Console.WriteLine("\nOther details about the Car : \n");
            Console.WriteLine("Is CNG ?  : {0} ", this.isCNG);
            Console.WriteLine("Total number of seats : {0} ", this.SeatCount);
            Console.WriteLine("Mileage : {0} ", this.Mileage);
        }
       
        //overridden ToString()
        public override string ToString()
        {
            return "Car : " + base.ToString();
        }
    }
}
