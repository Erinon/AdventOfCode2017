using System;
using System.IO;

namespace Day11
{
    class HexEd
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string text = File.ReadAllText(fileName);

            string[] directions = text.Split(',');
            
            int x = 0; int y = 0;

            int maxDistance = 0;

            foreach(string direction in directions)
            {
                switch(direction)
                {
                    case "n":
                        y++;
                        break;
                    case "ne":
                        x++;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        y--;
                        break;
                    case "sw":
                        x--;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    default:
                        break;
                }

                if(MaxValue(x, y, -(x + y)) > maxDistance)
                {
                    maxDistance = MaxValue(x, y, -(x + y));
                }
            }

            int distance = MaxValue(x, y, -(x + y));

            Console.WriteLine("Distance:");
            Console.WriteLine(distance);
            Console.WriteLine("Maximal distance:");
            Console.WriteLine(maxDistance);
            Console.ReadKey();
        }

        private static int MaxValue(int a, int b, int c)
        {
            return a > b ? (a > c ? a : c) : (b > c ? b : c);
        }

    }

}
