Console.WriteLine("OBJEKTI\n");

List<Slika> slike = new List<Slika>();
Slika slika1 = new Slika { Tip = "olje", Sirina = 80, Visina = 12, Ime = "test", Cena = 50, Podokvir = true, Avtor = "daniel" };
slike.Add(slika1);

foreach (Slika slika in slike)
{
    Console.WriteLine("Slika");
    Console.WriteLine("tip: " + slika.Tip + "\n" + "sirina: " + slika.Sirina + "\n" + "visina: " + slika.Visina + "\n" + "ime: " + slika.Ime + "\n" + "cena: " + slika.Cena + "\n" + "podokvir: " + slika.Podokvir + "\n" + "avtor: " + slika.Avtor);
}

List<Okvir> okviri = new List<Okvir>();
Okvir okvir1 = new Okvir { Ime = "zlati les", Material = "les", Cena = 21 };
okviri.Add(okvir1);

foreach (Okvir okvir in okviri)
{
    Console.WriteLine("\nOkvir");
    Console.WriteLine("ime: " + okvir.Ime + "\n" + "material: " + okvir.Material + "\n" + "cena: " + okvir.Cena);
}

List<Zascita> zascite = new List<Zascita>();
Zascita zascita1 = new Zascita { Ime = "zlati les", Material = "steklo", Cena = 18 };
zascite.Add(zascita1);

foreach (Zascita zascita in zascite)
{
    Console.WriteLine("\nZascita");
    Console.WriteLine("ime: " + zascita.Ime + "\n" + "material: " + zascita.Material + "\n" + "cena: " + zascita.Cena);
}

Console.WriteLine("\nARTIKEL IN NAROCILO");

List<Artikel> artikli = new List<Artikel>();
Artikel artikel1 = new Artikel { Slika = slika1, Okvir = okvir1, Zascita = zascita1, IzDatum = "7.3.2023" /*tipZascite="test", tveganostZascite="primer"*/  }; // tip & tveganost zascite = null -> DEFAULT VREDNOST
artikli.Add(artikel1);

Console.WriteLine("\nIZRACUN ZA DATUM\n");
Artikel preveri = new Artikel();
preveri.skrajniDatum(artikel1.IzDatum, artikel1.TipZascite, artikel1.TveganostZascite); // tipZascite & tveganostZascite DEFAULT -> standardno & nekontrolirano okolje

Console.WriteLine("\nROK POTEKA\n");
preveri.rokZascite(preveri.TveganostZascite); // tveganost DEFAULT -> nekontrolirano (1.0X)

foreach (Artikel artikel in artikli)
{
    Console.WriteLine("\nArtikel\n");

    Console.WriteLine("Slika: " + artikel1.Slika + "\n" + "Okvir: " + artikel1.Okvir + "\n" + "Zascita: " + artikel1.Zascita + "\n" + artikel1.IzDatum + "\n" + artikel1.TipZascite + "\n" + artikel1.TveganostZascite);
}

//Console.WriteLine(preveri.izDatum);
Console.WriteLine(preveri.TipZascite);
Console.WriteLine(preveri.TveganostZascite);

List<Narocilo> narocila = new List<Narocilo>();
Narocilo narocilo1 = new Narocilo { Slika = slika1, Okvir = okvir1, Zascita = zascita1, Datum = "19.03.2023", Dobava = 14, Izdano = true };
narocila.Add(narocilo1);

foreach (Narocilo narocilo in narocila)
{
    Console.WriteLine("\nNarocilo");
    Console.WriteLine("Slika: " + narocilo1.Slika + "\n" + "Okvir: " + narocilo1.Okvir + "\n" + "Zascita: " + narocilo1.Zascita + "\n" + "Datum narocila: " + narocilo1.Datum + "\n" + "Dobava dni: " + narocilo1.Dobava + "\n" + "Izdano: " + narocilo1.Izdano);
}

class Slika
{
    public string Tip { get; set; }
    public int Sirina { get; set; }
    public int Visina { get; set; }
    public string Ime { get; set; }
    public int Cena { get; set; }
    public bool Podokvir { get; set; }
    public string Avtor { get; set; }

    public Slika(string tip="", int sirina=0, int visina=0, string ime="", int cena=0, bool podokvir=false,string avtor="" )
    {
        Tip = tip;
        Sirina = sirina;
        Visina = visina;
        Ime = ime;
        Cena = cena;
        Podokvir = podokvir;
        Avtor = avtor;
    }
}

class Okvir : Slika
{
    public string Material { get; set; }

    public Okvir(string tip="", string material="", int cena=0)
    {
        Tip = tip;
        Material = material;
        Cena=cena;
    }
}

class Zascita : Okvir
{
    public Zascita(string tip = "", string material = "", int cena = 0)
    {
        Tip = tip;
        Material = material;
        Cena = cena;
    }
}

class Artikel
{
    public Slika Slika { get; set; }
    public Okvir Okvir { get; set; }
    public Zascita Zascita { get; set; }
    public string IzDatum { get; set; }
    public string TipZascite { get; set; }
    public string TveganostZascite { get; set; }

    public void setZascita(string zascita = "standardno")
    {
        this.TipZascite = zascita;
    }

    public void setTveganost(string tveganost = "nekontrolirano okolje") //kontrolirano okolje -> 2.5X
    {
        this.TveganostZascite = tveganost;
    }

    public void skrajniDatum(string datum, string zascita, string tveganost)
    {

        if(datum != null && zascita == null && tveganost == null)
        {
            setZascita();
            setTveganost();
        }
        if(datum != null && zascita != null && tveganost == null)
        {
            setTveganost();
        }

    }

    public void rokZascite(string tveganost)
    {
        if (tveganost == "slabe razmere")
        {
            Console.WriteLine("0.5X");
        }
        if (tveganost == "nekontrolirano okolje")
        {
            Console.WriteLine("1.0X");
        }
        if (tveganost == "kontrolirano okolje")
        {
            Console.WriteLine("2.5X");
        }
    }


}

class Narocilo : Artikel
{
    public string Datum { get; set; }
    public int Dobava { get; set; }
    public bool Izdano { get; set; }

}




