using CsvHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace ReadFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputfolder = ConfigurationManager.AppSettings["inputDataFolder"];
            string filesPattern = ConfigurationManager.AppSettings["Files"];
            string[] files = Directory.GetFiles(inputfolder, filesPattern);

            List<OutputLine> printOut = ReadFiles(files);
            printOut.ForEach(c => Console.WriteLine($"{c.DriverName}, {c.Order}"));

            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }

        public static List<OutputLine> ReadFiles(string[] files)
        {
            List<LineFile> output = new List<LineFile>();

            try
            {
                Parallel.ForEach(files, (currentFile) =>
                {
                    CsvReader csv = new CsvReader(new StreamReader(currentFile), CultureInfo.InvariantCulture);
                    csv.Configuration.Delimiter = ", ";
                    csv.Configuration.MissingFieldFound = null;
                    csv.Read();
                    csv.ReadHeader();
                    csv.Configuration.AutoMap<LineFile>();
                    var record = csv.GetRecords<LineFile>();
                    output.AddRange(record);
                    // Console.WriteLine($"Processing {currentFile} on thread {Thread.CurrentThread.ManagedThreadId}");
                });
                var printOut = (from record in output
                                orderby record.Order descending
                                select new OutputLine { DriverName = record.Name, Order = record.Order }).ToList();



                return printOut;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
