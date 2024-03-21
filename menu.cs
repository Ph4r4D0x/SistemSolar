using System;

namespace SistemSolar
{
    internal class Program
    {
        static void Main()
        {
            Menu menu = new Menu();
            string optiune;

            do
            {
                menu.AfisareMeniu();
                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "A":
                        menu.CitireSistemSolar();
                        break;
                    case "B":
                        menu.AfisareUltimSistemSolar();
                        break;
                    case "C":
                        menu.AfisareToateSistemeleSolare();
                        break;
                    case "D":
                        menu.SalvareSistemeSolare();
                        break;
                    case "E":
                        Console.WriteLine("Inchidere program...");
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta!");
                        break;
                }
            } while (optiune.ToUpper() != "E");

            Console.ReadKey();
        }
    }
}