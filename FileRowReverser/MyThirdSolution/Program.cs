using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MyThirdSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pick a number 1 or 2: ");

            int fileSwitcher = int.Parse(Console.ReadLine());

            string file = @"C:\Users\anaki\source\repos\FileRowReverser\FileRowReverser\bin\1000000 Sales Records.csv";

            if (fileSwitcher == 2)
            {
                file = @"C:\Users\anaki\source\repos\FileRowReverser\FileRowReverser\bin\10GBFile.csv";
            }
            Console.WriteLine("Wait 2 sec");
            Thread.Sleep(2000);
            Console.WriteLine("Started");
            Console.Clear();



            Console.WriteLine(DateTime.Now);
            Solution(file);
            Console.WriteLine(DateTime.Now);
            Console.Beep(30000, 1000);
        }

        public static void Solution(string file)
        {
            var allOutputFileNames = new Stack<string>();

            string outputFileName = @"..\file_chunk.txt";

            using (var reader = new StreamReader(file, Encoding.GetEncoding("UTF-8")))
            {
                var lines = new Stack<string>();

                int rowCounter = 1;

                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (rowCounter++ == 1000001)
                    {
                        File.AppendAllLines(outputFileName, lines);
                        rowCounter = 1;
                        lines.Clear();
                    }
                    lines.Push(String.Join(" ", line.Split(new string[] { ",", "|", "    ", "^" }, StringSplitOptions.RemoveEmptyEntries).Reverse()));
                }
            }
        }
    }
}