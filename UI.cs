namespace A02_CSV
{
    public class UI
    {
        public static void DisplayUI()
        {
            EditData editData = new EditData();
            ReadCSV readCSV = new ReadCSV();
            WriteCSV writeCSV = new WriteCSV();
            List<Data> dataList = readCSV.CSV_Reader();
            bool play = true;

            do
            { 
                string[,] choices = {
                    {"0", "Show DataList"},
                    {"1", "Edit DataList"},
                    {"2", "Save DataList"},
             /*        {"3", "Add Row/ Collum"},
                    {"4", "delete"}, */
                    {"5", "Exit"},
                };

                PrintTable(choices);
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 0:
                        Console.WriteLine("Hier wird die DatenListe angezeigt");                     
                        ShowDataList(dataList);
                        break;

                    case 1:
                        Console.WriteLine("Hier kannst du die Liste Bearbeiten");
                        dataList = editData.DataEditor(dataList); 
                        break;

                    case 2:
                        Console.WriteLine("Hier kannst du die Daten speichern");
                        writeCSV.CSV_Writer(dataList);  
                        break;

                    case 3:
                        Console.WriteLine("Hier kannst du eine Neue Reihe hinzufügen");
                     //   editData.AddRow();
                        break;

                    case 4:
                        Console.WriteLine(". . . . .");
                        break;
            

                    case 5:
                        Console.WriteLine("Auf Wiedersehen! ");
                        play = false;
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        continue;
                }
            } while (play);
        }

        private static void PrintTable(string[,] choices)
        {
            Console.WriteLine("Was möchtest du tun?");
            for (int i = 0; i < choices.GetLength(0); i++)
            {
                Console.WriteLine($"{choices[i, 0]} {choices[i, 1]}");
            }
        }

        private static void ShowDataList(List<Data> dataList)
        {
            foreach (var data in dataList)
            {
                Console.WriteLine(data);
            }
        }
    }
}
