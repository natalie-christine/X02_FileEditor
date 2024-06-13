using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A02_CSV
{
    public class WriteCSV
    {
        int version = 1;

        public void CSV_Writer(List<Data> dataList)
        {
            string outputPath = $"C:\\Users\\nscho\\Documents\\B01\\0{version}_OutputFile.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    // Schreibe den Header
                    if (dataList.Count > 0)
                    {
                        var standardHeaders = "Datum,Zahl1,Zahl2,Text";
                        var additionalHeaders = string.Join(",", dataList[0].AdditionalColumns.Keys);
                        var header = standardHeaders;

                        if (!string.IsNullOrEmpty(additionalHeaders))
                        {
                            header += "," + additionalHeaders;
                        }

                        writer.WriteLine(header);
                    }

                    // Schreibe die Daten
                    foreach (Data data in dataList)
                    {
                        writer.WriteLine(data.ToString());
                    }
                }

                // Console.WriteLine("Data has been written to output file.");
                version++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to file: {ex.Message}");
            }
        }
    }
}
