using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDamageCalculator
{
    public class Calcolo
    {
        public int HP { get; set; }

        public List<List<int>> ListeDanni { get; set; }

        public int ContatoreKO { get; set; }

        public int Totale { get; set; }

        public int ContatoreKOmin { get; set; }

        public int TotaleMin { get; set; }

        public double PercentualeKO { get; set; }

        public Calcolo()
        {
            ListeDanni = new List<List<int>>();
        }
    }
}
