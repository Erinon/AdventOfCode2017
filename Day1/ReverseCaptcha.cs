using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class ReverseCaptcha
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string text = File.ReadAllText(fileName);

            int len = text.Length;
            int halfLen = len / 2;
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < len; i++)
            {
                if (text.ElementAt(i).Equals(text.ElementAt((i + 1) % len)))
                {
                    Int32.TryParse(text.ElementAt(i).ToString(), out int temp);
                    sum1 += temp;
                }
                if (text.ElementAt(i).Equals(text.ElementAt((i + halfLen) % len)))
                {
                    Int32.TryParse(text.ElementAt(i).ToString(), out int temp);
                    sum2 += temp;
                }
            }

            Console.WriteLine("First sum:");
            Console.WriteLine(sum1);
            Console.WriteLine("Second sum:");
            Console.WriteLine(sum2);
            Console.ReadKey();
        } 

    }

}
