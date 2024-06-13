namespace A02_CSV
{
    public class UI
    {
        public static void DisplayUI()
        {
            EditData editData = new EditData();
            ReadCSV readCSV = new ReadCSV();
            WriteCSV writeCSV = new WriteCSV();
            ExpandDataList expandDataList = new ExpandDataList();
            AddData addData = new AddData();
            DeleteData deleteData = new DeleteData();
            List<Data> dataList = readCSV.CSV_Reader();
            bool play = true;

            do
            { 
                string[,] choices = {
                    {"0", "DataList anzeigen"},
                    {"1", "DataList bearbeiten"},
                    {"2", "DataList speichern"},
                    {"3", "Spalte hinzufügen"},
                    {"4", "Daten hinzugügen"},
                    {"5", "Datenreihe löschen"},
                    {"6", "Exit"},
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
                        Console.WriteLine("Hier kannst du die Daten in der Liste bearbeiten");
                        dataList = editData.DataEditor(dataList); 
                        break;

                    case 2:
                        Console.WriteLine("DatenListe wurde gespeichert.");
                      new WriteCSV().CSV_Writer(dataList);  
                        break;

                    case 3:
                        Console.WriteLine("Hier kannst du die Datenliste erweitern");
                        new ExpandDataList().AddColumn(dataList);
                        break;

                    case 4:
                        Console.WriteLine("Hier kannst du neue Daten hinzufügen");
                        addData.AddDataToDataList(dataList); 
                        break;
            

                    case 5:
                        Console.WriteLine("Hier kannst du eine Datenreihe löschen");
                        deleteData.DeleteDataFromDataList(dataList);   
                        break;

                    case 6:
                        Console.WriteLine("Auf Wiedersehen! ");
                        play = false;
                        Thread.Sleep(1000);
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

        public static void ShowDataList(List<Data> dataList)
        {
            if (dataList.Count == 0)
            {
                Console.WriteLine("Die Datenliste ist leer.");
                return;
            }

            // Header anzeigen
            var standardHeaders = "Datum,Zahl1,Zahl2,Text";
            var additionalHeaders = string.Join(",", dataList[0].AdditionalColumns.Keys);
            var header = standardHeaders;

            if (!string.IsNullOrEmpty(additionalHeaders))
            {
                header += "," + additionalHeaders;
            }

            Console.WriteLine($"0. {header}");

            // Daten anzeigen
            for (int i = 0; i < dataList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dataList[i]}");
            }
            Console.WriteLine();
        }
    }
}

