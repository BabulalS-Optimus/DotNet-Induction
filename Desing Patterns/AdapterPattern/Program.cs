using System;

namespace AdapterPattern
{
    /// <summary>
    /// Rectangle class
    /// </summary>
    class Rectangle
    {
        /// <summary>
        /// Attributes for Rectangle
        /// </summary>
        public int Height { get; set; }
        public int Width { get; set; }

        /// <summary>
        /// Constructor to initialize Rectangle attributes
        /// </summary>
        /// <param name="height">Height of Rectangle</param>
        /// <param name="width">Width of Rectangle</param>
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }

    /// <summary>
    /// Square class
    /// </summary>
    class Square
    {
        public int Side { get; set; }

        /// <summary>
        /// Parametric Constructor for SQuare
        /// </summary>
        /// <param name="side"></param>
        public Square(int side)
        {
            Side = side;
        }
    }

    /// <summary>
    /// Area class to calculate Area 
    /// </summary>
    class Area
    {
        /// <summary>
        /// Method to calculate Area
        /// </summary>
        /// <param name="rect">Object of Rectangle storing Height and Width</param>
        /// <returns>Area of the Rectangle</returns>
        public static int FindArea(Rectangle rect)
        {
            int area = rect.Height * rect.Width;
            return area;
        }
    }

    /// <summary>
    /// Adapter class to calculate area of Square using Rectangle Area Function
    /// </summary>
    class AreaAdapter
    {
        /// <summary>
        /// Method to calculate Area of Square 
        /// </summary>
        /// <param name="sq">Object having side of square</param>
        /// <returns>Area of the square</returns>
        public static int FindArea(Square sq)
        {
            int area;
            Rectangle rect = new Rectangle(sq.Side, sq.Side);
            area = Area.FindArea(rect);
            return area;
        }
    }

    /// <summary>
    /// Class containing Main method
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Argument list holding value of arguments passed</param>
        static void Main(string[] args)
        {
            //Create an object of Rectangle and find Area
            Rectangle rectangle = new Rectangle(12, 10);
            Console.WriteLine(Area.FindArea(rectangle));

            //Create an object of Square and find area
            Square square = new Square(4);
            Console.WriteLine(AreaAdapter.FindArea(square));
        }
    }
}
