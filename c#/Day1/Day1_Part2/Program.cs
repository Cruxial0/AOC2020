using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines(@"input.txt");

            List<int> values = text.Select(s => int.Parse(s)).ToList();

            var result = getValues(values);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static List<int> getValues(List<int> values)
        {
            List<int> resultValues = new List<int>();

            int val1 = 0;
            int val2 = 0;
            int val3 = 0;

            for (int i = 0; i < values.Count; i++)
            {
                val1 = values[i];
                for (int j = 0; j < values.Count; j++)
                {
                    val2 = values[j];
                    for (int k = 0; k < values.Count; k++)
                    {
                        val3 = values[k];
                        if (is2020(val1, val2, val3))
                        {
                            if (resultValues.Contains(val1 * val2 * val3)) continue;
                            resultValues.Add(val1 * val2 * val3);
                        }
                    }
                }
            }

            return resultValues;
        }

        private static bool is2020(int val1, int val2, int val3)
        {
            if(val1 != 0 && val2 != 0 && val3 != 0)
            {
                if (val1 + val2 + val3 == 2020)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
