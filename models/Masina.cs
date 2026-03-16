using Proiect_PIU.models;
using System.Collections.Generic;

namespace Proiect_PIU.models
{
    public class Masina
    {
        public string Marca { get; set; }
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public string NrInmatriculare { get; set; }
        public Proprietar Proprietar { get; set; }

        // lista pt a tine evidenta tuturor inspectiilor facute de aceasta masina
        public List<InspectieITP> IstoricInspectii { get; set; } = new List<InspectieITP>();

        public Masina(string marca, string model, int an, string nrInmatriculare, Proprietar proprietar)
        {
            Marca = marca;
            Model = model;
            AnFabricatie = an;
            NrInmatriculare = nrInmatriculare;
            Proprietar = proprietar;
        }
    }
}