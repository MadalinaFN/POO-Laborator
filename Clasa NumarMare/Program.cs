using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_NumarMare
{
    class NumarMare
    {
        public int[] numar;
        public int n;

        public NumarMare(int[] n)
        {
            numar = n;
        }

        public NumarMare(int n)
        {
            this.n = n;
            this.numar = new int[n];
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            Array.ForEach(numar, x => s.Append(x));
            return s.ToString();
        }

        public void RP()
        {
            int p = 0;
            List<int> nrnc = new List<int>();

            if (numar.Length == 1)
                return;

            for (int i = 0; i < numar.Length; i++)
            {
                if (numar[i] != 0)
                {
                    p = i;
                    break;
                }
            }

            for (int i = 0; i < numar.Length; i++)
                nrnc.Add(numar[i]);
            numar = nrnc.ToArray();
        }

        public void PTL(int l)
        {
            int[] nrc = new int[l];

            if (numar.Length == l)
                return;

            for (int i = l - numar.Length; i < l; i++)
                nrc[i] = numar[i - (l - numar.Length)];
            numar = nrc;
        }

        public static NumarMare operator +(NumarMare nr1, NumarMare nr2)
        {
            int m, carr, nmr;
            List<int> rez = new List<int>();

            m = (nr1.numar.Length > nr2.numar.Length) ? nr1.numar.Length : nr2.numar.Length;
            carr = 0;

            nr1.PTL(m);
            nr2.PTL(m);

            for (int i = 1; i < nr1.numar.Length + 1; i++)
            {
                nmr = nr1.numar[nr1.numar.Length - i] + nr2.numar[nr1.numar.Length - i];
                if (carr > 0)
                {
                    nmr += carr;
                    carr = 0;
                }
                if (nmr >= 10)
                {
                    nmr -= 10;
                    carr = 1;
                }
                rez.Add(nmr);
            }

            if (carr > 0)
                rez.Add(carr);

            nr1.RP();
            nr2.RP();
            rez.Reverse();

            return new NumarMare(rez.ToArray());
        }

        public static NumarMare operator *(NumarMare nr1, NumarMare nr2)
        {
            int t = 0, nr3l = nr1.numar.Length + nr2.numar.Length - 1;
            int[] nr3 = new int[nr3l + 1];

            for (int i = 0; i < nr1.numar.Length + nr2.numar.Length; i++)
                nr3[i] = 0;

            for (int i = 0; i < nr1.numar.Length; i++)
            {
                for (int j = 0; j < nr2.numar.Length; j++)
                {
                    nr3[i + j] += nr1.numar[i] * nr2.numar[j];
                }
            }

            for (int i = 0; i < nr3l; i++)
            {
                nr3[i] += t;
                t = nr3[i] / 10;
                nr3[i] %= 10;
            }

            if (t != 0)
                nr3[nr3l++] = t;

            return new NumarMare(nr3);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100, factorial = 1000;
            int[] n1 = { 7, 8, 2, 4, 9, 1, 5, 3, 9, 2 };
            int[] n2 = { 3, 5, 6, 2, 7, 4, 1, 8, 7, 9 };

            NumarMare nr1 = new NumarMare(n1);
            NumarMare nr2 = new NumarMare(n2);

            Console.WriteLine("Primul numar este: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(n1[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Al doilea numar este: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(n2[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Suma celor doua numere este: {nr1 + nr2}");
            Console.WriteLine($"Inmultirea celor doua numere este: {nr1 * nr2}");
            Console.WriteLine($"Al {n}-lea termen din sirul lui Fibonacci este: {Fibonacci(n)}");
            Console.WriteLine($"Valoarea lui {factorial}! este: {Factorial(factorial)}");
        }

        public static NumarMare Fibonacci(int n)
        {
            NumarMare nrf1 = new NumarMare(new int[] { 0 });
            NumarMare nrf2 = new NumarMare(new int[] { 1 });
            NumarMare t;

            for (int i = 0; i < n; i++)
            {
                t = nrf1;
                nrf1 = nrf2;
                nrf2 += t;
            }
            return nrf1;
        }

        public static NumarMare Factorial(int factorial)
        {
            NumarMare rez = new NumarMare(5000);
            int rs = 1, t = 0, aux;
            rez.numar[0] = 1;

            for (int i = 2; i <= factorial; i++)
            {
                for (int j = 0; j < rs; j++)
                {
                    aux = rez.numar[j] * i + t;
                    rez.numar[j] = aux % 10;
                    t = aux / 10;
                }
                while (t != 0)
                {
                    rez.numar[rs] = t % 10;
                    rs++;
                    t = t / 10;
                }
            }

            NumarMare x = new NumarMare(rs);

            for (int i = 0; i < x.numar.Length; i++)
                x.numar[i] = rez.numar[i];

            Array.Reverse(x.numar);

            return x;
        }
    }
}
