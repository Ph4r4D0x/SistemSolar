using System;

namespace SistemSolar
{
    public class SistemSolar
    {
        public string NumeSistem { get; private set; }
        public string Soare { get; private set; }
        public int NrPlanete { get; private set; }

        public SistemSolar(string numeSistem, string soare, int nrPlanete)
        {
            NumeSistem = numeSistem;
            Soare = soare;
            NrPlanete = nrPlanete;
        }

        public string Info()
        {
            return $"Numele Sistemului solar: {NumeSistem},Steaua sistemului: {Soare}, Numarul Planetelor a sistemului: {NrPlanete}";
        }
    }
}