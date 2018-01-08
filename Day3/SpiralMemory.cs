using System;

namespace Day3
{
    class SpiralMemory
    {
        static void Main(string[] args)
        {
            Int32.TryParse(Console.ReadLine(), out int N);

            int c = 0;
            int odd = 1;

            while(N > odd*odd)
            {
                odd += 2;
                c++;
            }

            int dist;

            if (N <= 4 * c * c - 2 * c + 1)
            {
                dist = c + Math.Abs(N - (4 * c * c - 3 * c + 1));
            }
            else if(N <= 4 * c * c + 1)
            {
                dist = c + Math.Abs(N - (4 * c * c - c + 1));
            }
            else if(N <= 4 * c * c + 2 * c + 1)
            {
                dist = c + Math.Abs(N - (4 * c * c + c + 1));
            }
            else
            {
                dist = c + Math.Abs(N - (4 * c * c + 3 * c + 1));
            }

            Console.WriteLine(dist);
            Console.ReadKey();
        }

    }

}
