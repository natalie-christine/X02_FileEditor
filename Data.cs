using System;
using System.Globalization;

namespace A02_CSV
{
    public class Data
    {
        public DateTime? Date { get; set; }
        public decimal? Number1 { get; set; }
        public decimal? Number2 { get; set; }
        public string Input { get; set; }

        public Dictionary<string, string> AdditionalColumns { get; set; } = new Dictionary<string, string>();



        public string OriginalDate { get; set; }
        public string OriginalNumber1 { get; set; }
        public string OriginalNumber2 { get; set; }

        // Konstruktor für erfolgreiche Parsing-Ergebnisse
        public Data(DateTime date, decimal number1, decimal number2, string input)
        {
            Date = date;
            Number1 = number1;
            Number2 = number2;
            Input = input;
        }

        // Konstruktor für fehlgeschlagene Parsing-Ergebnisse
        public Data(string originalDate, string originalNumber1, string originalNumber2, string input)
        {
            OriginalDate = originalDate;
            OriginalNumber1 = originalNumber1;
            OriginalNumber2 = originalNumber2;
            Input = input;
        }
      
        public override string ToString()
        {
            string additionalColumns = string.Join(",", AdditionalColumns.Select(kv => kv.Value));
            if (Date.HasValue && Number1.HasValue && Number2.HasValue)
            {
           
                return $"{Date:dd.MM.yyyy},{Number1.Value.ToString("0.##", NumberFormatInfo.InvariantInfo)},{Number2.Value.ToString("0.##", NumberFormatInfo.InvariantInfo)},{Input}{(string.IsNullOrEmpty(additionalColumns) ? "" : "," + additionalColumns)}";
            }
            else
            {
                return $"{OriginalDate},{OriginalNumber1},{OriginalNumber2},{Input}";
            }

        }


    }
}
