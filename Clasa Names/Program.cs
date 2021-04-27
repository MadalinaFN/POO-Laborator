using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Names
{
    class Names
    {
        public List<string> names;
        public bool err;

        public Names()
        {
            names = new List<string>();
        }

        public string this[int index]
        {
            get
            {
                if (index < names.Count)
                {
                    err = false;
                    return names.ElementAt(index);
                }
                else
                {
                    err = true;
                    return "-1";
                }
            }
            set
            {
                if (index < names.Count)
                {
                    err = false;
                    names[index] = value;
                }
                else
                    err = true;
            }
        }

        public string this[string index]
        {
            get
            {
                string poz = "";
                bool ok = false;

                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i] == index)
                    {
                        poz = names[i];
                        ok = true;
                    }
                }

                if (ok == false)
                {
                    err = true;
                    return "-1";
                }
                else
                    return poz;
            }
        }

        public void Afisare(string nume)
        {
            names.Add(nume);
            foreach (string name in names)
                Console.WriteLine(name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Names nume1 = new Names();
            Names nume2 = new Names();
            Names nume3 = new Names();
            Names nume4 = new Names();

            Console.WriteLine("------------------");
            Console.WriteLine("Lista de nume:");
            Console.WriteLine("------------------");
            nume1.Afisare("Domocos Ionut");
            nume2.Afisare("Iulian Alexandra");
            nume3.Afisare("Trip Andrei");
            nume4.Afisare("Vesa Dorian");
            Console.WriteLine();
        }
    }
}
