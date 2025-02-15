using System;
using System.Collections.Generic;

// Zadanie 1: Kalkulator operacji matematycznych
enum Operacja
{
    Dodawanie,
    Odejmowanie,
    Mnozenie,
    Dzielenie
}

class Kalkulator
{
    private static List<double> historiaWynikow = new List<double>();
    
    public static double Oblicz(double a, double b, Operacja operacja)
    {
        try
        {
            double wynik = operacja switch
            {
                Operacja.Dodawanie => a + b,
                Operacja.Odejmowanie => a - b,
                Operacja.Mnozenie => a * b,
                Operacja.Dzielenie => b == 0 ? throw new DivideByZeroException() : a / b,
                _ => throw new ArgumentException("Nieznana operacja")
            };
            historiaWynikow.Add(wynik);
            return wynik;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
            return double.NaN;
        }
    }

    public static void PokazHistorie()
    {
        Console.WriteLine("Historia obliczeń:");
        foreach (var wynik in historiaWynikow)
        {
            Console.WriteLine(wynik);
        }
    }
}

// Zadanie 2: Zarządzanie zamówieniami w sklepie
enum StatusZamowienia
{
    Oczekujace,
    Przyjete,
    Zrealizowane,
    Anulowane
}

class Sklep
{
    private Dictionary<int, (List<string> produkty, StatusZamowienia status)> zamowienia = new();
    
    public void DodajZamowienie(int id, List<string> produkty)
    {
        zamowienia[id] = (produkty, StatusZamowienia.Oczekujace);
    }
    
    public void ZmienStatusZamowienia(int id, StatusZamowienia nowyStatus)
    {
        if (!zamowienia.ContainsKey(id))
            throw new KeyNotFoundException("Nie znaleziono zamówienia.");
        if (zamowienia[id].status == nowyStatus)
            throw new ArgumentException("Nowy status nie może być taki sam jak aktualny.");
        
        zamowienia[id] = (zamowienia[id].produkty, nowyStatus);
    }
    
    public void WyswietlZamowienia()
    {
        foreach (var zamowienie in zamowienia)
        {
            Console.WriteLine($"Zamówienie {zamowienie.Key}: {string.Join(", ", zamowienie.Value.produkty)} - {zamowienie.Value.status}");
        }
    }
}

// Zadanie 3: Gra w zgadywanie kolorów
enum Kolor
{
    Czerwony,
    Niebieski,
    Zielony,
    Zolty,
    Fioletowy
}

class GraKolory
{
    private static List<Kolor> kolory = new() { Kolor.Czerwony, Kolor.Niebieski, Kolor.Zielony, Kolor.Zolty, Kolor.Fioletowy };
    
    public static void Zagraj()
    {
        Random rand = new Random();
        Kolor wylosowanyKolor = kolory[rand.Next(kolory.Count)];
        
        while (true)
        {
            Console.Write("Zgadnij kolor (Czerwony, Niebieski, Zielony, Zolty, Fioletowy): ");
            if (Enum.TryParse(Console.ReadLine(), true, out Kolor wybor) && kolory.Contains(wybor))
            {
                if (wybor == wylosowanyKolor)
                {
                    Console.WriteLine("Brawo! Zgadłeś!");
                    break;
                }
                else
                {
                    Console.WriteLine("Źle, spróbuj ponownie.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny kolor, wpisz ponownie.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Testowanie kalkulatora
        Console.Write("Podaj pierwszą liczbę: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj drugą liczbę: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Wybierz operację (Dodawanie, Odejmowanie, Mnozenie, Dzielenie): ");
        if (Enum.TryParse(Console.ReadLine(), true, out Operacja operacja))
        {
            Console.WriteLine($"Wynik: {Kalkulator.Oblicz(a, b, operacja)}");
        }
        Kalkulator.PokazHistorie();
        
        // Testowanie zarządzania zamówieniami
        Sklep sklep = new Sklep();
        Console.Write("Podaj numer zamówienia: ");
        int id = Convert.ToInt32(Console.ReadLine());
        sklep.DodajZamowienie(id, new List<string> { "Chleb", "Masło" });
        sklep.WyswietlZamowienia();
        
        Console.Write("Zmień status zamówienia (Oczekujace, Przyjete, Zrealizowane, Anulowane): ");
        if (Enum.TryParse(Console.ReadLine(), true, out StatusZamowienia nowyStatus))
        {
            sklep.ZmienStatusZamowienia(id, nowyStatus);
        }
        sklep.WyswietlZamowienia();
        
        // Gra w zgadywanie kolorów
        GraKolory.Zagraj();
    }
}
