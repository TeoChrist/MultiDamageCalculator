using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDamageCalculator
{
    public class Calculation
    {
        public int HP { get; set; }

        public List<List<int>> ListAttackRolls { get; set; }

        public int KOcounter { get; set; }

        public int Total { get; set; }

        public int SimplifiedKOcounter { get; set; }

        public int SimplifiedTotal { get; set; }

        public double KOpercentage { get; set; }

        public Calculation()
        {
            ListAttackRolls = new List<List<int>>();
        }
    }
}
