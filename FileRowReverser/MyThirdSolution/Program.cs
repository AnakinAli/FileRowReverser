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

            string file = @"C:\Users\Anakin Ali\source\repos\ReversingBigFiles\bin\1000000 Sales Records.csv";

            if (fileSwitcher == 2)
            {
                file = @"C:\Users\Anakin Ali\source\repos\ReversingBigFiles\bin\10GBFile.csv";
            }

            //string outputFile = @"..\Output.txt";

            Console.WriteLine("Wait 2 sec");
            Thread.Sleep(2000);
            Console.WriteLine("Started");
            Console.Clear();

            Console.WriteLine(DateTime.Now);

            ThirdSolution(file);
            Console.WriteLine(DateTime.Now);
        }


        /* static void SecondSolution(string file, string outputFile)
         {
             Console.WriteLine("Wait 2 sec");
             Thread.Sleep(2000);
             Console.WriteLine("Started");
             Console.Clear();
             Console.WriteLine(DateTime.Now);

             //ReverseLineReader reverseReading = new ReverseLineReader(file);

             if (File.Exists(outputFile))
             {
                 File.Delete(outputFile);
             }

             try
             {
                 var lines = new List<string>();


                 using (var writer = new StreamWriter(outputFile))
                 {
                     foreach (var line in reverseReading)
                     {
                         string newLine = String.Join(" ", line
                             .Split(new string[] { ",", "     ", "|", "^" }, StringSplitOptions.RemoveEmptyEntries)
                             .Reverse());

                         double usedMemory = (double.Parse((new Microsoft.VisualBasic.Devices.ComputerInfo().AvailableVirtualMemory / Math.Pow(1024d, 3)).ToString("0.0")));
                         double totalMemory = (double.Parse((new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / Math.Pow(1024d, 3)).ToString("0.0")));
                         int percentOfFreeRam = (int)Math.Round((usedMemory * 100) / totalMemory);

                         if (percentOfFreeRam <= 46)
                         {
                             writer.WriteLine(String.Join("\n", lines));
                         }
                         lines.Add(newLine);
                     }
                     writer.WriteLine(String.Join("\n", lines));
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
             finally
             {
                 Console.WriteLine(DateTime.Now);
                 //Console.Beep(30000, 1000);
             }
         }*/

        static void FirstSolution(string file, string outputFile)
        {
            Console.WriteLine("Wait 2 sec");
            Thread.Sleep(2000);
            Console.WriteLine("Started");
            Console.Clear();
            Console.WriteLine(DateTime.Now);


            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            try
            {
                var lines = new Stack<string>();

                using (var writer = new StreamWriter(outputFile))
                {
                    using (var reader = new StreamReader(file))
                    {
                        string line = "";

                        while ((line = reader.ReadLine()) != null)
                        {
                            string newLine = String.Join(" ", line
                                                                 .Split(new string[] { ",", "     ", "|", "^" }, StringSplitOptions.RemoveEmptyEntries)
                                                                 .Reverse());

                            double usedMemory = (double.Parse((new Microsoft.VisualBasic.Devices.ComputerInfo().AvailableVirtualMemory / Math.Pow(1024d, 3)).ToString("0.0")));
                            double totalMemory = (double.Parse((new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / Math.Pow(1024d, 3)).ToString("0.0")));
                            int percentOfFreeRam = (int)Math.Round((usedMemory * 100) / totalMemory);

                            if (percentOfFreeRam <= 46)
                            {
                                while (lines.Count >= 1)
                                {
                                    writer.WriteLine(lines.Pop());
                                }
                            }

                            lines.Push(newLine);
                        }

                        while (lines.Count >= 1)
                        {
                            writer.WriteLine(lines.Pop());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(DateTime.Now);
                //Console.Beep(30000, 1000);
            }
        }

        public static void ThirdSolution(string file)
        {
            string realOutputFile = @"..\RealOutputFile.txt";

            List<string> allOutputFileNames = new List<string>();

            string outputFileName = "";

            int chunkCounter = 1;

            var fi = new FileInfo(file);
            double gb = fi.Length / 1024d / 1024d / 1024d;


            if (gb <= 0.5)
            {
                var reversedLines = File.ReadAllLines(file).Reverse();
                File.WriteAllLines(realOutputFile, reversedLines);
            }
            else
            {
                using (var reader = new StreamReader(file, Encoding.GetEncoding("UTF-8")))
                {
                    var directory = Directory.CreateDirectory(@"..\Chunks");

                    var lines = new Stack<string>();

                    int rowCounter = 1;

                    string line = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        string reversedLine = String.Join(" ", line.Split(new string[] { ",", "|", "    ", "^" }, StringSplitOptions.RemoveEmptyEntries).Reverse());

                        if (rowCounter++ == 1000001)
                        {
                            outputFileName = $@"..\file_chunk_{chunkCounter++}.txt";

                            File.AppendAllLines(outputFileName, lines);
                            allOutputFileNames.Add(outputFileName);
                            rowCounter = 1;
                            lines.Clear();
                        }

                        lines.Push(reversedLine);
                    }
                    if (lines.Count > 0)
                    {
                        outputFileName = $@"..\file_chunk_{chunkCounter++}.txt";

                        File.AppendAllLines(outputFileName, lines);
                        allOutputFileNames.Add(outputFileName);
                        lines.Clear();
                    }
                }

                for (int i = allOutputFileNames.Count - 1; i >= 0; i--)
                {
                    File.AppendAllLines(realOutputFile, File.ReadLines(allOutputFileNames[i]));
                }
            }
        }

    }
}