using System.Collections.Generic;
using Proiect_PIU.models;

namespace Proiect_PIU.manager
{
    public class ManagerMasini
    {
        private List<Masina> listaMasini = new List<Masina>();

        public void AdaugaMasina(Masina masina)
        {
            listaMasini.Add(masina);
        }

        public List<Masina> GetToateMasinile()
        {
            return listaMasini;
        }

        public Masina CautaDupaNrInmatriculare(string nrInmatriculare)
        {
            foreach (Masina m in listaMasini)
            {
                if (m.NrInmatriculare.ToUpper() == nrInmatriculare.ToUpper())
                {
                    return m;
                }
            }
            return null;
        }
    }
}