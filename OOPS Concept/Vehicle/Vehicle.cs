using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    class Vehicle
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
            if (this.Speed + speed <= maxSpeed)
            {
                this.Speed += speed;
                if (!this.IsMoving())
                    this.isMoving = true;
            }
            else
            {
                Console.WriteLine("Cannot exceed the maximum speed of the vehicle. The speed is set to maximum.");
                this.Speed = maxSpeed;
            }
            Console.WriteLine("\nNew Speed of the vehicle : {0}\n", Speed);

        }

        //method to deaccelerate the vehicle
        public void Deaccelerate(float speed)
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
            if (Speed == 0)
            {
                this.isMoving = false;
            }
            Console.WriteLine("\nNew Speed of the vehicle : {0}\n", Speed);
        }

        //method that tells whether the vehicle is moving or not
        public bool IsMoving()
        {
            return isMoving;
        }

    }
}
