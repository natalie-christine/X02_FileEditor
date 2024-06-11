using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    internal class ExpandDataList
    {

        public List<Data> AddColumn(List<Data> dataList)
        {


            Console.WriteLine("Wie soll die neue Spalte benennt werden?");

            String columnName = Console.ReadLine() ?? "Unknown";

            foreach (Data data in dataList)
            {

                data.AdditionalColumns[columnName] = " ";

            }

            Console.WriteLine($"Spalte '{columnName}' wurde hinzugefügt.");

            return dataList;
        }
    }
}
