using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Extensions
{
    public class QueryFactory
    {
        public class Query
        {
            public string[] Operator { get; set; }
            public QueryFactory.Fliter[] Filter { get; set; }
        }
        public class Fliter
        {
            public string FilterTerm { get; set; }
            public string FilterArgument { get; set; }
            public string Operator { get; set; }
            public string[] OperatorArguments { get; set; }
        }
        public class Operators
        {
            private class EqualityQuery
            {
                private readonly string field;
                private readonly string value;

                public EqualityQuery(string field, string value)
                {
                    this.field = field;
                    this.value = value;
                }
                public Tuple<string, string, string> ToTuple()
                {
 	                 return Tuple.Create<string, string, string>(this.field, "eq", this.value);
                }
            }
            private class LessThanQuery
            {
                private readonly string field;
                private readonly string value;

                public LessThanQuery(string field, string value)
                {
                    this.field = field;
                    this.value = value;
                }
                public Tuple<string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string>(this.field, "lt", this.value);
                }
            }
            private class GreaterThanQuery
            {
                private readonly string field;
                private readonly string value;

                public GreaterThanQuery(string field, string value)
                {
                    this.field = field;
                    this.value = value;
                }
                public Tuple<string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string>(this.field, "gt", this.value);
                }
            }
            private class BetweenQuery
            {
                private readonly string field;
                private readonly string low;
                private readonly string high;

                public BetweenQuery(string field, string low, string high)
                {
                    this.field = field;
                    this.low = low;
                    this.high = high;
                }
                public Tuple<string, string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string, string>(this.field, "between", this.low, this.high);
                }
            }
            private class InLastQuery
            {
                private readonly string field;
                private readonly List<Intervals> interval;

                public InLastQuery(string field, Intervals interval)
                {
                    this.field = field;
                    this.interval = new List<Intervals>();
                    foreach (Intervals i in interval)
                    {
                        this.interval.Add(i);
                    }
                }
                public Tuple<string, string, List<Intervals>> ToTuple()
                {
                    return Tuple.Create<string, string, List<Intervals>>(this.field, "in last", this.interval);
                }
            }
            private class InNextQuery
            {
                private readonly string field;
                private readonly List<Intervals> interval;

                public InNextQuery(string field, Intervals interval)
                {
                    this.field = field;
                    this.interval = new List<Intervals>();
                    foreach (Intervals i in interval)
                    {
                        this.interval.Add(i);
                    }
                }
                public Tuple<string, string, List<Intervals>> ToTuple()
                {
                    return Tuple.Create<string, string, List<Intervals>>(this.field, "in next", this.interval);
                }
            }
            public class DateMatchQuery
            {
                private readonly string field;
                private readonly List<Dates> date;

                public DateMatchQuery(string field, Dates dates)
                {
                    this.field = field;
                    this.date = new List<Dates>();
                    foreach (Dates d in dates)
                    {
                        this.date.Add(d);
                    }
                }
                public Tuple<string, string, List<Dates>> ToTuple()
                {
                    return Tuple.Create<string, string, List<Dates>>(this.field, "datematch", this.date);
                }
            }
            private class ContansQuery
            {
                private readonly string field;
                private readonly string value;

                public ContansQuery(string field, string value)
                {
                    this.field = field;
                    this.value = value;
                }
                public Tuple<string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string>(this.field, "contains", this.value);
                }
            }
            private class AnyQuery
            {
                private readonly string field;
                private readonly string value;

                public AnyQuery(string field, string value)
                {
                    this.field = field;
                    this.value = value;
                }
                public Tuple<string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string>(this.field, "any", this.value);
                }
            }
            private class IsInQuery
            {
                private readonly string field;
                private readonly List<int> values;

                public IsInQuery(string field, List<int> values)
                {
                    this.field = field;
                    this.values = values;
                }
                public Tuple<string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string>(this.field, "in", string.Join<int>(", ", values));
                }
            }
            private class ZipRadiusQuery
            {
                private readonly string field;
                private readonly int radius;
                private readonly int zip;

                public ZipRadiusQuery(string field, int radius, int zip)
                {
                    List<int> ints = new List<int> { 5, 10, 15, 20, 25, 50 };
                    if (!ints.Contains(radius))
                        radius = 5; // So it doesn't blow up the call.
                    this.field = field;
                    this.radius = radius;
                    this.zip = zip;
                }
                public Tuple<string, string, string> ToTuple()
                {
                    return Tuple.Create<string, string, string>(this.field, "zip-radius:" + radius.ToString(), zip.ToString());
                }
            }
        }
    }
}
