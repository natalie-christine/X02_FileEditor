using System;
using System.Collections.Generic;
using System.IO;

namespace A02_CSV
{
    public class WriteCSV
    {
        public void CSV_Writer(List<Data> dataList)
        {
            string outputPath = "C:\\Users\\nscho\\Documents\\B01\\CSV_Export.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("Datum,Zahl1,Zahl2,Text");

                    foreach (Data data in dataList)
                    {
                        writer.WriteLine(data.ToString());
                    }
                }

                Console.WriteLine("Data has been written to output file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to file: {ex.Message}");
            }
        }
    }
}
