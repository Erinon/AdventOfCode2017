using System;
using System.IO;
using System.Linq;

namespace Day9
{
    class StreamProcessing
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string text = File.ReadAllText(fileName);

            int len = text.Length;

            int currLevel = 0;

            int sum1 = 0;
            int sum2 = 0;

            bool ignore = false;

            for(int i = 0; i < len; i++)
            {
                char currElement = text.ElementAt(i);

                if (currElement.Equals('!'))
                {
                    i++;
                    continue;
                }
                else if (currElement.Equals('<'))
                {
                    if (ignore) sum2++;
                    ignore = true;
                    continue;
                }
                else if (currElement.Equals('>'))
                {
                    ignore = false;
                    continue;
                }

                if (!ignore)
                {
                    if (currElement.Equals('{'))
                    {
                        currLevel++;
                        sum1 += currLevel;
                        continue;
                    }
                    else if (currElement.Equals('}'))
                    {
                        currLevel--;
                        continue;
                    }
                }
                else
                {
                    sum2++;
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
