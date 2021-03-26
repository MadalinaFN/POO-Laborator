using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Rational
{
    class Rational
    {
        private int numarator, numitor;
        public Rational()
        {
            numarator = 0;
            numitor = 0;
        }
        public Rational(int numarator)
        {
            this.numarator = numarator;
            this.numitor = 0;
        }
        public Rational(int numarator, int numitor)
        {
            this.numarator = numarator;
            this.numitor = numitor;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.AppendFormat("{0}/{1}", numarator, numitor);

            return s.ToString();
        }
        public static Rational operator +(Rational r1, Rational r2)
        {
            return new Rational(((r1.numarator * r2.numitor) + (r2.numarator * r1.numitor)), r1.numitor * r2.numitor);
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            return new Rational(((r1.numarator * r2.numitor) - (r2.numarator * r1.numitor)), r1.numitor * r2.numitor);
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational(r1.numarator * r2.numarator, r1.numitor * r2.numitor);
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.numarator * r2.numitor, r1.numitor * r2.numarator);
        }
        public static Rational operator ^(Rational r1, int n)
        {
            Rational r2 = new Rational(r1.numarator, r1.numitor);

            for (int i = 1; i < n; i++)
            {
                r2.numarator = r2.numarator * r1.numarator;
                r2.numitor = r2.numitor * r1.numitor;
            }

            return r2;
        }
        public Rational simplificare(Rational r1)
        {
            int numarator = r1.numarator, numitor = r1.numitor, d = 2;

            while (d <= numarator)
            {
                if (numitor % d == 0 && numarator % d == 0)
                {
                    numitor = numitor / d;
                    numarator = numarator / d;
                }
                else
                {
                    d++;
                }
            }
            return new Rational(numarator, numitor);
        }
        public static bool operator ==(Rational r1, Rational r2)
        {
            if ((r1.numarator == r2.numarator) && (r1.numitor == r2.numitor))
                return true;
            return false;
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            if (r1.numarator == r2.numarator && r1.numitor == r2.numitor)
                return false;
            return true;
        }
        public static bool operator <(Rational r1, Rational r2)
        {
            if ((r1.numarator < r2.numarator) && (r1.numitor > r2.numitor))
                return true;
            if ((r1.numarator > r2.numarator) && (r1.numitor > r2.numitor))
                return true;
            return false;
        }
        public static bool operator <=(Rational r1, Rational r2)
        {
            if ((r1.numarator < r2.numarator) && (r1.numitor > r2.numitor) || (r1.numarator == r2.numarator) && (r1.numitor == r2.numitor))
                return true;
            if ((r1.numarator > r2.numarator) && (r1.numitor > r2.numitor) || (r1.numarator == r2.numarator) && (r1.numitor == r2.numitor))
                return true;
            return false;
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            if ((r1.numarator < r2.numarator) && (r1.numitor > r2.numitor) || (r1.numarator == r2.numarator) && (r1.numitor == r2.numitor))
                return false;
            if ((r1.numarator > r2.numarator) && (r1.numitor > r2.numitor) || (r1.numarator == r2.numarator) && (r1.numitor == r2.numitor))
                return false;
            return true;
        }
        public static bool operator >=(Rational r1, Rational r2)
        {
            if ((r1.numarator < r2.numarator) && (r1.numitor > r2.numitor))
                return false;
            if ((r1.numarator > r2.numarator) && (r1.numitor > r2.numitor))
                return false;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            Rational r1 = new Rational(5, 6);
            Rational r2 = new Rational(15, 30);

            Console.WriteLine($"Rational 1 = {r1}");
            Console.WriteLine($"Rational 2 = {r2}");
            Console.WriteLine($"Adunare = {r1 + r2}");
            Console.WriteLine($"Scadere = {r1 - r2}");
            Console.WriteLine($"Inmultire = {r1 * r2}");
            Console.WriteLine($"Impartire = {r1 / r2}");
            Console.WriteLine($"Ridicare la puterea {n} a lui {r1} = {r1 ^ n}");
            Console.WriteLine($"Ridicare la puterea {n} a lui {r2} = {r2 ^ n}");
            Console.WriteLine($"{r1} simplificata = {r1.simplificare(r1)}");
            Console.WriteLine($"{r2} simplificata = {r2.simplificare(r2)}");

            if (r1 == r2)
                Console.WriteLine("Rationali sunt egali");
            else if (r1 < r2)
                Console.WriteLine("Rationalul 1 este mai mic decat rationalul 2");
            else
                Console.WriteLine("Rationalul 2 este mai mic decat rationalul 1");
        }
    }
}
