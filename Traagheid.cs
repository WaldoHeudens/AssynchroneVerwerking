using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssynchroneVerwerking
{
    internal class Traagheid
    {
        public static int aantalKlaar = 0;  // Hoeveel asynchrone "Wachts" werden uitgevoerd?
        public static double somAlleWachttijden = 0;   // De totale tijd in seconden besteed aan wachten 

        public int Id { get; set; }

        public Traagheid(int id)
        {
            Id = id;
        }

        public async void Wacht()
        {
            // Definieer een nieuwe delegate van type Func<int> die GetWachttijd uitvoerd
            Func<int> asyncMetode = new Func<int>(GetWachttijd);

            // Voer deze delegate uit in een nieuwe thread (asynchroon) en zet het resultaat in wachttijd
            int wachttijd = await Task.Factory.StartNew(asyncMetode);

            // Als de methode klaar is:  Verwerk de resultaten
            Console.WriteLine("Klaar met {0} na {1}ms", Id, wachttijd);
            aantalKlaar++;
            somAlleWachttijden += wachttijd/1000;
        }

        private int GetWachttijd()
        {
            // wacht een random tijd tussen 0 en 2 seconden en return deze tijd

            int wachttijd = new Random().Next(2000);
            System.Threading.Thread.Sleep(wachttijd);
            return wachttijd;
        }
    }
}
