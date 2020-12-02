using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Part1
{
    public class Program
    {
        private static readonly Program p = new Program();

        static void Main(string[] args)
        {
            var text = File.ReadAllLines(@"input.txt");

            List<string> values = text.ToList();

            List<string> validPassowrds = getValidPasswordList(values);

            Console.WriteLine($"There are {validPassowrds.Count()} valid passwords.");
        }

        private static List<string> getValidPasswordList(List<string> input)
        {
            List<string> output = new List<string>();

            string currentItem;

            foreach (var item in input)
            {
                currentItem = p.getValidPassword(item);

                if (currentItem != null) output.Add(currentItem);
            }
            return output;
        }

        public string getValidPassword(string input)
        {
            StringParser SP = new StringParser();

            List<string> info = input.Split(new char[0]).ToList();

            string pw = info[2];

            int min = SP.GetMin(info[0]);
            int max = SP.GetMax(info[0]);

            char key = SP.GetKeyChar(info[1]);

            if (pw.Count(x => x == key) >= min && pw.Count(y => y == key) <= max)
            {
                return pw;
            }

            return null;
        }
    }
}
