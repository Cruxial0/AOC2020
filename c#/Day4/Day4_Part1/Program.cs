using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines(@"input.txt");

            List<string> values = text.ToList();

            var validPasses = ValidatePass(values);

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
                Console.WriteLine(item);

                if(item == "" || it == vals.Count - 1)
                {
                    if(!IsAnyNullOrEmpty(pass)) ValidPasses.Add(pass);
                    pass = new Pass();
                    continue;
                }

                key = item.Substring(0, 3);
                value = item.Substring(4);

                switch(key)
                {
                    case "byr":
                        pass.byt = value;
                        break;

                    case "iyr":
                        pass.iyr = value;
                        break;

                    case "eyr":
                        pass.eyr = value;
                        break;

                    case "hgt":
                        pass.hgt = value;
                        break;

                    case "hcl":
                        pass.hcl = value;
                        break;

                    case "ecl":
                        pass.ecl = value;
                        break;

                    case "pid":
                        pass.pid = value;
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
            }
            return false;
        }
    }

    public class Pass
    {
        public string byt { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        //public string cid { get; set; } "optional"
    }
}
