using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Program
    {
        static List<Sportolo> sportolok = new List<Sportolo>();
        static void Main(string[] args)
        {
            Beolvas("kalapacsvetes.txt");

            Console.WriteLine("d, feladat\n");
            Atlag();
            Min();
            Max();
            Osszeg();
            Edatum();
            Udatum();

            Console.WriteLine("\nNyomj ENTER-t a folytatáshoz.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("e, feladat, első része\n");
            Szures1();
            Console.WriteLine("\nNyomj ENTER-t a folytatáshoz.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("e, feladat, második része\n");
            Szures2();


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
                    sportolok.Add(sportolo); //feltöltjük a sportolo listát a beolvasott fájl alapján.
                }
            }
            sr.Close();
        }

        static void Atlag()
        {
            double atlag = sportolok.Average(s => s.Eredmeny); // kiszámoljuk a "sportolok" listában levő "Eredmeny" tulajdonság átlagát.
            Console.WriteLine($"A versenyzők eredményének átlaga: {atlag}");
        }

        static void Min()
        {
            double min = sportolok.Min(s => s.Eredmeny); // kiszámoljuk a "sportolok" listában levő "Eredmeny" tulajdonság minimumát.
            Console.WriteLine($"A legutolsó versenyző eredménye: {min}");
        }

        static void Max()
        {
            double max = sportolok.Max(s => s.Eredmeny); // kiszámoljuk a "sportolok" listában levő "Eredmeny" tulajdonság maximumát.
            Console.WriteLine($"A legelső versenyző eredménye: {max}"); 
        }

        static void Osszeg()
        {
            double sum = sportolok.Sum(s => s.Eredmeny); // kiszámoljuk a "sportolok" listában levő "Eredmeny" tulajdonság összegét.
            Console.WriteLine($"A versenyzők eredményének összege: {sum}");
        }

        static void Edatum()
        { 
            int index = 0; //ez a változó mondja meg, hogy melyik indexen van a keresett számunk.
            int legkisebb = Convert.ToInt32(sportolok[0].Datum.Replace(".", "")); //ezzel a változóval tároljuk a jelenlegi legkisebb számot. A replace metódussal kiszedjuk a pontokat a dátumból, hogy tudjunk vele számolni.
            int mostaniszam = 0; //ez a ciklusban lévő aktuális szám.
            for (int i = 0; i < sportolok.Count; i++)
            {
                mostaniszam = Convert.ToInt32(sportolok[i].Datum.Replace(".", ""));
                if (mostaniszam < legkisebb) //hogyha a jelenlegi számunk kisebb az eddigi legkisebbnél, 
                { 
                    legkisebb = mostaniszam; //az lesz az új legkisebb szám.
                    index = i; //ez esetben eltároljuk hogy a bizonyos legkisebb szám melyik indexen van.
                }
            }
            Console.WriteLine($"+ A legrégebbi dátum: {sportolok[index].Datum}"); //az eltárolt index segítségével kiíratjuk a legrégebbi dátumot.
        }

        static void Udatum()
        {
            int index = 0; //ez a változó mondja meg, hogy melyik indexen van a keresett számunk.
            int legnagyobb = Convert.ToInt32(sportolok[0].Datum.Replace(".", "")); //ezzel a változóval tároljuk a jelenlegi legnagyobb számot. A replace metódussal kiszedjuk a pontokat a dátumból, hogy tudjunk vele számolni.
            int mostaniszam = 0; //ez a ciklusban lévő aktuális szám.
            for (int i = 0; i < sportolok.Count; i++)
            {
                mostaniszam = Convert.ToInt32(sportolok[i].Datum.Replace(".", ""));
                if (mostaniszam > legnagyobb) //hogyha a jelenlegi számunk nagyobb az eddigi legnagyobbnál,
                { 
                    legnagyobb = mostaniszam; //az lesz az új legnagyobb szám.
                    index = i; //ez esetben eltároljuk hogy a bizonyos legnagyobb szám melyik indexen van.
                }
            }
            Console.WriteLine($"+ A legújabb dátum: {sportolok[index].Datum}"); //az eltárolt index segítségével kiíratjuk a legújabb dátumot.
        }

        static void Szures1()
        {
            Console.WriteLine("Hányadik helyezett versenyző adatait szeretnél látni?");
            int bekert1 = Convert.ToInt32(Console.ReadLine());
            Sportolo adottsportolo = sportolok[bekert1 - 1]; //eltároljuk az "adottsportolo" változóban a kiszűrt sportoló indexét.
            Console.WriteLine($"A(z) {bekert1}. helyezett sportoló adatai:\n\t Név: {adottsportolo.Nev}\n\t Helyezés: {adottsportolo.Helyezes}\n\t Eredmény: {adottsportolo.Eredmeny}\n\t Országkód: {adottsportolo.Orszagkod}\n\t Helyszín: {adottsportolo.Helyszin}\n\t Dátum: {adottsportolo.Datum}");
            StreamWriter sw = new StreamWriter("fajliras1.txt");
            sw.WriteLine($"A(z) {bekert1}. helyezett sportoló adatai:\n\t Név: {adottsportolo.Nev}\n\t Helyezés: {adottsportolo.Helyezes}\n\t Eredmény: {adottsportolo.Eredmeny}\n\t Országkód: {adottsportolo.Orszagkod}\n\t Helyszín: {adottsportolo.Helyszin}\n\t Dátum: {adottsportolo.Datum}");
            sw.Close();
        }

        static void Szures2()
        {
            Console.WriteLine("Melyik ország versenyzőinek a statisztikáit szeretnéd látni? (Add meg az országkódot, pl: RUS)");
            string okod = Console.ReadLine().ToUpper(); //átalakítjuk nagybetűssé a bekért szöveget, hogyha a felhasználó kisbetűket gépelne be, még akkor is működjön a program.
            int vszamlalo = 0; //ez fogja a versenyzőket számolni a kiíratásnál.

            StreamWriter sr = new StreamWriter("fajliras2.txt");

            foreach (Sportolo sportolo in sportolok) //végigmegyünk ciklussal a sportolo listán
            {
                if (sportolo.Orszagkod==okod) //ha a bekért országkód megegyezik a listában lévő aktuális országkóddal, akkor kiíratjuk.
                {
                    vszamlalo++;
                    sr.WriteLine($"{vszamlalo}. \n\t Név: {sportolo.Nev} \n\t Helyezés: {sportolo.Helyezes}\n\t Eredmény: {sportolo.Eredmeny}\n\t Országkód: {sportolo.Orszagkod}\n\t Helyszín: {sportolo.Helyszin}\n\t Dátum: {sportolo.Datum}\n");
                    Console.WriteLine($"{vszamlalo}. \n\t Név: {sportolo.Nev} \n\t Helyezés: {sportolo.Helyezes}\n\t Eredmény: {sportolo.Eredmeny}\n\t Országkód: {sportolo.Orszagkod}\n\t Helyszín: {sportolo.Helyszin}\n\t Dátum: {sportolo.Datum}\n");
                }
            }

            if (vszamlalo == 0) //ha a számláló nulla, vagyis nem találtunk egy darab versenyzőt sem, akkor:
            {
                Console.WriteLine("Nincs ilyen országkódú országból levő versenyző, vagy rossz adatot adtál meg.");
                sr.WriteLine("Nincs ilyen országkódú országból levő versenyző, vagy rossz adatot adtál meg.");
            }
            sr.Close();
        }

        static void Vege()
        {
            Console.WriteLine("\nNyomj ENTER-t a bezáráshoz.");
            Console.ReadLine();
        }
    }
}
