using System;
using System.Collections.Generic;

class Zwierze
{
    public string Imie { get; set; }
    public int Wiek { get; set; }
    public bool Adoptowane { get; set; }

    public Zwierze(string imie, int wiek)
    {
        Imie = imie;
        Wiek = wiek;
        Adoptowane = false;
    }

    public virtual void WyswietlInformacje()
    {
        Console.WriteLine("Imię: " + Imie);
        Console.WriteLine("Wiek: " + Wiek);
        Console.WriteLine("Status: " + (Adoptowane ? "Adoptowane" : "W schronisku"));
    }

    public virtual void WydajDzwiek()
    {
        Console.WriteLine("Zwierzę wydaje dźwięk.");
    }

    public void Adoptuj()
    {
        Adoptowane = true;
    }
}

class Pies : Zwierze
{
    public string Rasa { get; set; }

    public Pies(string imie, int wiek, string rasa)
        : base(imie, wiek)
    {
        Rasa = rasa;
    }

    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine("Gatunek: Pies");
        Console.WriteLine("Rasa: " + Rasa);
    }

    public override void WydajDzwiek()
    {
        Console.WriteLine(Imie + " szczeka: Hau hau!");
    }
}

class Kot : Zwierze
{
    public bool Wychodzacy { get; set; }

    public Kot(string imie, int wiek, bool wychodzacy)
        : base(imie, wiek)
    {
        Wychodzacy = wychodzacy;
    }

    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine("Gatunek: Kot");
        Console.WriteLine("Kot wychodzący: " + (Wychodzacy ? "Tak" : "Nie"));
    }

    public override void WydajDzwiek()
    {
        Console.WriteLine(Imie + " miauczy: Miau!");
    }
}

class Schronisko
{
    private List<Zwierze> zwierzeta = new List<Zwierze>();

    public void DodajZwierze(Zwierze z)
    {
        zwierzeta.Add(z);
    }

    public void WyswietlWszystkie()
    {
        foreach (Zwierze z in zwierzeta)
        {
            Console.WriteLine("------------------------");
            z.WyswietlInformacje();
            z.WydajDzwiek();
        }
    }

    public void LiczbaZwierzat()
    {
        Console.WriteLine();
        Console.WriteLine("Łączna liczba zwierząt: " + zwierzeta.Count);
    }
}

class Program
{
    static void Main()
    {
        Schronisko schronisko = new Schronisko();

        Pies pies1 = new Pies("Burek", 4, "Owczarek Niemiecki");
        Pies pies2 = new Pies("Max", 2, "Labrador");
        Kot kot1 = new Kot("Mruczek", 3, true);

        kot1.Adoptuj();

        schronisko.DodajZwierze(pies1);
        schronisko.DodajZwierze(pies2);
        schronisko.DodajZwierze(kot1);

        Console.WriteLine("=== SCHRONISKO DLA ZWIERZĄT ===");
        Console.WriteLine();

        schronisko.WyswietlWszystkie();
        schronisko.LiczbaZwierzat();

        Console.WriteLine();
        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
        Console.ReadKey();
    }
}