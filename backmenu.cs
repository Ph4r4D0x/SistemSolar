using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemSolar
{
    public class Menu
    {
        private List<SistemSolar> sistemeSolare = new List<SistemSolar>();
        private SistemSolar sistemSolarCurent = null;

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
                Console.WriteLine("Nu exista sistemul introdus.");
            }
        }

        public void AfisareToateSistemeleSolare()
        {
            string filePath = "DateSS.txt";

            if (File.Exists(filePath))
            {
                Console.WriteLine("Sisteme salvate: ");
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Nu a fost gasit sistemul introdus.");
            }
        }


        public void SalvareSistemeSolare()
        {
            string filePath = "DateSS.txt";
            int lastId = -1; 

            if (File.Exists(filePath))
            {
                string lastline = File.ReadLines(filePath).LastOrDefault();
                if (lastline != null)
                {
                    string[] parti = lastline.Split(':');
                    if (parti.Length > 0 && int.TryParse(parti[0], out int idLastSystem))
                    {
                        lastId = idLastSystem;
                    }
                }
            }

            using (StreamWriter file = new StreamWriter(filePath, append: true))
            {
                foreach (var sistem in sistemeSolare)
                {
                    lastId++;
                    file.WriteLine($"{lastId}: {sistem.NumeSistem}, {sistem.Soare}, {sistem.NrPlanete}");
                }
            }

            Console.WriteLine("Sistemul a fost salvat.");
        }

    }
   
}