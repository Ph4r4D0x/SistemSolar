using System;
using System.Collections.Generic;

namespace SistemSolar
{
    public class Menu
    {
        private List<SistemSolar> sistemeSolare = new List<SistemSolar>();
        private SistemSolar sistemSolarCurent = null;

        public void AfisareMeniu()
        {
            Console.WriteLine("A. Citire sistem solar");
            Console.WriteLine("B. Afisare informatii despre ultimul sistem solar introdus");
            Console.WriteLine("C. Afisare toate sistemele solare");
            Console.WriteLine("D. Salvare sisteme solare");
            Console.WriteLine("E. Inchidere program");
        }

        public void CitireSistemSolar()
        {
            Console.WriteLine("Introduceti numele sistemului:");
            string numeSistem = Console.ReadLine();

            Console.WriteLine("Introduceti numele stelei:");
            string numeStea = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de planete:");
            int nrPlanete;

            while (!int.TryParse(Console.ReadLine(), out nrPlanete))
            {
                Console.WriteLine("Input esuat, va rog sa dati un numar intreg:");
            }

            sistemSolarCurent = new SistemSolar(numeSistem, numeStea, nrPlanete);
            sistemeSolare.Add(sistemSolarCurent);
        }

        public void AfisareUltimSistemSolar()
        {
            if (sistemSolarCurent != null)
            {
                Console.WriteLine(sistemSolarCurent.Info());
            }
            else
            {
                Console.WriteLine("Nu exista sisteme solare introduse.");
            }
        }

        public void AfisareToateSistemeleSolare()
        {
            if (sistemeSolare.Count > 0)
            {
                foreach (var sistem in sistemeSolare)
                {
                    Console.WriteLine(sistem.Info());
                }
            }
            else
            {
                Console.WriteLine("Nu exista sisteme solare de afisat.");
            }
        }

        public void SalvareSistemeSolare()
        {

            Console.WriteLine("Salvat sistemele solare. (Implementare necesara)");
        }
    }
}