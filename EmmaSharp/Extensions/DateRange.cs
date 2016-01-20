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
        /// <summary>
        /// The Start or Specific Date.
        /// </summary>
        public DateTime? Start { get; set; }
        /// <summary>
        /// The End Date. Ignored if SpecificDate is true.
        /// </summary>
        public DateTime? End { get; set; }
        /// <summary>
        /// Set whether the call will use just the Start date.
        /// </summary>
        public bool SpecificDate { get; set; }

        /// <summary>
        /// Build a DateRage string for use in API calls. Use Optional SpecificDate attribute to specify a single date using only the Start date; End date will be ignored.
        /// </summary>
        public DateRange()
        {

        }
    }

    /// <summary>
    /// Extensions for the DateRange class.
    /// </summary>
    public static class DateRangeExtensions
    {
        /// <summary>
        /// Build a DateRage string for use in API calls. Use Optional SpecificDate attribute to specify a single date using only the Start date; End date will be ignored.
        /// </summary>
        /// <param name="range">A date range object.</param>
        /// <returns>A range string to be used in Response API calls.</returns>
        public static string BuildRangeString(this DateRange range)
        {
            string r = string.Empty;
            if (range.SpecificDate == true)
            {
                r += range.Start.Value.ToString("yyyy-MM-dd");
            }
            else if (range.Start != null && range.End != null)
            {
                r += range.Start.Value.ToString("yyyy-MM-dd") + "~" + range.End.Value.ToString("yyyy-MM-dd");
            }
            else if (range.Start == null && range.End != null)
            {
                r += "~" + range.End.Value.ToString("yyyy-MM-dd");
            }
            else if (range.Start != null && range.End == null)
            {
                r += range.Start.Value.ToString("yyyy-MM-dd") + "~";
            }
            return r;
        }
    }
}
