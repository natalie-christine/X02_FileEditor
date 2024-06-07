using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    internal class WriteCSV
    {
        public void CSV_Writer(List<Data> dataList)
        {

            try
            {
                string outputPath = "C:\\Users\\nscho\\Documents\\B02\\B00_output.txt";

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (Data data in dataList)
                    {
                        writer.WriteLine($"{data.Date},{data.Number1},{data.Number2},{data.Input}");
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
