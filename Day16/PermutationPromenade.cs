using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    class PermutationPromenade
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string text = File.ReadAllText(fileName);

            string[] moves = text.Split(',');

            char[] baseArr = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                                          'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'};
            int len = baseArr.Length;

            char[] programs = new char[len];

            baseArr.CopyTo(programs, 0);

            foreach(string move in moves)
            {
                char fun = move[0];

                string temp = move.Substring(1);

                string[] spl = temp.Split('/');

                switch(fun)
                {
                    case 's':
                        Spin(Int32.Parse(spl[0]), programs);
                        break;
                    case 'x':
                        Exchange(Int32.Parse(spl[0]), Int32.Parse(spl[1]), programs);
                        break;
                    case 'p':
                        Partner(spl[0][0], spl[1][0] , programs);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(new string(programs));

            int[] positions = new int[len];
 
            for (int i = 0; i < len; i++)
            {
                positions[i] = Array.IndexOf(programs, baseArr.ElementAt(i));
            }

            for (int i = 0; i < 999999999; i++)
            {
                UpdateArr(programs, positions);
            }


            char[] prg = new char[] { 'a', 'b', 'c', 'd', 'e' };
            Spin(1, prg);
            Console.WriteLine(new string(prg));
            Exchange(3, 4, prg);
            Console.WriteLine(new string(prg));
            Partner('e', 'b', prg);
            Console.WriteLine(new string(prg));
            Console.WriteLine(new string(programs));
            Console.ReadKey();
        }

        private static void UpdateArr(char[] arr, int[] indexes)
        {
            int len = arr.Length;
            char[] temp = new char[len];

            arr.CopyTo(temp, 0);

            for(int i = 0; i < len; i++)
            {
                arr[indexes[i]] = temp[i];
            }
        }

        private static void Spin(int X, char[] arr)
        {
            int len = arr.Length;
            char[] temp = new char[len];

            arr.CopyTo(temp, 0);

            for(int i = 0; i < len; i++)
            {
                arr[i] = temp[(len - X + i) % len];
            }
        }

        private static void Exchange(int A, int B, char[] arr)
        {
            char[] ret = new char[arr.Length];
            int bla = A;
            char temp = arr[A];
            arr[A] = arr[B];
            arr[B] = temp;
        }

        private static void Partner(char A, char B, char[] arr)
        {
            int len = arr.Length;

            Exchange(Array.IndexOf(arr, A), Array.IndexOf(arr, B), arr);
        }

    }

}
