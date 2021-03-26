using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Time
{
    class Time
    {
        private int ore, minute, secunde, sutimi;
        public Time(int ore, int minute)
        {
            this.ore = ore;
            this.minute = minute;
        }
        public Time(int ore, int minute, int secunde)
        {
            this.ore = ore;
            this.minute = minute;
            this.secunde = secunde;
        }
        public Time(int ore, int minute, int secunde, int sutimi)
        {
            this.ore = ore;
            this.minute = minute;
            this.secunde = secunde;
            this.sutimi = sutimi;
        }
        public Time(string s)
        {
            char[] separator = { ',', ':' };
            string[] x = s.Split(separator);

            if (x.Length > 4)
                Console.WriteLine("Data incorecta!");
            else
            {
                this.ore = Convert.ToInt32(x[0]);
                this.minute = Convert.ToInt32(x[1]);
                this.secunde = Convert.ToInt32(x[2]);
                this.sutimi = Convert.ToInt32(x[3]);
            }
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (secunde == 0 && sutimi == 0)
            {
                s.AppendFormat("{0},{1}", ore, minute);
            }
            else if (sutimi == 0)
            {
                s.AppendFormat("{0},{1},{2}", ore, minute, secunde);
            }
            else
            {
                //s.AppendFormat("{0},{1},{2},{3} / ", ore, minute, secunde, sutimi);
                s.AppendFormat("{0}:{1}:{2}:{3}", ore, minute, secunde, sutimi);
            }
            return s.ToString();
        }
        public static Time operator +(Time t1, Time t2)
        {
            Time t = new Time(0, 0, 0, 0);
            int k;

            t.sutimi = (t1.sutimi + t2.sutimi) % 100;
            k = (t1.sutimi + t2.sutimi) / 100;

            t.secunde = (t1.secunde + t2.secunde + k) % 60;
            k = (t1.secunde + t2.secunde + k) / 60;

            t.minute = (t1.minute + t2.minute + k) % 60;
            k = (t1.minute + t2.minute + k) / 60;

            t.ore = t1.ore + t2.ore + k;

            return t;
        }
        public static Time operator -(Time t1, Time t2)
        {
            Time t = new Time(0, 0, 0, 0);
            int k;

            t.ore = t1.ore - t2.ore;

            t.minute = (t1.minute - t2.minute) % 60;
            k = (t1.minute - t2.minute) / 60;

            t.secunde = (t1.secunde - t2.secunde + k) % 60;
            k = (t1.secunde - t2.secunde + k) / 60;

            t.sutimi = (t1.sutimi - t2.sutimi + k) % 100;
            k = (t1.sutimi - t2.sutimi + k) / 100;

            return t;
        }
        public static bool operator ==(Time t1, Time t2)
        {
            if ((t1.ore == t2.ore) && (t1.minute == t2.minute) && (t1.secunde == t2.secunde) && (t1.sutimi == t2.sutimi))
                return true;
            return false;
        }
        public static bool operator !=(Time t1, Time t2)
        {
            if (t1 == t2)
                return false;
            return true;
        }
        public static bool operator <(Time t1, Time t2)
        {
            if (t1.ore < t2.ore)
                return true;
            if ((t1.ore == t2.ore) && (t1.minute < t2.minute))
                return true;
            if ((t1.ore == t2.ore) && (t1.minute == t2.minute) && (t1.secunde < t2.secunde))
                return true;
            if ((t1.ore == t2.ore) && (t1.minute == t2.minute) && (t1.secunde == t2.secunde) && (t1.sutimi < t2.sutimi))
                return true;
            return false;
        }
        public static bool operator <=(Time t1, Time t2)
        {
            if (t1 < t2 || t1 == t2)
                return true;
            return false;
        }
        public static bool operator >(Time t1, Time t2)
        {
            if (t1 <= t2)
                return false;
            return true;
        }
        public static bool operator >=(Time t1, Time t2)
        {
            if (t1 < t2)
                return false;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(10, 30, 25, 75);
            Time t2 = new Time(47, 50, 40, 60);

            Console.WriteLine($"Time1: {t1}");
            Console.WriteLine($"Time2: {t2}");
            Console.WriteLine($"Adunarea timpurilor este {t1 + t2}");
            Console.WriteLine($"Scaderea timpurilor este {t1 - t2}");

            if (t1 == t2)
                Console.WriteLine("Timpurile sunt la fel");
            else if (t1 < t2)
                Console.WriteLine("Timpul 1 este anterior timpului 2");
            else
                Console.WriteLine("Timpul 2 este anterior timpului 1");
        }
    }
}
