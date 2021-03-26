using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Complex
{
    class Complex
    {
        private double pReala, pImag;
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
        public static Complex operator ^(Complex c1, int n)
        {
            Complex c2 = new Complex(c1.pReala, c1.pImag);

            for (int i = 1; i < n; i++)
            {
                c2 = c2 * c1;
            }

            return c2;
        }
        public string formatrigonometrica()
        {
            double r = Math.Sqrt(Math.Pow(pReala, 2) + Math.Pow(pImag, 2));
            double fi = Math.Atan(pImag / pReala);
            return String.Format("{0:0.00}", r) + "(cos" + String.Format("{0:0.00}", fi) + " + i * sin" + String.Format("{0:0.00}", fi) + ")";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Complex c1 = new Complex(9.7, 4.3);
            Complex c2 = new Complex(3.5, 7.8);

            Console.WriteLine($"x = {c1}");
            Console.WriteLine($"y = {c2}");
            Console.WriteLine($"x + y = {c1 + c2}");
            Console.WriteLine($"x - y = {c1 - c2}");
            Console.WriteLine($"x * y = {c1 * c2}");
            Console.WriteLine($"x^{n} = {c1 ^ n}");
            Console.WriteLine($"Forma Trigonometrica a lui x = {c1.formatrigonometrica()}");
            Console.WriteLine($"Forma Trigonometrica a lui y = {c2.formatrigonometrica()}");
        }
    }
}
