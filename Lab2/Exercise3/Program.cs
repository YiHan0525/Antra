using System;

namespace Exercise3
{
    class Program
    {
        private static int PerfectSquares(int startIndex, int endIndex)
        {
            int count = (int)Math.Floor(Math.Sqrt(endIndex)) - (int)Math.Ceiling(Math.Sqrt(startIndex)) + 1;
            return count;
        }

        //Explanation:
        // Count the difference between square root of b and square root of
        // a + 1 is enough to find the number of perfect squares
        // between two given numbers

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
