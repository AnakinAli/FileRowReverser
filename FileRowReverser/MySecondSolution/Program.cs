using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace MySecondSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //1+ min 
             Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

             string file = @"..\" + Console.ReadLine();

             var lines = new List<string>();

             using (TextFieldParser parser = new TextFieldParser(file))
             {
                 parser.Delimiters = new string[] { ",", "^", "|", ";", "    " };

                 var parts = parser.ReadFields().ToList();

                 while (parts != null)
                 {
                     parts.Reverse();
                     lines.Add(String.Join(" ", parts));
                     parts = parser.ReadFields().ToList();
                 }
             }

             lines.Reverse();

             File.WriteAllLines(@"..\Output.txt", lines);
             Console.WriteLine("Operation ended");

        }
    }
}