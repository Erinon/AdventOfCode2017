using System;
using System.IO;
using System.Linq;

namespace Day10
{
    class KnotHash
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string text = File.ReadAllText(fileName);

            int[] lengths1 = text.Split(',').Select(Int32.Parse).ToArray();

            int[] numbers1 = GenerateNumbers(255);

            int[] posAndSize = new int[] { 0, 0 };

            ProcessArray(numbers1, lengths1, posAndSize);

            Console.WriteLine("First output:");
            Console.WriteLine(numbers1[0] * numbers1[1]);

            string knotHash = GenerateKnotHash(text);

            Console.WriteLine("Knot Hash:");
            Console.WriteLine(knotHash);
            Console.ReadKey();
        }

        private static string ToKnotHash(int[] arr)
        {
            string ret = "";

            foreach(int num in arr)
            {
                string temp = num.ToString("x2");

                ret += temp;
            }

            return ret;
        }

        private static int[] ToDenseHash(int[] numbers)
        {
            int len = numbers.Length;
            int[] ret = new int[len / 16];

            for(int i = 0; i < len / 16; i++)
            {
                int xor = numbers[i * 16];

                for(int j = 1; j < 16; j++)
                {
                    xor = xor ^ numbers[i * 16 + j];
                }

                ret[i] = xor;
            }

            return ret;
        }

        private static void ProcessArray(int[] arr, int[] lengths, int[] pAndS)
        {
            int len = arr.Length;

            foreach(int length in lengths)
            {
                ReverseOrder(arr, pAndS[0], length);
                pAndS[0] = (pAndS[0] + length + pAndS[1]++ + len) % len;
            }
        }

        private static void ReverseOrder(int[] arr, int pos1, int length)
        {
            int len = arr.Length;

            int pos2 = (pos1 + length - 1 + len) % len;

            for(int i = 0; i < length / 2; i++)
            {
                int a1 = pos1;
                int a2 = pos2;
                arr[pos1] += arr[pos2];
                arr[pos2] = arr[pos1] - arr[pos2];
                arr[pos1] -= arr[pos2];

                pos1 = (pos1 + 1 + len) % len;
                pos2 = (pos2 - 1 + len) % len;
            }
        }

        private static int[] GenerateNumbers(int maxNum)
        {
            int[] ret = new int[maxNum + 1];

            for(int i = 0; i <= maxNum; i++)
            {
                ret[i] = i;
            }

            return ret;
        }

        private static string GenerateKnotHash(string input)
        {
            int[] posAndSize = new int[] { 0, 0 };

            int[] additionalLengths = new int[] { 17, 31, 73, 47, 23 };

            int[] Lengths = input.ToCharArray().Select(i => (int)i).ToArray()
                                    .Concat(additionalLengths).ToArray();

            int[] numbers = GenerateNumbers(255);

            for (int i = 0; i < 64; i++)
            {
                ProcessArray(numbers, Lengths, posAndSize);
            }

            int[] denseHash = ToDenseHash(numbers);

            string knotHash = ToKnotHash(denseHash);

            return knotHash;
        }

    }

}
