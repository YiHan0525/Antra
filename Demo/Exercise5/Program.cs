using System;

namespace Exxercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTriangle();
            BinaryTriangleFormated();
        }

        public static void BinaryTriangle()
        {
            int p, lastInt = 0, input;
            Console.WriteLine("Enter the Number of Rows: ");
            input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                for (p = 1; p <= i; p++)
                {
                    if (lastInt == 1)
                    {
                        Console.WriteLine("0");
                        lastInt = 0;
                    }
                    else if (lastInt == 0)
                    {
                        Console.WriteLine("1");
                        lastInt = 1;
                    }
                }
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }

        public static void BinaryTriangleFormated()
        {
            int i, j, k, numOfLine;
            Console.WriteLine("Enter the Number of Lines: ");
            numOfLine = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i <= numOfLine; i++)
            {
                for (k = numOfLine - i; k >= 1; k--)
                {
                    Console.WriteLine(" ");
                }

                if (i % 2 != 0)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (j % 2 == 0)
                        {
                            Console.WriteLine("0 ");
                        }
                        else
                        {
                            Console.WriteLine("1 ");
                        }
                    }
                }
                else if (i % 2 == 0)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (j % 2 == 0)
                        {
                            Console.WriteLine("1 ");
                        }
                        else
                        {
                            Console.WriteLine("0 ");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

    
}
