using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //9.04 sec
            Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

            string file = @"..\Output.csv";

            var lines = File
                 .ReadAllLines(file)
                 .Select(l =>
                     String.Join(" ",
                     l
                     .Split(new string[] { ",", "^", "|", ";", "    " }, StringSplitOptions.RemoveEmptyEntries)
                     .Reverse())
                  )
                 .ToList();
            lines.Reverse();
            File.WriteAllLines(@"..\Output.txt", lines);

        }
    }
}