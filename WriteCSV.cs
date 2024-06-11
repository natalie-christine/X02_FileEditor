using System;
using System.Collections.Generic;
using System.IO;

namespace A02_CSV
{
    public class WriteCSV
    {
        int version = 1; 
        public void CSV_Writer(List<Data> dataList)
        {
            string outputPath = "C:\\Users\\nscho\\Documents\\B01\\0" + version +"_OutputFile.txt";

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
                version++; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to file: {ex.Message}");
            }
        }
    }
}
