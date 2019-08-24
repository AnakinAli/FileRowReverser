using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataWithPrepend
{
    class Program
    {
        static void Main(string[] args)
        {
            //1000000 Sales Records.csv
            string lines = String.Join("\n", File
                .ReadAllText(@"..\1000000 Sales Records.csv")
                .Split(new char[] { '\n'})
                .Select(l=>String.Join(" ",l.Split(',').Reverse()))
                .Reverse());

            File.WriteAllText(@"..\Output.txt", lines);
        }
    }
}