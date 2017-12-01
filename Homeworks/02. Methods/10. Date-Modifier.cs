using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    //57% solved!!!
    
    public class DateModifier
    {
        public long difference;

        public DateModifier(long dif)
        {
            this.difference = dif;
        }

        public static void CalculateDifference(string start, string end)
        {
            string[] s = start.Split();
            int sYear = int.Parse(s[0]);
            int sMonth = int.Parse(s[1]);
            int sDay = int.Parse(s[2]);

            string[] e = end.Split();
            int eYear = int.Parse(e[0]);
            int eMonth = int.Parse(e[1]);
            int eDay = int.Parse(e[2]);

            DateTime ends = new DateTime(eYear, eMonth, eDay);
            DateTime starts = new DateTime(sYear, sMonth, sDay);
            double daysBetween = ends.Subtract(starts).TotalDays;
            Console.WriteLine((daysBetween));

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            DateModifier.CalculateDifference(a, b);

        }
    }
}
