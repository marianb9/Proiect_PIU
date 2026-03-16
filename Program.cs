 // Asigură-te că pui numele corect al proiectului tău
using Proiect_PIU.enums;
using Proiect_PIU.models;
using System;

namespace Proiect_PIU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testare Sistem Gestiune ITP (Lab 2) ===\n");

            // 1. Creăm un proprietar
            Proprietar proprietar1 = new Proprietar("Ion Popescu", "1900101123456", "0722123456");

            // 2. Creăm o mașină asociată acestui proprietar
            Masina masina1 = new Masina("Dacia", "Logan", 2018, "B-123-ABC", proprietar1);

            // 3. Creăm un inspector
            Inspector inspector1 = new Inspector("Vasile Ionescu", "RO-ITP-456");

            // 4. Simulăm o inspecție ITP cu rezultat ADMIS
            InspectieITP inspectie1 = new InspectieITP(DateTime.Now, Rezultat.Admis, inspector1);

            // Adăugăm inspecția în istoricul mașinii
            masina1.IstoricInspectii.Add(inspectie1);

            // 5. Afișăm datele pentru a testa că totul s-a legat corect
            Console.WriteLine($"Proprietar: {masina1.Proprietar.Nume}");
            Console.WriteLine($"Masina: {masina1.Marca} {masina1.Model} ({masina1.NrInmatriculare})");
            Console.WriteLine($"Data Inspectiei: {inspectie1.DataEfectuare.ToShortDateString()}");
            Console.WriteLine($"Rezultat ITP: {inspectie1.Rezultat}");
            Console.WriteLine($"Inspector responsabil: {inspectie1.InspectorCareAAprobat.Nume}");
            Console.WriteLine($"Data Expirare ITP: {inspectie1.DataExpirare.ToShortDateString()}");

            Console.WriteLine("\napasati orice tasta pentru a inchide...");
            Console.ReadKey();
        }
    }
}