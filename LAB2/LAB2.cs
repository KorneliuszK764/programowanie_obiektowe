using System;
using System.Collections.Generic;

// Zadanie 1: Klasa Osoba
class Osoba
{
    private string imie;
    private string nazwisko;
    private int wiek;

    public string Imie
    {
        get { return imie; }
        set { if (value.Length >= 2) imie = value; }
    }
    public string Nazwisko
    {
        get { return nazwisko; }
        set { if (value.Length >= 2) nazwisko = value; }
    }
    public int Wiek
    {
        get { return wiek; }
        set { if (value > 0) wiek = value; }
    }
    
    public Osoba(string imie, string nazwisko, int wiek)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
    }
    
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Osoba: {Imie} {Nazwisko}, Wiek: {Wiek}");
    }
}

// Zadanie 2: Klasa BankAccount
class BankAccount
{
    public string Wlasciciel { get; private set; }
    public decimal Saldo { get; private set; }
    
    public BankAccount(string wlasciciel, decimal saldoPoczatkowe)
    {
        Wlasciciel = wlasciciel;
        Saldo = saldoPoczatkowe;
    }
    
    public void Wplata(decimal kwota)
    {
        if (kwota > 0) Saldo += kwota;
    }
    
    public void Wyplata(decimal kwota)
    {
        if (kwota > 0 && Saldo >= kwota) Saldo -= kwota;
    }
}

// Zadanie 3: Klasa Student
class Student
{
    public string Imie { get; private set; }
    public string Nazwisko { get; private set; }
    private List<int> oceny;
    
    public Student(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        oceny = new List<int>();
    }
    
    public void DodajOcene(int ocena)
    {
        if (ocena >= 1 && ocena <= 6) oceny.Add(ocena);
    }
    
    public double SredniaOcen => oceny.Count > 0 ? (double)oceny.Sum() / oceny.Count : 0;
}

// Zadanie 4: Klasa Licz
class Licz
{
    private int value;
    
    public Licz(int startValue)
    {
        value = startValue;
    }
    
    public void Dodaj(int x) { value += x; }
    public void Odejmij(int x) { value -= x; }
    public void Wyswietl() { Console.WriteLine($"Wartość: {value}"); }
}

// Zadanie 5: Klasa Sumator
class Sumator
{
    private int[] liczby;
    
    public Sumator(int[] liczby)
    {
        this.liczby = liczby;
    }
    
    public int Suma() => liczby.Sum();
    public int SumaPodziel2() => liczby.Where(x => x % 2 == 0).Sum();
    public int IleElementow() => liczby.Length;
    
    public void WyswietlElementy()
    {
        Console.WriteLine("Elementy: " + string.Join(", ", liczby));
    }
    
    public void WyswietlZakres(int lowIndex, int highIndex)
    {
        for (int i = Math.Max(0, lowIndex); i <= Math.Min(highIndex, liczby.Length - 1); i++)
        {
            Console.Write(liczby[i] + " ");
        }
        Console.WriteLine();
    }
}
