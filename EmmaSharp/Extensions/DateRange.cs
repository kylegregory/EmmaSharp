using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Extensions
{
    public sealed class DateRange
    {
        public static DateTime Start { get; private set; }
        public static DateTime End { get; private set; }

        //public DateRange(DateTime? start, DateTime? end)
        //{
        //    Start = start.Value;
        //    End = end.Value;
        //}

        

        //public bool Includes(DateTime value)
        //{
        //    return (Start <= value) && (value <= End);
        //}

        //public bool Includes(IRange<DateTime> range)
        //{
        //    return (Start <= range.Start) && (range.End <= End);
        //}

        public static string BuildRange(/*this IRange<DateTime> range, bool specificDate = false*/)
        {
            string r = string.Empty;
            //if (specificDate)
            //{
            //    r += range.Start;
            //}
            //else if (range.Start != null && range.End != null)
            //{
            //    r += range.Start + "~" + range.End;
            //}
            //else if (range.Start == null && range.End != null)
            //{
            //    r += "~" + range.End;
            //}
            //else if (range.Start != null && range.End == null)
            //{
            //    r += range.Start + "~";
            //}
            return r;
        }
    }
}
