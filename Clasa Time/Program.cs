using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Time
{
    class Time
    {
        int ore, minute, secunde, sutimi;
        public Time(int ore = 0, int minute = 0, int secunde = 0, int sutimi = 0)
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
                s.AppendFormat("{0},{1},{2},{3} / ", ore, minute, secunde, sutimi);
                s.AppendFormat("{0}:{1}:{2}:{3}", ore, minute, secunde, sutimi);
            }
            return s.ToString();
        }
        public static int GetSutimiPlus(Time t)
        {
            int sutimi, sutimi1, sutimi2, sutimi3;

            sutimi1 = t.ore * 3600000;
            sutimi2 = t.minute * 60000;
            sutimi3 = t.secunde * 1000;

            sutimi = sutimi1 + t.sutimi + sutimi2 + sutimi3;

            return sutimi;
        }
        public static int GetSutimiMinus(Time t)
        {
            int sutimi, sutimi1, sutimi2, sutimi3;

            sutimi1 = t.ore * 3600000;
            sutimi2 = t.minute * 60000;
            sutimi3 = t.secunde * 1000;

            sutimi = sutimi1 - sutimi2 - sutimi3 - t.sutimi;

            return sutimi;
        }
        public static int operator +(Time t1, Time t2)
        {
            return GetSutimiPlus(t1) + GetSutimiPlus(t2);
        }
        public static int operator -(Time t1, Time t2)
        {
            return GetSutimiMinus(t1) - GetSutimiMinus(t2);
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
            Time t1 = new Time(10, 15, 50, 80);
            Time t2 = new Time(8, 30, 17, 15);

            Console.WriteLine($"Time1: {t1}");
            Console.WriteLine($"Time2: {t2}");
            Console.WriteLine($"Adunarea timpurilor este de {t1 + t2} sutimi");
            Console.WriteLine($"Scaderea timpurilor este de {t1 - t2} sutimi");

            if (t1 == t2)
                Console.WriteLine("Timpurile sunt la fel");
            else if (t1 < t2)
                Console.WriteLine("Timpul 1 este anterior timpului 2");
            else
                Console.WriteLine("Timpul 2 este anterior timpului 1");
        }
    }
}
