// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

namespace A02_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            UI uI = new UI();
            ReadCSV readCSV = new ReadCSV();    
            WriteCSV writeCSV = new WriteCSV();
           
        }
    }
}