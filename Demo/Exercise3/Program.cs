using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string myStr, rev;
            myStr = "Hello World";
            rev = "";
            Console.WriteLine("String is {0}", myStr);
            // find length
            int len;
            len = myStr.Length - 1;
            while (len >= 0)
            {
                rev = rev + myStr[len];
                len--;
            }
            Console.WriteLine("Reversed String is {0}", rev);
            Console.ReadLine();

        }

    }
}
