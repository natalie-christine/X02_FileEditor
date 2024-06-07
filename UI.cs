using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A02_CSV
{
    public class UI
    {


        public void DisplayUI()
        {
            EditData editData = new EditData();
            ReadCSV readCSV = new ReadCSV();
            bool play = true;

            do
            {
                

                Console.WriteLine("Was möchtest du machen?");


                string[,] choices = {
                
                    {"0", "Show DataList"},
                    {"1", "Edit DataList"},
                    {"2", "Add Collum"},
                    {"3", "Add Row"},
                    {"4", " "},
                    {"5", "Exit"},
            };

                PrintTable(choices);


                int userInput = Convert.ToInt32(Console.ReadLine());


                switch (userInput)
                {

                    case 0:
                        Console.WriteLine("Hier wird die DatenListe angezeigt");
                        readCSV.CSV_Reader();
                        break;

                    case 1:
                        Console.WriteLine("Hier kannst du die Liste Bearbeiten");
                        editData.DataEditor();
                        break;
                    case 2:
                        Console.WriteLine("Hier kannst du eine neue Spalte hinzufügen");
                        editData.AddCollum();
                        break;

                    case 3:
                        Console.WriteLine("Hier kannst du einen Neue Reihe hinzufügen");
                        editData.AddRow();
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
                        break;


                }


            } while (play);
        }
       private static void PrintTable(String[,] choices)
            {

          Console.WriteLine("Was möchtest du tun?");

          for (int i = 0; i < choices.GetLength(0); i++)
                {
                Console.WriteLine($"{choices[i, 0]} {choices[i, 1]}");


                }
            }


    }
 
}
