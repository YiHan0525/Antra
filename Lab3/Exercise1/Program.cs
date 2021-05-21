using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exercise1
{
    class Program
    {
        abstract class Shape1
        {
            protected float Result, Length, Breadth;
            public abstract float Area();
            public abstract float Circumference();
        }

        class Rectangle1 : Shape1
        {
            public void GetLB()
            {
                Console.WriteLine("Enter Length: ");
                Length = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Breadth: ");
                Breadth = float.Parse(Console.ReadLine());
            }

            public override float Area()
            {
                return Length * Breadth;
            }

            public override float Circumference()
            {
                return 2 * (Length + Breadth);
            }
        }

        class Circle1 : Shape1
        {
            public void GetRadius()
            {
                Console.WriteLine("Enter Radius: ");
                Result = float.Parse(Console.ReadLine());
            }

            public override float Area()
            {
                return 3.14F * Result * Result;
            }

            public override float Circumference()
            {
                return 2 * 3.14F * Result;
            }
        }
        class MainClass
        {
            public static void Calculate(Shape1 S)
            {
                Console.WriteLine("Area: {0}", S.Area());
                Console.WriteLine("Circumference : {0}", S.Circumference());
            }
            static void Main()
            {
                Rectangle1 R = new Rectangle1();
                R.GetLB();
                Calculate(R);

                Console.WriteLine();

                Circle1 C = new Circle1();
                C.GetRadius();
                Calculate(C);

                Console.Read();
            }
        }

    }
}
