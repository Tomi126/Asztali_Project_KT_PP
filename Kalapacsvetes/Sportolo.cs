using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalapacsvetes
{
    internal class Sportolo
    {
        //Sportolo osztály addattagjainak létrehozása
        public int Helyezes { get; set; }
        public double Eredmeny { get; set; }
        public string Nev {  get; set; }
        public string Orszagkod { get; set; }
        public string Helyszin { get; set; }
        public string Datum {  get; set; }

        public Sportolo(string sor)//A Sportolo osztály konstruktora
        {
            string[] adatok = sor.Split(';');
            Helyezes = int.Parse(adatok[0]);
            Eredmeny = Convert.ToDouble(adatok[1]);
            Nev = adatok[2];
            Orszagkod = adatok[3];
            Helyszin = adatok[4];
            Datum = adatok[5];
        }
    }
}
