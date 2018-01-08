using System;
using System.IO;

namespace Day13
{
    class PacketScanners
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            int sum = 0;

            foreach(string line in lines)
            {
                string[] newLine = line.Split(new string[] { ": " }, StringSplitOptions.None);

                Int32.TryParse(newLine[0], out int key);
                Int32.TryParse(newLine[1], out int value);

                if(key % (2*value - 2) == 0)
                {
                    sum += key * value;
                }

            }

            Console.WriteLine("Severity:");
            Console.WriteLine(sum);

            bool found = false;
            int i;

            for (i = 0; !found ; i++)
            {
                found = true;

                foreach (string line in lines)
                {
                    string[] newLine = line.Split(new string[] { ": " }, StringSplitOptions.None);

                    Int32.TryParse(newLine[0], out int key);
                    Int32.TryParse(newLine[1], out int value);
                    
                    if ((key + i) % (2 * value - 2) == 0)
                    {
                       found = false ;
                    }
                }
            }

            Console.WriteLine("Delay:");
            Console.WriteLine(i - 1);
            Console.ReadKey();
        }

    }

}
