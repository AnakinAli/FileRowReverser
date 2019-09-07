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
            string file = @"C:\Users\anaki\source\repos\FileRowReverser\FileRowReverser\bin\1000000 Sales Records.csv";

            //1000000 Sales Records.csv

            Console.WriteLine(DateTime.Now);
            var lines = File
                .ReadLines(file)
                .Select(l => String.Join(" ", l.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Reverse()))
                .Reverse();
            
            for (int i = 0; i < 87; i++)
            {
                File.AppendAllLines(@"..\Output.txt", lines);
            }

            Console.WriteLine(DateTime.Now);
        }
    }
}