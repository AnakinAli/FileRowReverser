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
            Console.WriteLine("Wait 2 sec");
            Thread.Sleep(2000);
            Console.WriteLine("Started");
            Console.Clear();
            Console.WriteLine(DateTime.Now);

            string file = @"C:\Users\anaki\source\repos\FileRowReverser\FileRowReverser\bin\Output.csv";
            //  string file = @"C:\Users\anaki\source\repos\FileRowReverser\FileRowReverser\bin\1000000 Sales Records.csv";


            string outputFile = @"..\Output.txt";

            //if (File.Exists(outputFile)) File.Delete(outputFile);

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

                            lines.Push(line);
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
    }
}