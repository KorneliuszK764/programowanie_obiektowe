using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

// Zadanie 1: Zapisanie numeru albumu do pliku
class AlbumWriter
{
    public static void SaveAlbumNumber(string filename)
    {
        string albumNumber = "70779";
        File.WriteAllText(filename, albumNumber);
        Console.WriteLine("Numer albumu 70779 zapisany do pliku.");
    }
}

// Zadanie 2: Odczyt zawartości pliku
class FileReader
{
    public static void ReadFile(string filename)
    {
        if (File.Exists(filename))
        {
            string content = File.ReadAllText(filename);
            Console.WriteLine("Zawartość pliku:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
        }
    }
}

// Zadanie 3: Sprawdzenie liczby żeńskich PESEL-i
class PeselAnalyzer
{
    public static int CountFemalePesels(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Plik PESEL-i nie istnieje.");
            return 0;
        }
        
        try
        {
            string[] pesels = File.ReadAllLines(filename);
            int femaleCount = pesels.Count(p => p.Length == 11 && int.TryParse(p[9].ToString(), out int digit) && digit % 2 == 0);
            Console.WriteLine($"Liczba żeńskich PESEL-i: {femaleCount}");
            return femaleCount;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas analizy PESEL-i: {ex.Message}");
            return 0;
        }
    }
}

// Zadanie 4: Analiza populacji z pliku JSON
class PopulationAnalyzer
{
    public class PopulationRecord
    {
        public string Country { get; set; }
        public int Year { get; set; }
        public long Value { get; set; }
    }

    public static List<PopulationRecord> LoadPopulationData(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Plik bazy danych nie istnieje.");
            return new List<PopulationRecord>();
        }
        
        try
        {
            string json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<PopulationRecord>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas wczytywania danych populacji: {ex.Message}");
            return new List<PopulationRecord>();
        }
    }

    public static long GetPopulationDifference(List<PopulationRecord> data, string country, int year1, int year2)
    {
        var pop1 = data.FirstOrDefault(p => p.Country == country && p.Year == year1)?.Value ?? 0;
        var pop2 = data.FirstOrDefault(p => p.Country == country && p.Year == year2)?.Value ?? 0;
        return pop2 - pop1;
    }
}

// Główna funkcja programu
class Program
{
    static void Main()
    {
        string dbFile = "db.json";
        string peselFile = "pesels.txt";

        Console.WriteLine("Rozpoczęcie programu...");

        AlbumWriter.SaveAlbumNumber("album_number.txt");
        PeselAnalyzer.CountFemalePesels(peselFile);

        var populationData = PopulationAnalyzer.LoadPopulationData(dbFile);
        
        Console.WriteLine("Różnice populacji:");
        Console.WriteLine("   Indie (1970-2000): " + PopulationAnalyzer.GetPopulationDifference(populationData, "India", 1970, 2000));
        Console.WriteLine("   USA (1965-2010): " + PopulationAnalyzer.GetPopulationDifference(populationData, "United States", 1965, 2010));
        Console.WriteLine("   Chiny (1980-2018): " + PopulationAnalyzer.GetPopulationDifference(populationData, "China", 1980, 2018));
        
        Console.WriteLine("Program zakończył działanie.");
    }
}
