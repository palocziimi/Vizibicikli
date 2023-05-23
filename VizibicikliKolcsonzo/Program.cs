using System;

namespace VizibicikliKolcsonzo
{
    internal class Program
    {
        static List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();
        static void Main(string[] args)
        {
            //Hagyományos technika
            StreamReader sr = new StreamReader("kolcsonzesek.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var mezok = sr.ReadLine().Split(';');

                Kolcsonzes uj = new Kolcsonzes(mezok[0],
                                               char.Parse(mezok[1]),
                                               int.Parse(mezok[2]),
                                               int.Parse(mezok[3]),
                                               int.Parse(mezok[4]),
                                               int.Parse(mezok[5]));
                kolcsonzesek.Add(uj);
            }
            sr.Close();

            // LINQ + Foreach
            //kolcsonzesek.Clear();

            //foreach (var sor in File.ReadAllLines("kolcsonzesek.txt"))
            //{
            //    kolcsonzesek.Add(new Kolcsonzes(sor));
            //}



            //LINQ
            //List<Kolcsonzes> masikLista = File.ReadAllLines("DataSource\\kolcsonzesek.txt").Skip(1).Select(x => new Kolcsonzes(x)).ToList();

            //5.
            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {kolcsonzesek.Count()}");

            //6.
            Console.Write("6. feladat: Kérek egy nevet: ");
            string name = Console.ReadLine();
            Console.WriteLine($"\n\t{name} kölcsönzései:");
            if (kolcsonzesek.Where(x => x.Nev == name).ToList().Count == 0)
            {
                Console.WriteLine("\tNincs ilyen nevű kölcsönző.");
            }
            else
            {
                kolcsonzesek.Where(x => x.Nev == name).ToList().ForEach(x => Console.WriteLine($"\t{x.EOra}:{x.EPerc}-{x.VOra}:{x.VPerc}"));
            }

            //7.
            Console.Write("7. feladat: Adjon meg egy időpontot óra:perc alakban: ");
            string idopont = Console.ReadLine();
            int idop = int.Parse(idopont.Split(':')[0]) * 60 + int.Parse(idopont.Split(':')[1]);
            Console.WriteLine("\tA vízen lévő járművek: ");
            kolcsonzesek.Where(x => (x.EOra * 60 + x.EPerc) < idop && (x.VOra * 60 + x.VPerc) > idop).ToList().ForEach(x => 
                Console.WriteLine($"\t{x.EOra}:{x.EPerc}-{x.VOra}:{x.VPerc} : {x.Nev}"));

            //8.




        }
    }
}