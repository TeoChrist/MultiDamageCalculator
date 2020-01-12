using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDamageCalculator
{
    public static class Matematica
    {
        public static int MCD(int a, int b)
        {
            List<int> da = Divisori(a);
            List<int> db = Divisori(b);

            return da.Where(x => db.Contains(x)).Max();
        }

        public static List<int> Divisori(int n)
        {
            List<int> l = new List<int>();

            for (int i = (int)Math.Sqrt(n); i >= 1; i--)
            {
                if (n % i == 0)
                {
                    l.Add(i);
                }
            }

            return l;
        }
    }
}
