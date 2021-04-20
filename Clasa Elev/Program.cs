using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clasa_Elev
{
    public class Elev
    {
        public string nume;
        public string prenume;
        public int medie;

        public override string ToString()
        {
            return nume + " " + prenume + " " + medie.ToString();
        }

        public Elev(string n, string p, int nrnote, int[] note)
        {
            this.nume = n;
            this.prenume = p;

            int suma = 0;

            foreach (int nota in note)
            {
                suma = suma + nota;
            }

            medie = (int)Math.Round((double)suma / nrnote, MidpointRounding.ToEven);
        }

        public string NumeSiPrenume { get { return nume + " " + prenume; } private set { } }
        public int Medie { get { return medie; } private set { } }
    }

    internal class CElev
    {
        private Dictionary<Elev, int> elevi;

        public CElev(Dictionary<Elev, int> e)
        {
            this.elevi = e;
        }

        public void SortByMedium()
        {
            var items = from p in elevi orderby p.Value descending select p;

            Dictionary<Elev, int> newE = new Dictionary<Elev, int>();
            foreach (var item in items)
            {
                newE.Add(item.Key, item.Value);
            }
            elevi.Clear();

            foreach (var item in newE)
            {
                elevi.Add(item.Key, item.Value);
            }
        }

        public void Iesire()
        {
            string[] linii = Write(elevi);
            File.WriteAllLines(@"C:\Users\Mădă\source\repos\POO-Laborator\Clasa Elev\Iesire.txt", linii);
        }

        private string[] Write(Dictionary<Elev, int> elevi)
        {
            StringBuilder[] linii = new StringBuilder[elevi.Count];

            for (int i = 0; i < linii.Length; i++)
            {
                linii[i] = new StringBuilder();
            }

            List<Elev> l = elevi.Select(kvp => kvp.Key).ToList();
            List<int> lMedii = elevi.Select(kvp => kvp.Value).ToList();

            for (int i = 0; i < l.Count; i++)
            {
                linii[i].Append(l[i].NumeSiPrenume + " " + l[i].Medie);
            }

            string[] s = new string[elevi.Count];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = linii[i].ToString();
            }
            return s;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string[] linii = File.ReadAllLines(@"C:\Users\Mădă\source\repos\POO-Laborator\Clasa Elev\Intrare.txt");

            Dictionary<Elev, int> elevi = new Dictionary<Elev, int>();

            for (int i = 0; i < linii.Length; i++)
            {
                char[] seps = { ' ' };

                StringBuilder nume = new StringBuilder();
                StringBuilder prenume = new StringBuilder();

                int nrnote = 0;
                int[] note;

                string[] tokens = linii[i].Split(seps, StringSplitOptions.RemoveEmptyEntries);
                nume.Append(tokens[0]);
                prenume.Append(tokens[1]);
                nrnote = int.Parse(tokens[2]);
                note = new int[nrnote];

                for (int j = 0; j < nrnote; j++)
                {
                    note[j] = int.Parse(tokens[j + 2]);
                }

                Elev elev = new Elev(nume.ToString(), prenume.ToString(), nrnote, note);
                elevi.Add(elev, elev.Medie);
            }

            CElev el = new CElev(elevi);

            el.SortByMedium();
            el.Iesire();
        }
    }
}
