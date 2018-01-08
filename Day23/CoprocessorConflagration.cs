using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    class CoprocessorConflagration
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            int len = lines.Length;

            int[] registers = new int[8];
            registers[0] = 1;

            int sum = 0;

            int i = 0;

            while(i >= 0 && i < len)
            {
                string[] line = lines[i].Split();

                if (line[0].Equals("set"))
                {
                    if (line[2].First() < 97)
                    {
                        registers[line[1].First() - 97] = Int32.Parse(line[2]);
                    }
                    else
                    {
                        registers[line[1].First() - 97] = registers[line[2].First() - 97];
                    }
                }
                else if (line[0].Equals("sub"))
                {
                    if (line[2].First() < 97)
                    {
                        registers[line[1].First() - 97] -= Int32.Parse(line[2]);
                    }
                    else
                    {
                        registers[line[1].First() - 97] -= registers[line[2].First() - 97];
                    }
                }
                else if (line[0].Equals("mul"))
                {
                    sum++;

                    if (line[2].First() < 97)
                    {
                        registers[line[1].First() - 97] *= Int32.Parse(line[2]);
                    }
                    else
                    {
                        registers[line[1].First() - 97] *= registers[line[2].First() - 97];
                    }
                }
                else if (line[0].Equals("jnz"))
                {
                    if (line[1].First() < 97)
                    {
                        if (Int32.Parse(line[1]) != 0)
                        {
                            i += Int32.Parse(line[2]);
                            continue;
                        }
                    }
                    else
                    {
                        if (registers[line[1].First() - 97] != 0)
                        {
                            i += Int32.Parse(line[2]);
                            continue;
                        }
                    }
                }

                i++;
            }

            Console.WriteLine(sum);
            Console.WriteLine(registers[8]);
            Console.ReadKey();
        }

    }

}
