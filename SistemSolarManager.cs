using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemSolarSP
{
    public class SistemSolarManager
    {
        private List<SistemSolar> sistemeSolare = new List<SistemSolar>();
        private string filePath = "DateSS.txt";

        public void AdaugaSistemSolar(string numeSistem, string soare, int nrPlanete)
        {
            var sistemSolarCurent = new SistemSolar(numeSistem, soare, nrPlanete);
            sistemeSolare.Add(sistemSolarCurent);
            SalvareSistemeSolare(sistemSolarCurent);
        }

        public SistemSolar GetUltimSistemSolar()
        {
            return sistemeSolare.LastOrDefault();
        }

        public IEnumerable<string> GetToateSistemeleSolare()
        {
            return File.Exists(filePath) ? File.ReadAllLines(filePath) : new List<string>();
        }

        private void SalvareSistemeSolare(SistemSolar sistem)
        {
            int lastId = sistemeSolare.Count - 1;
            using (StreamWriter file = new StreamWriter(filePath, append: true))
            {
                file.WriteLine($"{lastId}: {sistem.NumeSistem}, {sistem.Soare}, {sistem.NrPlanete}");
            }
        }
    }
}
