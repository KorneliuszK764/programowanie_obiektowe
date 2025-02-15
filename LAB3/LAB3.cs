using System;
using System.Collections.Generic;

// Zadanie 1a: Klasy Person i Book
class Person
{
    private string FirstName;
    private string LastName;
    private int Age;

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public virtual void View()
    {
        Console.WriteLine($"Osoba: {FirstName} {LastName}, Wiek: {Age}");
    }
}

class Book
{
    private string Title;
    private Person Author;
    private int ReleaseYear;

    public Book(string title, Person author, int releaseYear)
    {
        Title = title;
        Author = author;
        ReleaseYear = releaseYear;
    }

    public void View()
    {
        Console.WriteLine($"Książka: {Title}, Autor: {Author}, Rok wydania: {ReleaseYear}");
    }
}

// Zadanie 1b: Klasa Reader dziedzicząca z Person
class Reader : Person
{
    private List<Book> ReadBooks;

    public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
        ReadBooks = new List<Book>();
    }

    public void AddBook(Book book)
    {
        ReadBooks.Add(book);
    }

    public void ViewBook()
    {
        Console.WriteLine("Przeczytane książki:");
        foreach (var book in ReadBooks)
        {
            Console.WriteLine(book);
        }
    }

    public override void View()
    {
        base.View();
        ViewBook();
    }
}

// Zadanie 1f: Klasa Reviewer dziedzicząca z Reader
class Reviewer : Reader
{
    private Random random = new Random();

    public Reviewer(string firstName, string lastName, int age) : base(firstName, lastName, age) { }

    public void ReviewBooks()
    {
        Console.WriteLine("Oceny przeczytanych książek:");
        foreach (var book in ReadBooks)
        {
            Console.WriteLine($"{book}: Ocena {random.Next(1, 10)}/10");
        }
    }
}

// Zadanie 2: Klasy Samochod i SamochodOsobowy
t
class Samochod
{
    protected string Marka, Model, Nadwozie, Kolor;
    protected int RokProdukcji;
    protected double Przebieg;

    public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, double przebieg)
    {
        Marka = marka;
        Model = model;
        Nadwozie = nadwozie;
        Kolor = kolor;
        RokProdukcji = rokProdukcji;
        Przebieg = przebieg < 0 ? 0 : przebieg;
    }

    public virtual void WyswietlInformacje()
    {
        Console.WriteLine($"{Marka} {Model}, {Nadwozie}, {Kolor}, Rok: {RokProdukcji}, Przebieg: {Przebieg}km");
    }
}

class SamochodOsobowy : Samochod
{
    private double Waga, PojemnoscSilnika;
    private int IloscOsob;

    public SamochodOsobowy(string marka, string model, string nadwozie, string kolor, int rokProdukcji, double przebieg,
                            double waga, double pojemnoscSilnika, int iloscOsob) : base(marka, model, nadwozie, kolor, rokProdukcji, przebieg)
    {
        Waga = (waga < 2 || waga > 4.5) ? 2 : waga;
        PojemnoscSilnika = (pojemnoscSilnika < 0.8 || pojemnoscSilnika > 3.0) ? 0.8 : pojemnoscSilnika;
        IloscOsob = iloscOsob;
    }

    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine($"Waga: {Waga}t, Pojemność: {PojemnoscSilnika}L, Liczba osób: {IloscOsob}");
    }
}

class Program
{
    static void Main()
    {
        // Testowanie klas
        Person p1 = new Person("Jan", "Kowalski", 30);
        p1.View();
        
        Book b1 = new Book("Wiedźmin", p1, 1993);
        b1.View();
        
        Reader r1 = new Reader("Anna", "Nowak", 25);
        r1.AddBook(b1);
        r1.View();

        Reviewer rev1 = new Reviewer("Karol", "Kwiatkowski", 40);
        rev1.AddBook(b1);
        rev1.ReviewBooks();

        Samochod s1 = new Samochod("Toyota", "Corolla", "Sedan", "Czerwony", 2018, 60000);
        s1.WyswietlInformacje();

        SamochodOsobowy so1 = new SamochodOsobowy("BMW", "X5", "SUV", "Czarny", 2022, 5000, 2.5, 2.0, 5);
        so1.WyswietlInformacje();
    }
}
