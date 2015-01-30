using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExceptions;
using System.Diagnostics;

namespace Vehicle
{
    public class Vehicle
    {
        // private attributes for Vehicle class
        #region Attributes
        private string make;
        private int yearOfManufacture;
        private string model;
        private float speed;
        private float maxSpeed;
        private bool isMoving;
        #endregion

        /// <summary>
        /// public properties for private attributes
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
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public float MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }
        #endregion

        public Vehicle(string make, int yearOfManufacture, string model, float speed, float maxSpeed)
        {
            this.make = make;
            this.yearOfManufacture = yearOfManufacture;
            this.model = model;
            this.speed = speed;
            this.maxSpeed = maxSpeed;

            if (speed > 0)
            {
                this.isMoving = true;
            }
            else
            {
                this.isMoving = false;
            }
        }

        //to accelerate the vehicle
        public void Accelerate(float speed)
        {
            try //try block
            {

                this.Speed += speed;
                if (!this.IsMoving())
                    this.isMoving = true;

                if (this.Speed > MaxSpeed) //checking for any exception
                {
                    string message = "Vehicle overheated.";
                    throw new IsCarDeadException(message, Speed); //throwing the exception
                }

            }
            catch (IsCarDeadException ex)
            {
                Console.WriteLine("\nWarning : Vehicle is overheating...");
            }
            
            finally //finally block
            {
                Console.WriteLine("\nNew Speed of the vehicle : {0}\n", Speed);
            }
        }

        //method to deaccelerate the vehicle
        public void Deaccelerate(float speed)
        {
            try //try block
            {

                if (this.Speed - speed >= 0)
                {
                    this.Speed -= speed;
                }
                else
                {
                    Console.WriteLine("The speed cannot be less than zero. The speed is set to 0.");
                    this.Speed = 0;
                }

                if (this.Speed > MaxSpeed) //checking for the exception 
                {
                    string message = "Vehicle is still overheating.";
                    throw new IsCarDeadException(message, Speed); //throwing the exception
                }
            }
            catch (IsCarDeadException ex)
            {
                Console.WriteLine("\nWarning : Vehicle is overheating...");
            }
            
            finally //finally block for try
            {
                if (Speed == 0)
                {
                    this.isMoving = false;
                }
                Console.WriteLine("\nNew Speed of the vehicle : {0}\n", Speed);
            }
        }

        //method that tells whether the vehicle is moving or not
        public bool IsMoving()
        {
            return isMoving;
        }

        //printing the exceptions caught
        public void ShowExceptions()
        {
            Console.Write("\n Exceptions caught : \n\n");
            if (IsCarDeadException.messages.Count == 0)
            {
                Console.WriteLine("<<No exceptions found....>>");
            }
            foreach (string item in IsCarDeadException.messages)
            {
                Console.WriteLine(item);
            }
        }

    }
}
