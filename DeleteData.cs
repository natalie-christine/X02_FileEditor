using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    internal class DeleteData
    {

        public void DeleteDataFromDataList(List<Data> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                Console.WriteLine("Empty List");
                return;
            }

            Console.WriteLine("Welche Datehreihe soll entfernt werden?");

            UI.ShowDataList(dataList);

            string deletingRow = Console.ReadLine();


            int parseIndex = int.Parse(deletingRow);


            if (parseIndex > 0 && parseIndex < dataList.Count)
            {
              
                Data removedItem = dataList[parseIndex];
                dataList.RemoveAt(parseIndex);

                Console.WriteLine($"Die Datenreihe wurde erfolgreich entfernt:");
                Console.WriteLine($"{removedItem}");
            }
            else
            {
                Console.WriteLine("Ungültiger Index. Bitte geben Sie eine gültige Datenreihennummer ein.");
            }

        }
    }
}
