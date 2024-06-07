using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    internal class ReadCSV
    {
      
        WriteCSV writeCSV = new WriteCSV(); 

        public void CSV_Reader()
        {
            string path = "C:\\Users\\nscho\\Documents\\B01\\01_InputFile.txt";


            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            List<string> contentList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        contentList.Add(line);
                    }
                }

                List<Data> dataList = new List<Data>();

                int max = contentList.Count;

                for (int i = 0; i < max; i++)
                {
                    string[] parts = contentList[i].Split(',');

                    if (parts.Length == 4)
                    {
                        DateTime date;
                        decimal number1, number2;
                        string input;

                        if (DateTime.TryParse(parts[0], out date) &&
                            decimal.TryParse(parts[1], out number1) &&
                            decimal.TryParse(parts[2], out number2))
                        {
                            input = parts[3];
                            Data newData = new Data(date, number1, number2, input);
                            dataList.Add(newData);
                            Console.WriteLine(newData.ToString());
                        }


                    }
                    Console.ReadLine();

                }
                writeCSV.CSV_Writer(dataList);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }


}
