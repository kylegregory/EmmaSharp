using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Extensions
{
    public class Dates : IEnumerable
    {
        public class Dates
        {
            public Date Date { get; set; }
            public int Value { get; set; }
        }
        public sealed class Date
        {
            private readonly string name;

            public static readonly Date Year = new Date("year");
            public static readonly Date Month = new Date("month");
            public static readonly Date Day = new Date("day");
            public static readonly Date Hour = new Date("hour");
            public static readonly Date Minute = new Date("minute");
            public static readonly Date Second = new Date("second");
            public static readonly Date DateOfWeek = new Date("dow");

            private Date(string name)
            {
                this.name = name;
            }

            public override string ToString()
            {
                return this.name;
            }
        }
    }
}
