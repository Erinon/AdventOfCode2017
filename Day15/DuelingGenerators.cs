
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    class DuelingGenerators
    {
        static void Main(string[] args)
        {
            int A1 = 591, B1 = 393;
            int A2 = 591, B2 = 393;
            int factA = 16807;
            int factB = 48271;
            int M = 2147483647;

            int numberOfPairs1 = 40000000;
            int numberOfPairs2 = 5000000;

            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < numberOfPairs1; i++)
            {
                A1 = (int)(((long)A1 * factA) % M);
                B1 = (int)(((long)B1 * factB) % M);

                if ((A1 & 0xFFFF) == (B1 & 0xFFFF))
                {
                    count1++;
                }
            }

            for (int i = 0; i < numberOfPairs2; i++)
            {
                while ((A2 = (int)(((long)A2 * factA) % M)) % 4 != 0) ;
                while ((B2 = (int)(((long)B2 * factB) % M)) % 8 != 0) ;

                if((A2 & 0xFFFF) == (B2 & 0xFFFF))
                {
                    count2++;
                }
            }

            Console.WriteLine("Final count1:");
            Console.WriteLine(count1);
            Console.WriteLine("Final count2:");
            Console.WriteLine(count2);
            Console.ReadKey();
        }

    }

}
