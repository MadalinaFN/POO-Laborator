using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Stiva
{
    public class Stiva<T>
    {
        private T[] elem;
        private T[] x; //nu face nimic, e in plus
        private int nivel;
        public Stiva(int max)
        {
            elem = new T[max];
            x = new T[max]; //nu face nimic, e in plus
            nivel = 0;
        }
        public void Push(T data)
        {
            if (nivel < elem.Count())
                elem[nivel++] = data;
            else
                Console.WriteLine("Stiva plina!");
        }
        public T Pop()
        {
            if (nivel != 0)
            {
                nivel--;
                return elem[nivel];
            }
            else
            {
                Console.WriteLine("Stiva goala!");
                return x[nivel]; //am adaugat x-ul ca sa pot returna ceva aici deoarece nu pot returna un string sau int
            }
        }
        public void Clear()
        {
            if (nivel != 0)
            {
                elem = new T[elem.Length];
                nivel = 0;
            }
            else
                Console.WriteLine("Elementele din stiva au fost sterse deja!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stiva<char> st = new Stiva<char>(5);

            for (char ch = 'a'; ch <= 'f'; ch++)
                st.Push(ch);

            for (int i = 0; i < 6; i++)
                Console.WriteLine(st.Pop());

            st.Clear();
            Console.WriteLine();
        }
    }
}
