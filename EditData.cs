using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace A02_CSV
{
    public class EditData
    {
        public List<Data> DataEditor(List<Data> dataList)
        {
            Console.WriteLine("Welche Reihe möchtest du bearbeiten? (Nummer eingeben):");

            if (!int.TryParse(Console.ReadLine(), out int rowIndex) || rowIndex < 0 || rowIndex >= dataList.Count  )
            {
                Console.WriteLine("Ungültige Reihe.");
                return dataList;
            }
            
            Data selectedData = dataList[rowIndex-1];

            Console.WriteLine("Welche Spalte möchtest du bearbeiten?");
            Console.WriteLine("0 - Datum");
            Console.WriteLine("1 - Zahl1");
            Console.WriteLine("2 - Zahl2");
            Console.WriteLine("3 - Text");

            int extraColumnIndex = 4;
            foreach (var column in selectedData.AdditionalColumns.Keys)
            {
                Console.WriteLine($"{extraColumnIndex++} - {column}");
            }

            string columnChoice = Console.ReadLine();

            Console.WriteLine("Gib den neuen Wert ein:");
            string newValue = Console.ReadLine();

            switch (columnChoice)
            {
                case "0":
                    if (DateTime.TryParseExact(newValue, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDate))
                    {
                        selectedData.Date = newDate;
                        Console.WriteLine("Datum erfolgreich aktualisiert.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültiges Datum. Originalwert bleibt bestehen.");
                    }
                    break;

                case "1":
                    if (decimal.TryParse(newValue.Replace(".", ","), NumberStyles.AllowDecimalPoint, new CultureInfo("de-DE"), out decimal newNumber1))
                    {
                        selectedData.Number1 = newNumber1;
                        Console.WriteLine("Zahl1 erfolgreich aktualisiert.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Zahl1. Originalwert bleibt bestehen.");
                    }
                    break;

                case "2":
                    if (decimal.TryParse(newValue.Replace(".", ","), NumberStyles.Any, new CultureInfo("de-DE"), out decimal newNumber2))
                    {
                        selectedData.Number2 = newNumber2;
                        Console.WriteLine("Zahl2 erfolgreich aktualisiert.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Zahl2. Originalwert bleibt bestehen.");
                    }
                    break;

                case "3":
                    selectedData.Input = newValue;
                    Console.WriteLine("Text erfolgreich aktualisiert.");
                    break;

                default:
                    if (int.TryParse(columnChoice, out int additionalIndex) && additionalIndex >= 4 && additionalIndex < extraColumnIndex)
                    {
                        int actualIndex = additionalIndex - 4;
                        var columnKey = selectedData.AdditionalColumns.Keys.ElementAt(actualIndex);
                        selectedData.AdditionalColumns[columnKey] = newValue;
                        Console.WriteLine($"{columnKey} erfolgreich aktualisiert.");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Spalte.");
                    }
                    break;
            }

            return dataList;
        }
    }
}
