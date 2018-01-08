using System;
using System.IO;

namespace Day2
{
    class CorruptionChecksum
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            int sum1 = 0;
            int sum2 = 0;

            foreach (string line in lines)
            {
                string[] nums = line.Split('\t');
                int len = nums.Length;

                Int32.TryParse(nums[0], out int min);
                int max = min;

                foreach(string num in nums)
                {
                    Int32.TryParse(num, out int temp);
                    
                    if (temp > max)
                    {
                        max = temp;
                    }
                    if (temp < min)
                    {
                        min = temp;
                    }
                }
                sum1 += max - min;

                for(int i = 0; i < len - 1; i++)
                {
                    for(int j = i + 1; j < len; j++)
                    {
                        sum2 += Divisible(nums[i], nums[j]);
                    }
                }
            }

            Console.WriteLine("First sum:");
            Console.WriteLine(sum1);
            Console.WriteLine("Second sum:");
            Console.WriteLine(sum2);
            Console.ReadKey();
        }

        private static int Divisible(string X, string Y)
        {
            Int32.TryParse(X, out int A);
            Int32.TryParse(Y, out int B);
            if (A % B == 0)
            {
                return A / B;
            }
            if (B % A == 0)
            {
                return B / A;
            }
            return 0;
        }

    }

}
