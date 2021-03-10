using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Stars
{
    class Stars
    {
        int nrlinii;

        //Constructor
        public Stars(int n=0)
        {
            Console.WriteLine("Introduceti numarul de linii:");
            nrlinii = n;
        }

        //Metoda
        static void Main(string[] args)
        {
            Stars S = new Stars();
            S.nrlinii = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= S.nrlinii; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //Destructor
        ~Stars()
        {
            Console.WriteLine("DESTRUCTORUL A FOST APELAT");
            Console.WriteLine();
        }
    }
}
