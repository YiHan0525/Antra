using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, r, sum, temp;
            int stno, enno;

            Console.WriteLine("\n\n");
            Console.WriteLine("Find the Armstrong number for a given range of number: \n");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("Input starting number of range: ");
            stno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input ending number of range: ");
            enno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Armstrong number in given range are: ");
            for (num = stno; num <= enno; num++)
            {
                temp = num;
                sum = 0;

                while (temp != 0)
                {
                    r = temp % 10;
                    temp = temp / 10;
                    sum = sum + (r * r * r);
                }

                if (sum == num)
                    Console.WriteLine("{0}", num);
            }
            Console.WriteLine("\n");
        }
    }
}
