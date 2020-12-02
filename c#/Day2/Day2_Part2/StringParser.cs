using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Part2
{
    public class StringParser
    {
        public int GetMin(string input)
        {
            var split = input.Split('-');

            return int.Parse(split[0]);
        }

        public int GetMax(string input)
        {
            var split = input.Split('-');

            return int.Parse(split[1]);
        }

        public char GetKeyChar(string input)
        {
            return input[0];
        }
    }
}
