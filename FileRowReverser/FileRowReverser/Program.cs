using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace FileRowReverser
{
    class Program
    {

        static void Main(string[] args)
        {
            //1000000 Sales Records.csv
            //~7.60
            if (File.Exists(@"..\Out.txt"))
            {
                File.Delete(@"..\Out.txt");
            }

            Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

            string file = @"..\" + Console.ReadLine();
            
            var reader = File
                .ReadAllLines(file)
                .Reverse();

            using (StreamWriter writer = new StreamWriter(@"..\Out.txt", false, Encoding.GetEncoding("UTF-8")))
            {
                foreach (var line in reader)
                {
                    string reversedLine = String.Join(" ", line.Split(new string[] { ",", "^", "|", ";", "    " }, StringSplitOptions.RemoveEmptyEntries).Reverse());
                    writer.WriteLine(reversedLine);
                }
            }
        }
    }
}