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
            if (File.Exists(@"..\Out.txt"))
            {
                File.Delete(@"..\Out.txt");
            }
            Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

            string file = @"..\" + Console.ReadLine();

            StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));

            List<string> lines = new List<string>();//max capacity ~<=200 000 000

            using (reader)
            {
                string line = "";
                int row = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    string newLine = string
                           .Join(" ", line
                           .Split(new string[] { ",", "^", "|", ";", "    " }, StringSplitOptions.RemoveEmptyEntries)
                           .Reverse());

                    if (row == 2000000)
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
//1000000 Sales Records.csv
//9.04 sec
/*    Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

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
  Console.WriteLine(String.Join(" ",lines));*/

//1+ min 
/* Console.Write("Enter the file's name, but you should move it into the bin folder first: ");

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
 Console.WriteLine("Operation ended");*/
