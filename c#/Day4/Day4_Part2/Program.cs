using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Part2
{
    class Program
    {
        public static List<string> EyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        static void Main(string[] args)
        {
            var text = File.ReadAllLines(@"input.txt");

            List<string> values = text.ToList();

            var validPasses = ValidatePass(values);

            foreach(var pass in validPasses)
            {
                Console.WriteLine(pass.byr);
                Console.WriteLine(pass.iyr);
                Console.WriteLine(pass.eyr);
                Console.WriteLine(pass.hgt);
                Console.WriteLine(pass.hcl);
                Console.WriteLine(pass.ecl);
                Console.WriteLine(pass.pid + "\n");
            }

            Console.WriteLine(validPasses.Count);
        }

        private static List<Pass> ValidatePass(List<string> input)
        {
            List<string> vals = new List<string>();

            foreach (var line in input)
            {
                vals.AddRange(line.Split(null));
            }
            vals.Add("");
            string key = "";
            string value = "";

            List<Pass> ValidPasses = new List<Pass>();
            Pass pass = new Pass();

            int it = 0;
            foreach (var item in vals)
            {
                if (item == "")
                {
                    if (!IsAnyNullOrEmpty(pass)) ValidPasses.Add(pass);
                    pass = new Pass();
                    continue;
                }

                key = item.Substring(0, 3);
                value = item.Substring(4);

                bool isDigit;

                switch (key)
                {
                    case "byr":
                        isDigit = int.TryParse(value, out int val);
                        if (val >= 1920 && val <= 2002 && isDigit) pass.byr = val;
                        break;

                    case "iyr":
                        isDigit = int.TryParse(value, out int iyrVal);
                        if (iyrVal >= 2010 && iyrVal <= 2020 && isDigit) pass.iyr = iyrVal;
                        break;

                    case "eyr":
                        isDigit = int.TryParse(value, out int eyrVal);
                        if (eyrVal >= 2020 && eyrVal <= 2030 && isDigit) pass.eyr = eyrVal;
                        break;

                    case "hgt":
                        if (value.Length < 4 || value.Length > 5) break;
                        var height = value.Substring(0, value.Length - 2);
                        var def = value.Substring(value.Length - 2, 2);
                        isDigit = int.TryParse(height, out int hgtVal);

                        if (def == "cm" && hgtVal >= 150 && hgtVal <= 193 && isDigit) pass.hgt = value;
                        if (def == "in" && hgtVal >= 59 && hgtVal <= 76 && isDigit) pass.hgt = value;
                        break;

                    case "hcl":
                        if (value[0] != '#') break;

                        if (value.Length != 7) break;
                        List<char> validChars = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                        foreach (var Char in value.ToLower())
                        {
                            if (!validChars.Contains(Char)) break;
                        }
                        pass.hcl = value;
                        break;

                    case "ecl":
                        if(EyeColors.Contains(value)) pass.ecl = value;
                        break;

                    case "pid":
                        if (value.Length != 9) break;
                        isDigit = int.TryParse(value, out int pidVal);

                        if (value.Length == 9 && isDigit) pass.pid = pidVal;

                        break;
                }
                it++;
            }

            return ValidPasses;
        }

        public static bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
                if(pi.PropertyType == typeof(int))
                {
                    int intVal = (int)pi.GetValue(myObject);
                    if (intVal == 0) return true;
                }
            }
            return false;
        }
    }

    public class Pass
    {
        public int byr { get; set; }
        public int iyr { get; set; }
        public int eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public int pid { get; set; }
        //public string cid { get; set; } "optional"
    }
}
