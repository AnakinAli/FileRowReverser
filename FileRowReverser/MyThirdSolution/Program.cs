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
            string outputFile = @"..\Out.txt";
            Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

            string file = @"..\" + Console.ReadLine();
            StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));

            List<string> lines = new List<string>(); //max capacity ~<=200 000 000

            using (reader)
            {
                
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    double usedMemory = (double.Parse((new Microsoft.VisualBasic.Devices.ComputerInfo().AvailableVirtualMemory / Math.Pow(1024d, 3)).ToString("0.00")));
                    double totalMemory = (double.Parse((new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / Math.Pow(1024d, 3)).ToString("0.00")));
                    var percentOfFreeRam = (usedMemory * 100) / totalMemory;

                    string newLine = string
                           .Join(" ", line
                           .Split(new string[] { ",", "^", "|", ";", "    " }, StringSplitOptions.RemoveEmptyEntries)
                           .Reverse());

                    if (percentOfFreeRam <= 25)
                    {
                        lines.Reverse();
                        File.AppendAllLines(outputFile, lines);
                        lines.Clear();
                    }
                    lines.Add(newLine);
                }
            }
            lines.Reverse();
            File.AppendAllLines(outputFile, lines);
        }
    }
}