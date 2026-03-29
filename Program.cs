using Modele_PIU.models;
using Modele_PIU.enums;
using System;
using Proiect_PIU.manager;

namespace Proiect_PIU
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerMasini manager = new ManagerMasini();

            while (true)
            {
                Console.WriteLine("\n=== SISTEM GESTIUNE ITP ===");
                Console.WriteLine("1. Adauga o masina noua (Citire de la tastatura)");
                Console.WriteLine("2. Afiseaza toate masinile inregistrate");
                Console.WriteLine("3. Cauta o masina dupa numarul de inmatriculare");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        CitireMasinaDeLaTastatura(manager);
                        break;
                    case "2":
                        AfisareMasini(manager);
                        break;
                    case "3":
                        CautaMasina(manager);
                        break;
                    case "0":
                        Console.WriteLine("Se inchide aplicatia...");
                        return;
                    default:
                        Console.WriteLine("Optiune invalida! Incearca din nou.");
                        break;
                }
            }
        }

        static void CitireMasinaDeLaTastatura(ManagerMasini manager)
        {
            Console.WriteLine("\n--- INTRODUCERE DATE PROPRIETAR ---");
            Console.Write("Nume Proprietar: ");
            string nume = Console.ReadLine();
            Console.Write("CNP: ");
            string cnp = Console.ReadLine();
            Console.Write("Telefon: ");
            string telefon = Console.ReadLine();

            Proprietar proprietarNou = new Proprietar(nume, cnp, telefon);

            Console.WriteLine("\n--- INTRODUCERE DATE MASINA ---");
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("An fabricatie: ");
            int an;
            while (!int.TryParse(Console.ReadLine(), out an))
            {
                Console.Write("An invalid! Introdu un numar: ");
            }

            Console.Write("Numar inmatriculare (ex: B-12-ABC): ");
            string nrInmat = Console.ReadLine();

            Masina masinaNoua = new Masina(marca, model, an, nrInmat, proprietarNou);

            manager.AdaugaMasina(masinaNoua);
            Console.WriteLine("Masina a fost salvata cu succes!");
        }

        static void AfisareMasini(ManagerMasini manager)
        {
            var masini = manager.GetToateMasinile();

            if (masini.Count == 0)
            {
                Console.WriteLine("\nNu exista nicio masina inregistrata in sistem.");
                return;
            }

            Console.WriteLine("\n--- LISTA MASINI ---");
            foreach (var m in masini)
            {
                Console.WriteLine($"> Masina: {m.Marca} {m.Model} | An: {m.AnFabricatie} | Nr: {m.NrInmatriculare} | Proprietar: {m.Proprietar.Nume}");
            }
        }

        static void CautaMasina(ManagerMasini manager)
        {
            Console.Write("\nIntrodu numarul de inmatriculare cautat: ");
            string nrCautat = Console.ReadLine();

            Masina masinaGasita = manager.CautaDupaNrInmatriculare(nrCautat);

            if (masinaGasita != null)
            {
                Console.WriteLine($"\nMASINA GASITA: {masinaGasita.Marca} {masinaGasita.Model}, an {masinaGasita.AnFabricatie}, apartine lui {masinaGasita.Proprietar.Nume} ({masinaGasita.Proprietar.Telefon}).");
            }
            else
            {
                Console.WriteLine("\nMasina cu acest numar de inmatriculare nu a fost gasita in sistem.");
            }
        }
    }
}