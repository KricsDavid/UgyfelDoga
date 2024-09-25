using Doga;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



class Program
{
    static List<Ugyfel> ugyfelek = new List<Ugyfel>();

    static void Main(string[] args)
    {
        Beolvasas("ugyfelek.txt");
        Szures();
        AtlagosUtazasokSzama();
        LegaktívabbUgyfel();
        UjUgyfelFelvetele();
    }

    

    static void Beolvasas(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0]);
            string nev = parts[1];
            int kor = int.Parse(parts[2]);
            string orszag = parts[3];
            int utazasokSzama = int.Parse(parts[4]);

            Ugyfel ugyfel = new Ugyfel(id, nev, kor, orszag, utazasokSzama);
            ugyfelek.Add(ugyfel);
        }
    }

    static void Szures()
    {
        var szurtUgyfelek = ugyfelek.Where(u => u.UtazasokSzama > 3).ToList();
        Console.WriteLine("Ügyfelek, akik több mint 3 alkalommal utaztak:");
        foreach (var ugyfel in szurtUgyfelek)
        {
            Console.WriteLine($"{ugyfel.Id},{ugyfel.Nev} - Utazások száma: {ugyfel.UtazasokSzama}");
        }
    }

    static void AtlagosUtazasokSzama()
    {
        double atlag = ugyfelek.Average(u => u.UtazasokSzama);
        Console.WriteLine( $"Átlagos utazások száma: {atlag}");
    }
    // én elmentem a vásárba fél pénzzel 
    // O1G Orbán egy Géniusz
    static void LegaktívabbUgyfel()
    {
        int maxUtazasokSzama = ugyfelek.Max(u => u.UtazasokSzama);
        var legaktívabbUgyfelek = ugyfelek.Where(u => u.UtazasokSzama == maxUtazasokSzama).ToList();

        Console.WriteLine("Legaktívabb ügyfelek:");
        foreach (var ugyfel in legaktívabbUgyfelek)
        {
            Console.WriteLine($"{ugyfel.Id},{ugyfel.Nev} - Utazások száma: {ugyfel.UtazasokSzama}");
        }
    }

    static void UjUgyfelFelvetele()
    {
        Console.WriteLine("Új ügyfél adatai (Név, Kor, Ország, Utazások száma). Írd be a 'vége' szót a befejezéshez:");
        int nextId = 101;

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "vége") break;

            var parts = input.Split(',');
            if (parts.Length == 4 && int.TryParse(parts[1], out int kor) && int.TryParse(parts[3], out int utazasokSzama))
            {
                Ugyfel ujUgyfel = new Ugyfel(nextId++, parts[0], kor, parts[2], utazasokSzama);
                ugyfelek.Add(ujUgyfel);
                Console.WriteLine("Új ügyfél hozzáadva.");
            }
            else
            {
                Console.WriteLine("Hibás adatbevitel. Kérlek, próbáld újra.");
            }

            
            Console.WriteLine("Újraszámolt értékek:");
            Szures();
            AtlagosUtazasokSzama();
            LegaktívabbUgyfel();
            Console.WriteLine("Következő felhasználó:");
        }
    }
}
