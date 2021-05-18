using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_IForma2D
{
    public interface IForma2D
    {
        double Aria();
        double LungimeaFrontierei();
        string Denumire { get; }
    }
    public class Cerc : IForma2D
    {
        public double raza;
        private const float PI = 3.14159f;
        string s = "cercului";
        public Cerc(double r)
        {
            raza = r;
        }
        public double Aria()
        {
            return PI * raza * raza;
        }
        public double LungimeaFrontierei()
        {
            return 2 * PI * raza;
        }
        public string Denumire
        {
            get
            {
                return s;
            }
        }
    }
    public class Patrat : IForma2D
    {
        public double latura;
        string s = "patratului";
        public Patrat(double l)
        {
            latura = l;
        }
        public double Aria()
        {
            return latura * latura;
        }
        public double LungimeaFrontierei()
        {
            return 4 * latura;
        }
        public string Denumire
        {
            get
            {
                return s;
            }
        }
    }
    class Program
    {
        static void DisplayInfo(IForma2D f)
        {
            Console.WriteLine("A = {0:#.##}", f.Aria());
            Console.WriteLine("LF = {0:#.##}", f.LungimeaFrontierei());
        }
        public static void Main()
        {
            Cerc c = new Cerc(3);
            Patrat p = new Patrat(3);

            Console.WriteLine("Aria si lungimea frontierei a {0}:", c.Denumire);
            DisplayInfo(c);
            Console.WriteLine();

            Console.WriteLine("Aria si lungimea frontierei a {0}:", p.Denumire);
            DisplayInfo(p);
        }
    }
}
