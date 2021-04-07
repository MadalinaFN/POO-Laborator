using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_ComplexD
{
    class Complex
    {
        protected double pReala, pImag;
        public Complex()
        {
            pReala = 0;
            pImag = 0;
        }
        public Complex(double pReala)
        {
            this.pReala = pReala;
            this.pImag = 0;
        }
        public Complex(double pReala, double pImag)
        {
            this.pReala = pReala;
            this.pImag = pImag;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            if (pImag > 0)
            {
                s.AppendFormat("{0:0.00} + {1:0.00}i", pReala, pImag);
            }
            if (pImag < 0)
            {
                s.AppendFormat("{0:0.00} - {1:0.00}i", pReala, Math.Abs(pImag));
            }
            if (pImag == 0)
            {
                s.AppendFormat("{0:0.00}", pReala);
            }

            return s.ToString();
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.pReala + c2.pReala, c1.pImag + c2.pImag);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.pReala - c2.pReala, c1.pImag - c2.pImag);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.pReala * c2.pReala - c1.pImag * c2.pImag, c1.pReala * c2.pImag + c1.pImag * c2.pReala);
        }
        public virtual string ridicare_la_putere(int n)
        {
            Complex c = new Complex(this.pReala, this.pImag);
            for (int i = 1; i < n; i++)
                c = c * this;
            return c.ToString();
        }
        public string formatrigonometrica()
        {
            double r = Math.Sqrt(Math.Pow(pReala, 2) + Math.Pow(pImag, 2));
            double fi = Math.Atan(pImag / pReala);
            return String.Format("{0:0.00}", r) + "(cos" + String.Format("{0:0.00}", fi) + " + i * sin" + String.Format("{0:0.00}", fi) + ")";
        }
    }
    class ComplexD: Complex
    {
        public ComplexD(double pReala, double pImag)
        {
            this.pReala = pReala;
            this.pImag = pImag;
        }
        public override string ridicare_la_putere(int n)
        {
            double r = Math.Sqrt(Math.Pow(this.pReala, 2) + Math.Pow(this.pImag, 2));
            double fi = Math.Atan(this.pImag / this.pReala);
            return String.Format("{0:0.00}", Math.Pow(r, n)) + "(cos" + String.Format("{0:0.00}", n * fi) + " + i * sin" + String.Format("{0:0.00}", n * fi) + ")";
        }
        public double Distanta(ComplexD[] cD1)
        {
            double min = double.MaxValue, minactual;

            for (int i = 0; i < cD1.Length; i++)
            {
                minactual = Math.Sqrt(Math.Pow(cD1[i].pReala - this.pReala, 2) + Math.Pow(cD1[i].pImag - this.pImag, 2));
                if (minactual < min)
                    min = minactual;
            }
            return min;
        }
    }
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = 5;
            Complex c1 = new Complex(9.7, 4.3);
            Complex c2 = new Complex(3.5, 7.8);

            ComplexD cD = new ComplexD(2.3, 8.9);
            ComplexD[] cD1 = new ComplexD[3];

            for (int i = 0; i < cD1.Length; i++)
            {
                cD1[i] = new ComplexD(rnd.Next(1, 10), rnd.Next(1, 10));
            }

            Console.WriteLine($"x = {c1}");
            Console.WriteLine($"y = {c2}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"cD = {cD}");
            Console.Write("cD1 = ");
            for (int i = 0; i < cD1.Length; i++)
            {
                Console.Write($"{cD1[i]} / ");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"x + y = {c1 + c2}");
            Console.WriteLine($"x - y = {c1 - c2}");
            Console.WriteLine($"x * y = {c1 * c2}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"cD^{n} = {cD.ridicare_la_putere(n)}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"Forma Trigonometrica a lui x = {c1.formatrigonometrica()}");
            Console.WriteLine($"Forma Trigonometrica a lui y = {c2.formatrigonometrica()}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"Distanta de la {cD} la multimea lui cD1 este = {cD.Distanta(cD1)}");
            Console.WriteLine("------------------------------------------------------------------------");
        }
    }
}
