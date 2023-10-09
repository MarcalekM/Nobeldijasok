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
            var dijazottak = new List<Dijazott>();
            var sr = new StreamReader(
                path: @"..\..\..\src\orvosi_nobeldijak.txt",
                encoding: System.Text.Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) dijazottak.Add(new Dijazott(sr.ReadLine()));

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"\tÖsszesen {dijazottak.Count} db díjazott adatai találhatóak meg");

            Console.WriteLine("4.feladat:");
            var f4 = dijazottak
                .OrderBy(d => d.Ev)
                .Last();
            Console.WriteLine($"\tAz utolsó díjátadó éve: {f4.Ev}");

            Console.WriteLine("5. feladat:");
            Console.Write("Adjon meg egy országkódot:  ");
            string kod = Console.ReadLine();
            var f5 = dijazottak.GroupBy(d => d.Orszagkod == kod);
            foreach (var f in f5)
            {
                Console.WriteLine(f);
            }

        }
    }
}
