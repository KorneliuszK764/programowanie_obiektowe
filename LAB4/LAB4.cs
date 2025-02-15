using System;
using System.Collections.Generic;
using System.Linq;

// Zadanie 1: Klasa Shape i dziedziczące klasy
abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine("Rysowanie kształtu...");
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie prostokąta");
    }
}

class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie trójkąta");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie koła");
    }
}

// Zadanie 2: Klasy Osoba, Uczen, Nauczyciel
abstract class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }

    public DateTime GetBirthDate()
    {
        int year = int.Parse(Pesel.Substring(0, 2));
        int month = int.Parse(Pesel.Substring(2, 2));
        int day = int.Parse(Pesel.Substring(4, 2));

        if (month > 80) { year += 1800; month -= 80; }
        else if (month > 60) { year += 2200; month -= 60; }
        else if (month > 40) { year += 2100; month -= 40; }
        else if (month > 20) { year += 2000; month -= 20; }
        else { year += 1900; }

        return new DateTime(year, month, day);
    }

    public int GetAge()
    {
        DateTime birthDate = GetBirthDate();
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now < birthDate.AddYears(age)) age--;
        return age;
    }

    public string GetGender()
    {
        return (int.Parse(Pesel.Substring(9, 1)) % 2 == 0) ? "Kobieta" : "Mężczyzna";
    }

    public virtual bool CanGoAloneToHome()
    {
        return GetAge() >= 12;
    }
}

class Uczen : Osoba
{
    public string Szkola { get; set; }
    public bool MozeSamWracacDoDomu { get; set; }

    public override bool CanGoAloneToHome()
    {
        return GetAge() >= 12 || MozeSamWracacDoDomu;
    }
}

class Nauczyciel : Osoba
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

    public void WhichStudentCanGoHomeAlone()
    {
        Console.WriteLine("Uczniowie mogący wracać sami do domu:");
        foreach (var uczen in PodwladniUczniowie)
        {
            if (uczen.CanGoAloneToHome())
                Console.WriteLine(uczen.Imie + " " + uczen.Nazwisko);
        }
    }
}

// Program główny
t
class Program
{
    static void Main()
    {
        Uczen u1 = new Uczen { Imie = "Adam", Nazwisko = "Kowalski", Pesel = "05211234567", MozeSamWracacDoDomu = false };
        Uczen u2 = new Uczen { Imie = "Ewa", Nazwisko = "Nowak", Pesel = "08121234567", MozeSamWracacDoDomu = true };
        Nauczyciel n1 = new Nauczyciel { Imie = "Jan", Nazwisko = "Wiśniewski", PodwladniUczniowie = new List<Uczen> { u1, u2 } };
        
        Console.WriteLine($"{u1.Imie} {u1.Nazwisko} - Wiek: {u1.GetAge()}, Płeć: {u1.GetGender()}");
        Console.WriteLine($"{u2.Imie} {u2.Nazwisko} - Wiek: {u2.GetAge()}, Płeć: {u2.GetGender()}");
        
        n1.WhichStudentCanGoHomeAlone();
    }
}
