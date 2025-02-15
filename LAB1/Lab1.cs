using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wybierz program:");
        Console.WriteLine("1 - Obliczanie delty i pierwiastków trójmianu kwadratowego");
        Console.WriteLine("2 - Kalkulator matematyczny");
        Console.WriteLine("3 - Operacje na tablicy 10 liczb");
        Console.WriteLine("4 - Statystyki dla 10 liczb");
        Console.WriteLine("5 - Liczby 20-0 z pominięciem");
        Console.WriteLine("6 - Pętla nieskończona (zakończenie ujemną liczbą)");
        Console.WriteLine("7 - Sortowanie liczb");
        Console.Write("Wybór: ");
        
        int choice = Convert.ToInt32(Console.ReadLine());
        
        switch (choice)
        {
            case 1:
                CalculateQuadraticEquation();
                break;
            case 2:
                Calculator();
                break;
            case 3:
                ArrayOperations();
                break;
            case 4:
                ArrayStatistics();
                break;
            case 5:
                PrintNumbers();
                break;
            case 6:
                InfiniteLoop();
                break;
            case 7:
                SortNumbers();
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                break;
        }
    }

    // Zadanie 1: Obliczanie delty i pierwiastków trójmianu kwadratowego
    static void CalculateQuadraticEquation()
    {
        Console.Write("Podaj a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double delta = b * b - 4 * a * c;
        Console.WriteLine($"Delta: {delta}");

        if (delta > 0)
        {
            double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Pierwiastki: x1={x1}, x2={x2}");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Pierwiastek podwójny: x={x}");
        }
        else
        {
            Console.WriteLine("Brak pierwiastków rzeczywistych.");
        }
    }

    // Zadanie 2: Kalkulator matematyczny
    static void Calculator()
    {
        Console.Write("Podaj pierwszą liczbę: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj drugą liczbę: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("1. Suma\n2. Różnica\n3. Iloczyn\n4. Iloraz\n5. Potęga\n6. Pierwiastek pierwszej liczby");
        Console.Write("Wybierz operację: ");
        int op = Convert.ToInt32(Console.ReadLine());
        
        switch (op)
        {
            case 1:
                Console.WriteLine($"Wynik: {a + b}");
                break;
            case 2:
                Console.WriteLine($"Wynik: {a - b}");
                break;
            case 3:
                Console.WriteLine($"Wynik: {a * b}");
                break;
            case 4:
                Console.WriteLine(b != 0 ? $"Wynik: {a / b}" : "Nie można dzielić przez 0");
                break;
            case 5:
                Console.WriteLine($"Wynik: {Math.Pow(a, b)}");
                break;
            case 6:
                Console.WriteLine(a >= 0 ? $"Wynik: {Math.Sqrt(a)}" : "Nie można pierwiastkować liczby ujemnej");
                break;
            default:
                Console.WriteLine("Nieprawidłowa operacja.");
                break;
        }
    }

    // Zadanie 3: Operacje na tablicy 10 liczb
    static void ArrayOperations()
    {
        int[] numbers = new int[10];
        Console.WriteLine("Podaj 10 liczb:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Liczba {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        
        Console.WriteLine("Tablica od pierwszego do ostatniego indeksu: " + string.Join(", ", numbers));
        Console.WriteLine("Tablica od ostatniego do pierwszego indeksu: " + string.Join(", ", numbers.Reverse()));
        Console.WriteLine("Elementy o nieparzystych indeksach: " + string.Join(", ", numbers.Where((_, i) => i % 2 != 0)));
        Console.WriteLine("Elementy o parzystych indeksach: " + string.Join(", ", numbers.Where((_, i) => i % 2 == 0)));
    }
    static void ArrayOperations()
    {
        // Implementacja
    }

    // Zadanie 4: Statystyki dla 10 liczb
    static void ArrayStatistics()
    {
        int[] numbers = new int[10];
        Console.WriteLine("Podaj 10 liczb:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Liczba {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        
        int suma = numbers.Sum();
        int iloczyn = numbers.Aggregate(1, (x, y) => x * y);
        double srednia = numbers.Average();
        int min = numbers.Min();
        int max = numbers.Max();
        
        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Iloczyn: {iloczyn}");
        Console.WriteLine($"Średnia: {srednia}");
        Console.WriteLine($"Wartość minimalna: {min}");
        Console.WriteLine($"Wartość maksymalna: {max}");
    }
    static void ArrayStatistics()
    {
        // Implementacja
    }

    // Zadanie 5: Wypisywanie liczb od 20 do 0 z pominięciem niektórych
    static void PrintNumbers()
    {
        for (int i = 20; i >= 0; i--)
        {
            if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
                continue;
            Console.Write(i + " ");
        }
    }

    // Zadanie 6: Pętla nieskończona
    static void InfiniteLoop()
    {
        while (true)
        {
            Console.Write("Podaj liczbę: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
                break;
        }
    }

    // Zadanie 7: Sortowanie liczb
    static void SortNumbers()
    {
        Console.Write("Podaj ilość liczb: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Podaj liczbę {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Array.Sort(numbers);
        Console.WriteLine("Posortowane liczby: " + string.Join(", ", numbers));
    }
}
