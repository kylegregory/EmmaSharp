using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Extensions
{
    /// <summary>
    /// Class to create a DateRange from two nullable DateTimes.
    /// </summary>
    public class DateRange
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? SpecificDate { get; set; }
    }

    /// <summary>
    /// Extensions for the DateRange class.
    /// </summary>
    public static class DateRangeExtensions
    {
        /// <summary>
        /// Build a DateRage string for use in API calls. Use Optional specificDate attribute to specify a single date from the Start date. End date will be ignored.
        /// </summary>
        /// <param name="range">A date range object.</param>
        /// <param name="specificDate">Optional. When used a specific date will be returned. End date will be ignored, if provided.</param>
        /// <returns>A range string to be used in Response API calls.</returns>
        public static string BuildRangeString(this DateRange range)
        {
            string r = string.Empty;
            if (range.SpecificDate.HasValue && range.SpecificDate.Value == true)
            {
                r += range.Start;
            }
            else if (range.Start != null && range.End != null)
            {
                r += range.Start + "~" + range.End;
            }
            else if (range.Start == null && range.End != null)
            {
                r += "~" + range.End;
            }
            else if (range.Start != null && range.End == null)
            {
                r += range.Start + "~";
            }
            return r;
        }
    }
}
