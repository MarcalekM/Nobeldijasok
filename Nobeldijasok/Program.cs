using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings;
using System.Linq;

namespace Nobeldijasok
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dijazott> dijazottak = new ();
            var sr = new StreamReader(
                @"..\..\..\src\orvosi_nobeldijak.txt",
                System.Text.Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) dijazottak.Add(new(sr.ReadLine()));

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"\tÖsszesen {dijazottak.Count} db díjazott adatai találhatóak meg");

            Console.WriteLine("4.feladat:");
            var f4 = dijazottak.Max(d => d.Ev);
            Console.WriteLine($"\tAz utolsó díjátadó éve: {f4}");

            Console.WriteLine("5. feladat:");
            Console.Write("Adjon meg egy országkódot:  ");
            string kod = Console.ReadLine();
            var f5 = dijazottak.Where(d => d.Orszagkod == kod).ToList();
            if (f5.Count() == 0) Console.WriteLine("\tA megadott országból nem volt díjazott!");
            else if(f5.Count() == 1)
            {
                Console.WriteLine($"\tA megadott ország díjázottja:");
                Console.WriteLine($"\tNév: {f5[0].Nev}");
                Console.WriteLine($"\tÉv: {f5[0].Ev}");
                Console.WriteLine($"\tÉlet: {f5[0].SzulHal}");
            }

        }
    }
}
