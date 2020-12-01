using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines(@"input.txt");

            int[] values = text.Select(s => int.Parse(s)).ToArray();

            var result = getValues(values);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static List<int> getValues(int[] values)
        {
            List<int> resultValues = new List<int>();

            int val1 = 0;
            int val2 = 0;

            for (int i = 0; i < values.Length; i++)
            {
                val1 = values[i];
                for (int j = 0; j < values.Length; j++)
                {
                    val2 = values[j];

                    if(is2020(val1, val2))
                    {
                        if (resultValues.Contains(val1 * val2)) continue;
                        resultValues.Add(val1 * val2);
                    }
                }
            }

            return resultValues;
        }

        private static bool is2020(int val1, int val2)
        {
            if (val1 + val2 == 2020)
                return true;

            return false;
        }
    }
}
