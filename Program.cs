using System;

namespace SistemSolarSP
{
    class Program
    {
        static void Main(string[] args)
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
                        
                        break;
                    case "E":
                        Console.WriteLine("Inchidere program...");
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta!");
                        break;
                }

            } while (optiune.ToUpper() != "E");

            Console.WriteLine("Apasa orice tasta pentru a inchide programul...");
            Console.ReadKey();
        }
    }
}
