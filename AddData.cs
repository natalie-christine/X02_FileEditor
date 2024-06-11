using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    internal class AddData
    {

        public void AddDataToDataList(List<Data> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                Console.WriteLine("Die Datenliste ist leer oder ungültig.");
                return;
            }

            Console.WriteLine("Geben Sie die neuen Daten ein:");

        
            Console.Write("Datum (dd.MM.yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDate))
            {
                Console.WriteLine("Ungültiges Datum. Abbruch.");
                return;
            }

            Console.Write("Zahl1: ");
            if (!decimal.TryParse(Console.ReadLine().Replace(".", ","), NumberStyles.Any, new CultureInfo("de-DE"), out decimal newNumber1))
            {
                Console.WriteLine("Ungültige Zahl1. Abbruch.");
                return;
            }

            Console.Write("Zahl2: ");
            if (!decimal.TryParse(Console.ReadLine().Replace(".", ","), NumberStyles.Any, new CultureInfo("de-DE"), out decimal newNumber2))
            {
                Console.WriteLine("Ungültige Zahl2. Abbruch.");
                return;
            }

            Console.Write("Text: ");
            string newText = Console.ReadLine();

            // Additional Column 
           
            Dictionary<string, string> newAdditionalColumns = new Dictionary<string, string>();

           
            if (dataList[0].AdditionalColumns.Count > 0)
            {
                foreach (var column in dataList[0].AdditionalColumns.Keys)
                {
                    Console.Write($"{column}: ");
                    newAdditionalColumns[column] = Console.ReadLine();
                }
            }

           
            Data newData = new Data(newDate, newNumber1, newNumber2, newText)
            {
                AdditionalColumns = newAdditionalColumns
            };

            
            dataList.Add(newData);

            Console.WriteLine("Neue Datenzeile erfolgreich hinzugefügt.");
        }
    }
  }

