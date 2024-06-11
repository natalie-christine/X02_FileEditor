using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace A02_CSV
{
    public class EditData
    {
        Data data; 

        public List<Data> DataEditor(List<Data> dataList)
        {
            Console.WriteLine("Welche Reihe möchtest du bearbeiten? (Nummer eingeben):");
            if (!int.TryParse(Console.ReadLine(), out int rowIndex) || rowIndex < 0 || rowIndex >= dataList.Count)
            {
                Console.WriteLine("Ungültige Reihe.");
                return null;
            }

            Data selectedData = dataList[rowIndex];

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

            switch (columnChoice)
            {
                case "0":
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDate))
                    {
                        selectedData.Date = newDate;
                        selectedData.OriginalDate = null;  
                    }
                    else
                    {
                        Console.WriteLine("Ungültiges Datum. Originalwert bleibt bestehen.");
                    }
                    break;



                case "1":
                    if (decimal.TryParse(Console.ReadLine().Replace(".", ","), NumberStyles.AllowDecimalPoint, new CultureInfo("de-DE"), out decimal newNumber1))
                    {
                        selectedData.Number1 = newNumber1;
                        selectedData.OriginalNumber1 = null;  
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Zahl1. Originalwert bleibt bestehen.");
                    }
                    break;


                case "2":

                    if (decimal.TryParse(Console.ReadLine().Replace(".", ","), NumberStyles.Any, new CultureInfo("de-DE"), out decimal newNumber2))
                    {
                        selectedData.Number2 = newNumber2;
                        selectedData.OriginalNumber2 = null;  
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Zahl2. Originalwert bleibt bestehen.");
                    }
                    break;


                case "3":
                    selectedData.Input = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ungültige Spalte.");
                    break;

            }
            return dataList;

            Console.WriteLine("Wert wurde erfolgreich aktualisiert.");
        }


    }
}
