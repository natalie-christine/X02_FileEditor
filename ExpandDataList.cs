using System;
using System.Collections.Generic;

namespace A02_CSV
{
    internal class ExpandDataList
    {
        public List<Data> AddColumn(List<Data> dataList)
        {
            Console.WriteLine("Wie soll die neue Spalte benannt werden?");

            string columnName = Console.ReadLine() ?? "Unknown";

            foreach (Data data in dataList)
            {
                if (!data.AdditionalColumns.ContainsKey(columnName))
                {
                    data.AdditionalColumns[columnName] = ""; // Füge neue Spalte hinzu
                }
            }

            Console.WriteLine($"Spalte '{columnName}' wurde hinzugefügt.");
            return dataList;
        }
    }
}
