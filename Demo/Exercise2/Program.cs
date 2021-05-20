using System;

namespace Exercise2
{

    class Program
    {
        static void Main(string[] args)
        {
            int x, y, res;
            int ch;
            
            Console.WriteLine("Enter 1 For Addition:");
            Console.WriteLine("Enter 2 For Subtraction:");
            Console.WriteLine("Enter 3 For Multiplication:");
            Console.WriteLine("Enter 4 For Division");
            ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Two Numbers:");
                        x = Convert.ToInt32(Console.ReadLine());
                        y = Convert.ToInt32(Console.ReadLine());
                        res = x + y;
                        Console.WriteLine("Result is:" + res);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Two Numbers:");
                        x = Convert.ToInt32(Console.ReadLine());
                        y = Convert.ToInt32(Console.ReadLine());
                        res = x - y;
                        Console.WriteLine("Result is:" + res);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter Two Numbers:");
                        x = Convert.ToInt32(Console.ReadLine());
                        y = Convert.ToInt32(Console.ReadLine());
                        res = x * y;
                        Console.WriteLine("Result is:" + res);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter Two Numbers:");
                        x = Convert.ToInt32(Console.ReadLine());
                        y = Convert.ToInt32(Console.ReadLine());
                        res = x / y;
                        Console.WriteLine("Result is:" + res);
                        break;
                    }
            }
        }
    }
}
