using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class MemoryReallocation
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string text = File.ReadAllText(fileName);

            int[] nums = Array.ConvertAll(text.Split('\t'), Int32.Parse);
            
            int len = nums.Length;

            LinkedList < string > used = new LinkedList < string > ();

            int sum1 = 0;

            while (!used.Contains(String.Join(",", nums)))
            {
                int max = FindMax(nums, len);
                
                used.AddLast(String.Join(",", nums));

                Redistribute(nums, len, max);

                sum1++;
            }

            int sum2 = Array.IndexOf(used.ToArray(), String.Join(",", nums));

            Console.WriteLine("First sum:");
            Console.WriteLine(sum1);
            Console.WriteLine("Second sum:");
            Console.WriteLine(sum1 - sum2);
            Console.ReadKey();
        }

        private static int FindMax(int[] nums, int len)
        {
            int max = 0;

            for(int i = 1; i < len; i++)
            {
                if(nums[i] > nums[max])
                {
                    max = i;
                }
            }

            return max;
        }

        private static void Redistribute(int[] nums, int len, int ind)
        {
            int num = nums[ind];
            nums[ind] = 0;

            while(num > 0)
            {
                ind = (ind + 1) % len;
                nums[ind]++;
                num--;
            }
        }

    }

}
