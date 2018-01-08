using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class LikeRegisters
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            Dictionary<string, int> values = new Dictionary<string, int>();

            int max = 0;

            foreach(string line in lines)
            {
                string[] currLine = line.Split();

                if (!values.ContainsKey(currLine[4]))
                {
                    values.Add(currLine[4], 0);
                }
                if (!values.ContainsKey(currLine[0]))
                {
                    values.Add(currLine[0], 0);
                }

                string currReg = currLine[0];
                int ifReg = values[currLine[4]];
                string oper = currLine[5];
                Int32.TryParse(currLine[2], out int val);
                int diff = currLine[1].Equals("inc") ? val : -val;
                Int32.TryParse(currLine[6], out int ifVal);

                if (oper.Equals(">"))
                {
                    if (ifReg > ifVal)
                    {
                        values[currReg] += diff;
                    }
                }
                else if(oper.Equals("<"))
                {
                    if (ifReg < ifVal)
                    {
                        values[currReg] += diff;
                    }
                }
                else if (oper.Equals(">="))
                {
                    if (ifReg >= ifVal)
                    {
                        values[currReg] += diff;
                    }
                }
                else if (oper.Equals("<="))
                {
                    if (ifReg <= ifVal)
                    {
                        values[currReg] += diff;
                    }
                }
                else if (oper.Equals("=="))
                {
                    if (ifReg == ifVal)
                    {
                        values[currReg] += diff;
                    }
                }
                else if (oper.Equals("!="))
                {
                    if (ifReg != ifVal)
                    {
                        values[currReg] += diff;
                    }
                }

                if(values[currReg] > max)
                {
                    max = values[currReg];
                }
            }

            Console.WriteLine("First max:");
            Console.WriteLine(values.Values.Max());
            Console.WriteLine("Second max:");
            Console.WriteLine(max);
            Console.ReadKey();
        }

    }

}
