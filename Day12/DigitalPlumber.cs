using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day12
{
    class DigitalPlumber
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            int len = lines.Length;

            List < List < int > > connections = new List<List<int>>();

            foreach(string line in lines)
            {
                connections.Add(line.Split(new string[] { " <-> " }, StringSplitOptions.None)[1]
                    .Split(new string[] { ", " }, StringSplitOptions.None)
                    .Select(s => Int32.Parse(s))
                    .ToList());
            }

            HashSet < int > used = new HashSet < int >();

            int programNumber = CountPrograms(0, used, connections);

            Console.WriteLine("Group 0:");
            Console.WriteLine(programNumber);

            int distinct = 1;
            for(int i = 1; i < len; i++)
            {
                if(CountPrograms(i, used, connections) > 0)
                {
                    distinct++;
                }
            }

            Console.WriteLine("All groups:");
            Console.WriteLine(distinct);
            Console.ReadKey();
        }

        private static int CountPrograms(int node, HashSet<int> nodes, List<List<int>> conns)
        {
            int cont = 0;

            if(!nodes.Contains(node))
            {
                cont++;

                nodes.Add(node);

                foreach (int conn in conns[node])
                {
                    cont += CountPrograms(conn, nodes, conns);
                }
            }

            return cont;
        }

    }

}
