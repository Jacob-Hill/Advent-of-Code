using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PasswordChecker());
            Console.Read();
        }

        static List<string> ReadTxtFile(string filename)
        {
            string location = "Inputs/" + filename;
            List<string> result = new List<string>();
            StreamReader file = new StreamReader(location);
            string fileStr = file.ReadToEnd();
            string[] array = fileStr.Split("\n");
            for(int i = 0; i<array.Length; i++)
            {
                result.Add(array[i]);
            }
            return (result);
        }

        static int Sum2To2020()
        {
            List<string> inputStrings = ReadTxtFile("Day1.txt");
            List<int> input = new List<int>();
            for(int i = 0; i<inputStrings.Count; i++)
            {
                input.Add(int.Parse(inputStrings[i]));
            }
            for(int i1 = 0; i1<input.Count; i1++)
            {
                for(int i2 = 1; i2<input.Count; i2++)
                {
                    if (i2 != i1)
                    {
                        if (input[i1] + input[i2] == 2020)
                        {
                            return input[i1] * input[i2];
                        }
                    }
                }
            }
            return 0;
        }

        static int Sum3To2020()
        {
            List<string> inputStrings = ReadTxtFile("Day1.txt");
            List<int> input = new List<int>();
            for (int i = 0; i < inputStrings.Count; i++)
            {
                input.Add(int.Parse(inputStrings[i]));
            }
            for (int i1 = 0; i1 < input.Count; i1++)
            {
                for (int i2 = 1; i2 < input.Count; i2++)
                {
                    for (int i3 = 2; i3 < input.Count; i3++)
                    {
                        if (i2 != i1 && i2 != i3 && i1 != i3)
                        {
                            if (input[i1] + input[i2] + input[i3] == 2020)
                            {
                                return input[i1] * input[i2] * input[i3];
                            }
                        }
                    }
                }
            }
            return 0;
        }

        static int PasswordChecker()
        {
            List<string> input = ReadTxtFile("Day2.txt");
            List<string[]> splitInput = new List<string[]>();
            int result = 0;
            for (int a = 0; a<input.Count; a++)
            {
                splitInput.Add(input[a].Replace(" ","").Replace("\r","").Split(':'));
            }
            for(int i1 = 0; i1<splitInput.Count; i1++)
            {
                bool hyphen = false;
                string minS = "";
                string maxS = "";
                char letter = ' ';
                for (int i2 = 0; i2<splitInput[i1][0].Length; i2++)
                {
                    if (!hyphen)
                    {
                        if (int.TryParse(splitInput[i1][0][i2].ToString(), out int extra))
                        {
                            minS += splitInput[i1][0][i2];
                        }
                        else
                        {
                            hyphen = true;
                        }
                    }
                    else if (hyphen)
                    {
                        if (int.TryParse(splitInput[i1][0][i2].ToString(), out int extra))
                        {
                            maxS += splitInput[i1][0][i2];
                        }
                        else
                        {
                            letter = splitInput[i1][0][i2];
                        }
                    }
                }
                int minI = int.Parse(minS);
                int maxI = int.Parse(maxS);
                int counter = 0;
                for(int i3 = 0; i3<splitInput[i1][1].Length; i3++)
                {
                    if (splitInput[i1][1][i3] != letter)
                    {
                        counter++;
                    }
                }
                if (counter > minI && counter < maxI)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
