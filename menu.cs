using SistemSolarSP;
using System;
using System.Linq;

namespace SistemSolarSP
{
    public class Menu
    {
        private SistemSolarManager manager = new SistemSolarManager();

        public void AfisareMeniu()
        {
            Console.WriteLine("A. Citire sistem solar: ");
            Console.WriteLine("B. Afisare informatii despre ultimul sistem solar introdus: ");
            Console.WriteLine("C. Afisare toate sistemele solare: ");
            Console.WriteLine("D. Salvare sisteme solare: ");
            Console.WriteLine("E. Inchidere program");
        }

        public void CitireSistemSolar()
        {
            Console.WriteLine("Introduceti numele sistemului:");
            string numeSistem = Console.ReadLine();
            Console.WriteLine("Introduceti numele stelei:");
            string numeStea = Console.ReadLine();
            Console.WriteLine("Introduceti numarul de planete:");
            int nrPlanete = int.Parse(Console.ReadLine());

            manager.AdaugaSistemSolar(numeSistem, numeStea, nrPlanete);
        }

        public void AfisareUltimSistemSolar()
        {
            var sistem = manager.GetUltimSistemSolar();
            Console.WriteLine(sistem?.Info() ?? "Nu exista sistemul introdus.");
        }

        public void AfisareToateSistemeleSolare()
        {
            var sisteme = manager.GetToateSistemeleSolare();
            if (sisteme.Any())
            {
                Console.WriteLine("Sisteme salvate:");
                foreach (var sistem in sisteme)
                {
                    Console.WriteLine(sistem);
                }
            }
            else
            {
                Console.WriteLine("Nu exista sisteme salvate.");
            }
        }
    }
}
