using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day7
{
    class RecursiveCircus
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            HashSet<string> used = new HashSet<string>();

            foreach (string line in lines)
            {
                string[] splLine = line.Split(new string[] { " -> " }, StringSplitOptions.None);

                if (splLine.Length == 1)
                {
                    
                    continue;
                }

                string[] cont = splLine[1].Split(new string[] { ", " }, StringSplitOptions.None);

                foreach (string name in cont)
                {
                    
                    used.Add(name);
                }
            }

            foreach (string line in lines)
            {
                string[] splLine = line.Split(new string[] { " -> " }, StringSplitOptions.None);

                if (splLine.Length == 1) continue;

                string[] cont = splLine[0].Split(' ');

                if (!used.Contains(cont[0]))
                {
                    Console.WriteLine(cont[0]);
                    CurrWeight(lines, cont[0]);
                    break;
                }
            }



            Console.ReadKey();
        }

        private static int CurrWeight(string[] lines, string name)
        {
            foreach (string line in lines)
            {
                string[] splLine = line.Split(new string[] { " -> " }, StringSplitOptions.None);

                string orName = (splLine[0].Split(' '))[0];

                if (!orName.Equals(name)) continue;

                int myWeight = Int32.Parse(Regex.Match((splLine[0].Split(' '))[1], @"\(([^)]*)\)").Groups[1].Value);
                
                if (splLine.Length == 1)
                {

                    return myWeight;
                }

                string[] cont = splLine[1].Split(new string[] { ", " }, StringSplitOptions.None);

                int expValue1 = 0;
                
                int temp;
                int count = 0;
                
                foreach (string subName in cont)
                {
                    
                    if (count == 0)
                    {
                        expValue1 = CurrWeight(lines, subName);
                       
                        count++;
                    }
                    else
                    {
                        temp = CurrWeight(lines, subName);
                        if (temp != expValue1)
                        {

                            Console.WriteLine(ValueOf(lines, subName) - temp + expValue1);
                            
                        }
                        count++;
                    }
                    

                }

                return expValue1 * cont.Length + myWeight;


            }

           
            return 0;
        }

        private static int ValueOf(string[] lines, string name)
        {
            foreach (string line in lines)
            {
                string[] splLine = line.Split(new string[] { " -> " }, StringSplitOptions.None);

                string orName = (splLine[0].Split(' '))[0];

                if (!orName.Equals(name)) continue;

                return Int32.Parse(Regex.Match((splLine[0].Split(' '))[1], @"\(([^)]*)\)").Groups[1].Value);
            }
            return 0;

        }

    }

}
