using System;
using System.IO;

namespace Day4
{
    class HighEntropyPassphrases
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
                string[] words = line.Split();
                int len = words.Length;
                
                bool unique1 = true;
                bool unique2 = true;

                for (int i = 0; i < len - 1; i++)
                {
                    for(int j = i + 1; j < len; j++)
                    {
                        if(words[i].Equals(words[j]))
                        {
                            unique1 = false;
                        }

                        if (IsAnagram(words[i], words[j]))
                        {
                            unique2 = false;
                        }
                    }
                }

                if (unique1)
                {
                    sum1++;
                }

                if (unique2)
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

        private static bool IsAnagram(string word1, string word2)
        {
            char[] letters1 = word1.ToCharArray();
            char[] letters2 = word2.ToCharArray();

            Array.Sort(letters1);
            Array.Sort(letters2);

            string NewWord1 = new string(letters1);
            string NewWord2 = new string(letters2);

            return NewWord1.Equals(NewWord2);
        }
    }

}
