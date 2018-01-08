using System;
using System.IO;

namespace Day5
{
    class TwistyTrampolines
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);
            int len = lines.Length;

            int[] nums1 = Array.ConvertAll(lines, Int32.Parse);
            int sum1 = 0;
            int next1 = 0;

            while(next1 >= 0 && next1 < len)
            {
                nums1[next1]++;
                next1 += nums1[next1] - 1;
                sum1++;
            }

            int[] nums2 = Array.ConvertAll(lines, Int32.Parse);
            int sum2 = 0;
            int next2 = 0;

            while (next2 >= 0 && next2 < len)
            {
                if(nums2[next2] < 3)
                {
                    nums2[next2]++;
                    next2 += nums2[next2] - 1;
                }
                else
                {
                    nums2[next2]--;
                    next2 += nums2[next2] + 1;
                }

                sum2++;
            }

            Console.WriteLine("First sum:");
            Console.WriteLine(sum1);
            Console.WriteLine("Second sum:");
            Console.WriteLine(sum2);
            Console.ReadKey();
        }

    }

}
