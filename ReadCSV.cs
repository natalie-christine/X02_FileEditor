using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace A02_CSV
{
    internal class ReadCSV
    {
        WriteCSV writeCSV = new WriteCSV();

        public List<Data> CSV_Reader()
        {
            string path = "C:\\Users\\nscho\\Documents\\B01\\01_InputFile.csv";

            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Console.WriteLine("File does not exist");
                return new List<Data>();
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

                for (int i = 0; i < contentList.Count; i++)
                {
                    string[] parts = contentList[i].Split(',');

                    // Überspringe die Kopfzeile
                    if (i == 0)
                    {
                        continue; 
                       /* Data originalData = new Data(parts[0], parts[1], parts[2], parts[3]);
                        dataList.Add(originalData);
                       */
                    }

                    if (parts.Length >= 4 && i > 0)
                    {
                        DateTime date; decimal number1, number2;
                        string text = parts[3].Trim();

                        bool isDateValid = DateTime.TryParseExact( parts[0].Trim(), "dd.MM.yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out date );

                        bool isNumber1Valid = decimal.TryParse( parts[1], NumberFormatInfo.InvariantInfo, out number1 );

                        bool isNumber2Valid = decimal.TryParse( parts[2], NumberFormatInfo.InvariantInfo , out number2 );

                      
                        if (isDateValid && isNumber1Valid && isNumber2Valid)
                        {
                            Data newData = new Data(date, number1, number2, text);
                            dataList.Add(newData);
                       //    Console.WriteLine(newData);
                        }
                        else
                        {
                            if (!isDateValid)
                            {
                                Console.WriteLine($"Invalid date: {parts[0]}");
                            }
                            if (!isNumber1Valid)
                            {
                                Console.WriteLine($"Invalid number1: {parts[1]}");
                            }
                            if (!isNumber2Valid)
                            {
                                Console.WriteLine($"Invalid number2: {parts[2]}");
                            }
                   
                            Data originalData = new Data(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), text);
                            dataList.Add(originalData);
                        //    Console.WriteLine($"Original: {originalData}");
                        }
                    }
                }

                // Speichern der Daten
              //  writeCSV.CSV_Writer(dataList);
                return dataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Data>();
            }
        }
    }
}
