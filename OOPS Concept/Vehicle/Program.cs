using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            //instructions for the user to proceed
            Console.WriteLine("Choose an option to proceed....");
            Console.WriteLine("1. Truck");
            Console.WriteLine("2. Car");
            Console.WriteLine("3. Bike");
            Console.WriteLine("4. Bicycle");
            
            //read the input from user
            int choice = Convert.ToInt16(Console.ReadLine());

            //check the user input
            switch (choice)
            {
                case 1://if user chooses a truck
                    Truck truck = new Truck("Ashok Leyland", 2012, "ABC-001", 0, 1200, 7, 50);
                    truck.ShowDetails();     //show details 
                    truck.Accelerate(12);    //acelerate vehicle by 12
                    truck.ShowDetails();     //show details of the vehicle
                    truck.Deaccelerate(12);  //deaccelerate the vehicle by 12
                    truck.ShowDetails();     //show the details of the vehicle
                    break;

                case 2://if user chooses a car
                    Car car = new Car("MARUTI SUZUKI", 2011, "ABH_JKL", 0, true, 22, 4, 140);
                    car.ShowDetails();        //show details 
                    car.Accelerate(12);       //acelerate vehicle by 12
                    car.ShowDetails();        //show details of the vehicle
                    car.Deaccelerate(12);     //deaccelerate the vehicle by 12
                    car.ShowDetails();        //show the details of the vehicle
                    break;

                case 3://if user chooses a bike
                    Bike bike = new Bike("BAJAJ", 2013, "PULSUR", 12, 250, 67, 140);
                    bike.ShowDetails();        //show details 
                    bike.Accelerate(12);       //acelerate vehicle by 12
                    bike.ShowDetails();        //show details of the vehicle
                    bike.Deaccelerate(12);     //deaccelerate the vehicle by 12
                    bike.ShowDetails();        //show the details of the vehicle
                    break;

                case 4://if user chooses a bicycle
                    Bicycle bicycle = new Bicycle("ATLAS", 2014, "WER-005", 6, true, 40);
                    bicycle.ShowDetails();      //show details 
                    bicycle.Accelerate(12);     //acelerate vehicle by 12
                    bicycle.ShowDetails();      //show details of the vehicle
                    bicycle.Deaccelerate(12);   //deaccelerate the vehicle by 12
                    bicycle.ShowDetails();      //show the details of the vehicle
                    break;

                default:  //if user enters an incorrect option
                    Console.WriteLine("Not a correct option.");
                    break;
            }
        }
    }
}
