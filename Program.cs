using AssynchroneVerwerking;

int aantalIteraties = 10;
DateTime starttijd = DateTime.Now;
Console.WriteLine("Gestart op " + starttijd.ToString() + "\n");

// Creëer een aantal keer een object van traagheid, en laat achtereenvolgens wachten
for (int i = 0; i<aantalIteraties; i++)
{
    Traagheid traag = new Traagheid(i);
    traag.Wacht();
}

// Check of de methode Wacht ook voor alle objecten werd uitgevoerd
while (Traagheid.aantalKlaar < aantalIteraties)
{
    System.Threading.Thread.Sleep(20);
}

// Toon eindresultaten
DateTime einde = DateTime.Now;
TimeSpan tijdverschil = einde - starttijd;
Console.WriteLine("\nBeëindigd op {0} na {1}s, terwijl de som van alle wachttijden {2}s is.", einde.ToString(), tijdverschil, Traagheid.somAlleWachttijden);
