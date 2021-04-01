using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clasa_Matrici
{
                                    /*****!!!IMPORTANT!!!******/
    /***** MATRICILE LE-AM PUS INTR-UN FISIER TEXT, SI NU POT PUNE FISIERELE TEXT LA ASSIGNMENT ******/
    /*CEEA CE CONTINE FISIERUL "MATRICE A" ESTE:
      4 4
      1 2 3 4
      2 4 5 7
      3 4 5 1
      5 4 1 2*/
    /*CEEA CE CONTINE FISIERUL "MATRICE B" ESTE:
      4 4
      2 1 1 0
      2 3 1 2
      6 4 6 1
      6 5 3 7*/
    /***LAS AICI SI LINK-UL MEU DE GITHUB PENTRU DACA DORITI SA RULATI PROGRAMUL SAU SA VEDETI PROGRAMUL CU FISIERELE TEXT: 
        https://github.com/MadalinaFN/POO-Laborator/tree/master/Clasa%20Matrici ***/

    class Matrici
    {
        private int n, m;
        private double[,] mat;

        public Matrici(int n, int m)
        {
            this.n = n;
            this.m = m;
            mat = new double[n, m];
        }

        public Matrici(string matrice, bool ok)
        {
            TextReader load = new StreamReader(matrice);
            if (ok)
            {
                    string buffer = load.ReadLine();
                    n = int.Parse(buffer.Split(' ')[0]);
                    m = int.Parse(buffer.Split(' ')[1]);
                    mat = new double[n, m];

                    for (int i = 0; i < n; i++)
                    {
                        string[] T = load.ReadLine().Split(' ');
                        for (int j = 0; j < m; j++)
                        {
                            mat[i, j] = int.Parse(T[j]);
                        }
                    }
            }
            else
            {
                List<string> localData = new List<string>();
                string buffer;

                while ((buffer = load.ReadLine()) != null)
                {
                    localData.Add(buffer);
                }

                n = localData.Count;
                m = localData[0].Split(' ').Length;
                mat = new double[n, m];

                for (int i = 0; i < n; i++)
                {
                    string[] M = localData[i].Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        mat[i, j] = int.Parse(M[j]);
                    }
                }
            }
        }

        public Matrici(int n)
        {
            this.n = n;
        }

        public Matrici adunare(Matrici a)
        {
            if (a.n == this.n && a.m == this.m)
            {
                Matrici rez = new Matrici(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] + a.mat[i, j];
                return rez;
            }
            else
            {
                Console.WriteLine("Matricile nu se pot aduna. Nu au aceeasi dimensiune.");
                return null;
            }
        }

        public Matrici scadere(Matrici a)
        {
            if (a.n == n && a.m == m)
            {
                Matrici rez = new Matrici(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] - a.mat[i, j];
                return rez;
            }
            else
            {
                Console.WriteLine("Matricile nu se pot scadea. Nu au aceeasi dimensiune.");
                return null;
            }
        }

        public Matrici inmultire(Matrici a)
        {
            if (a.n == m)
            {
                Matrici rez = new Matrici(n, a.m);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < a.m; j++)
                    {
                        rez.mat[i, j] = 0;
                        for (int k = 0; k < m; k++)
                        {
                            rez.mat[i, j] += mat[i, k] * a.mat[k, j];
                        }
                    }
                }
                return rez;
            }
            else
            {
                Console.WriteLine("Matricile nu se pot inmulti.");
                return null;
            }
        }

        public Matrici ridicarelaputere(Matrici a, int p)
        {
            Matrici rez = a;
            while (p > 1)
            {
                a = a.inmultire(rez);
                p--;
            }
            return a;
        }

        private double determinant(double[,] a, int n)
        {
            int i, j;
            double d, e, aux;
            if (n == 1)
                return a[0, 0];
            else
            {
                d = 0.0;
                for (j = 0; j < n; j++) //dezvoltarea după o linie
                {
                    //semn
                    if (((n - 1 - j) % 2 == 1) || (j == n - 1))
                        e = a[n - 1, j];
                    else
                        e = -a[n - 1, j];
                    //pun elementul curent pe ultima coloană
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                    if ((n - 1 + j) % 2 == 0)
                        d += e * determinant(a, n - 1);
                    else
                        d -= e * determinant(a, n - 1);
                    //refac matricea
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                }
                return d;
            }
        }

        public Matrici inversa(Matrici mat)
        {
            if (n == m)
            {
                double d = mat.determinant(this.mat, n);
                if (d != 0)
                {
                    Matrici rez = new Matrici(n, n);
                    Matrici temp = new Matrici(n, n);
                    //matricea transpusa
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            temp.mat[i, j] = mat.mat[j, i];
                    double aux;
                    int semn;
                    //matricea adjuncta
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            //interschimb linia i cu ultima linie (n-1)
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            //si coloana j cu ultima coloana (n-1)
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                            //stabilim semnul pentru permutarea liniilor si a
                            //coloanelor in matrice
                            semn = 1;
                            if (((n - 1 - i) % 2 == 0) && (i != n - 1))
                                semn *= -1;
                            if (((n - 1 - j) % 2 == 0) && (j != n - 1))
                                semn *= -1;
                            if ((i + j) % 2 == 1)
                                semn *= -1;
                            rez.mat[i, j] = semn * determinant(temp.mat, n - 1);
                            //refac matricea
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                        }
                    //matricea inversa
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            rez.mat[i, j] /= d;
                    return rez;
                }
                else
                {
                    Console.WriteLine("Matricea nu este inversabila. Are determinantul nul.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Matricea nu se poate inversa. Nu este patratica.");
                return null;
            }
        }

        public List<string> afisare()
        {
            List<string> rez = new List<string>();
            string buffer;
            for (int i = 0; i < n; i++)
            {
                buffer = "";
                for (int j = 0; j < m; j++)
                {
                    buffer += mat[i, j] + " ";
                }
                rez.Add(buffer);
            }
            return rez;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prima matrice este:");
            Matrici A = new Matrici(@"..\..\Matrice A.txt", true);
            foreach (string s in A.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine("A doua matrice este:");
            Matrici B = new Matrici(@"..\..\Matrice B.txt", true);
            foreach (string s in B.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine("Adunarea matricilor este:");
            Matrici C = A.adunare(B);
            foreach (string s in C.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine("Scaderea matricilor este:");
            Matrici D = A.scadere(B);
            foreach (string s in D.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine("Inmultirea matricilor este:");
            Matrici E = A.inmultire(B);
            foreach (string s in E.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            int p = 3;
            Console.WriteLine($"Ridicarea la puterea {p} a primei matrici este:");
            Matrici F = A.ridicarelaputere(A, p);
            foreach (string s in F.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine($"Ridicarea la puterea {p} a celei de-a doua matrice este:");
            Matrici G = B.ridicarelaputere(B, p);
            foreach (string s in G.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine($"Inversa primei matrici este:");
            Matrici H = A.inversa(A);
            foreach (string s in H.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            Console.WriteLine($"Inversa a celei de-a doua matrice este:");
            Matrici I = B.inversa(B);
            foreach (string s in I.afisare())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
}
