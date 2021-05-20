using System;

namespace Exercise5
{
    class Box
    {
        public double length;
        public double breadth;
        public double height;

        public double getVolume()
        {
            return length * breadth * height;
        }
        public void setLength(double len)
        {
            length = len;
        }

        public void setBreadth(double bre)
        {
            breadth = bre;
        }

        public void setHeight(double hei)
        {
            height = hei;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box();
            Box box2 = new Box();
            Box box3 = new Box();
            double volume = 0.0;

            // data for box1
            box1.height = 5.0;
            box1.length = 6.0;
            box1.breadth = 7.0;

            // data for box2
            box2.height = 10.0;
            box2.length = 12.0;
            box2.breadth = 13.0;

            // data for box3
            box1.height = 12.0;
            box1.length = 45.0;
            box1.breadth = 10.0;

            // volume of box1
            volume = box1.getVolume();
            Console.WriteLine("Volume of Box1: {0}", volume);

            // volume of box2
            volume = box2.getVolume();
            Console.WriteLine("Volume of Box1: {0}", volume);

            // volumn of box3
            volume = box3.getVolume();
            Console.WriteLine("Volume of Box1: {0}", volume);
        }
    }
}
