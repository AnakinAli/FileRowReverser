using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThirdSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

            string file = @"..\" + Console.ReadLine();
            StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));

            List<string> lines = new List<string>(); //max capacity ~<=200 000 000

            using (reader)
            {
                string line = "";
                int row = 0;
                int maxListCount = 2000000;


                while ((line = reader.ReadLine()) != null)
                {
                    string newLine = string
                           .Join(" ", line
                           .Split(new string[] { ",", "^", "|", ";", "    " }, StringSplitOptions.RemoveEmptyEntries)
                           .Reverse());

                    if (row == maxListCount)
                    {
                        lines.Reverse();
                        File.AppendAllLines(@"..\Out.txt", lines);
                        lines.Clear();
                        row = 0;
                    }

                    lines.Add(newLine);
                    row++;
                }
            }
            lines.Reverse();
            File.AppendAllLines(@"..\Out.txt", lines);
        }
    }
}