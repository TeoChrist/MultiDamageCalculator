using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDamageCalculator
{
    public static class SimpleMath
    {
        public static int GCD(int a, int b)
        {
            List<int> da = Divisors(a);
            List<int> db = Divisors(b);

            return da.Where(x => db.Contains(x)).Max();
        }

        public static List<int> Divisors(int n)
        {
            List<int> list = new List<int>();

            for (int i = (int)Math.Sqrt(n); i >= 1; i--)
            {
                if (n % i == 0)
                {
                    list.Add(i);
                }
            }

            return list;
        }
    }
}
