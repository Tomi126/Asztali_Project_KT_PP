using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Program
    {
        static List<Sportolo>sportolok = new List<Sportolo>();
        static void Main(string[] args)
        {
            Beolvas("kalapacsvetes.txt");

            Atlag();
            Min();
            Max();
            Osszeg();

            Szures1();


            Vege();
        }

        static void Beolvas(string fajlNev)
        {
            int sorskip = 0;
            StreamReader sr = new StreamReader(fajlNev);
            while (!sr.EndOfStream) 
            {
                if (sorskip == 0) //ez az elágazás azért kell, mert a txt fájl első sora nem kell nekünk, és itt azt átugorjuk.
                {
                    sr.ReadLine();
                    sorskip = 1;
                }
                else
                {
                    string line = sr.ReadLine();
                    Sportolo sportolo = new Sportolo(line);
                    sportolok.Add(sportolo);
                }
            }
            sr.Close();
        }

        static void Atlag()
        {
            double atlag = sportolok.Average(s => s.Eredmeny); // ennél a sornál használtunk internetes segítséget, 
            Console.WriteLine($"A versenyzők eredményének átlaga: {atlag}");
        }

        static void Min()
        {
            double min = sportolok.Min(s => s.Eredmeny);
            Console.WriteLine($"A legutolsó versenyző eredménye: {min}");
        }

        static void Max()
        {
            double max = sportolok.Max(s => s.Eredmeny);
            Console.WriteLine($"A legelső versenyző eredménye: {max}");
        }

        static void Osszeg()
        {
            double sum = sportolok.Sum(s => s.Eredmeny);
            Console.WriteLine($"A versenyzők eredményének összege: {sum}");
        }

        static void Szures1() 
        {
            Console.WriteLine("Hányadik helyezett versenyző adatait szeretnél látni?");
            int bekert1 = Convert.ToInt32(Console.ReadLine());
        }

        static void Vege()
        {
            Console.WriteLine("Nyomj ENTER-t a bezáráshoz.");
            Console.ReadLine();
        }
    }
}
