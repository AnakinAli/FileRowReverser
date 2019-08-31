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

            Directory.CreateDirectory(@"..\Chunks");

            Console.WriteLine("Wait 2 sec");
            Thread.Sleep(2000);
            Console.WriteLine("Started");
            Console.Clear();


            try
            {
                Console.WriteLine(DateTime.Now);
                Solution(file);
            }
            catch (Exception)
            {


            }
            finally
            {
                Console.WriteLine(DateTime.Now);
                Console.Beep(30000, 1000);
            }
        }

        public static void Solution(string file)
        {
            string realOutputFile = @"..\RealOutputFile.txt";

            var allOutputFileNames = new Stack<string>();

            string outputFileName = "";

            int chunkCounter = 1;

            using (var reader = new StreamReader(file, Encoding.GetEncoding("UTF-8")))
            {
                var lines = new Stack<string>();

                int rowCounter = 1;

                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (rowCounter++ == 1000000)
                    {
                        outputFileName = $@"..\Chunks\file_chunk_{chunkCounter++}.txt";

                        File.AppendAllLines(outputFileName, lines);
                        allOutputFileNames.Push(outputFileName);

                        rowCounter = 1;
                        lines.Clear();
                    }

                    lines.Push(String.Join(" ", line.Split(new string[] { ",", "|", "    ", "^" }, StringSplitOptions.RemoveEmptyEntries).Reverse()));
                }

                if (lines.Count > 0)
                {
                    outputFileName = $@"..\Chunks\file_chunk_{chunkCounter}.txt";
                    File.AppendAllLines(outputFileName, lines);
                    allOutputFileNames.Push(outputFileName);
                    lines.Clear();
                }
            }


            while (allOutputFileNames.Count > 0)
            {
                File.AppendAllLines(realOutputFile, File.ReadLines(allOutputFileNames.Pop()));
            }
        }
    }
}