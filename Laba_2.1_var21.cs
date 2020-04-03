using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Era era = new Era();
            era.Time();
            Console.WriteLine(" ");
            era.Doba();
            Console.ReadKey();
        }
    }
    class Era
    {
        public Hours hours;
        public Minutes minutes;
        public Era()
        {
            hours = new Hours();
            minutes = new Minutes();
        }
        public void Time()
        {
            string h = Convert.ToString(hours.hour());
            string m = Convert.ToString(minutes.min());
            Console.WriteLine(h + ":" + m);
        }
        public void Doba()
        {
            if (hours.hour() >= 4 && hours.hour() < 11)
            {
                Console.WriteLine("Morning");
            }
            if (hours.hour() >= 11 && hours.hour() < 17)
            {
                Console.WriteLine("Afternoon");
            }
            if (hours.hour() >= 17 && hours.hour() < 22)
            {
                Console.WriteLine("Evening");
            }
            if (hours.hour() < 4 || hours.hour() >= 22)
            {
                Console.WriteLine("Night");
            }
        }
    }
    class Hours
    {
        public int hour()
        {
            DateTime d = DateTime.Now;
            int h = d.Hour;
            return h;
        }
    }
    class Minutes
    {
        public int min()
        {
            DateTime d = DateTime.Now;
            int m = d.Minute;
            return m;
        }
    }
}