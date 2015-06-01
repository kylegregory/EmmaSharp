using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Response
{
    public sealed class DelieveryType
    {
        private readonly string name;

        public static readonly DelieveryType All = new DelieveryType("all");
        public static readonly DelieveryType Delivered = new DelieveryType("delivered");
        public static readonly DelieveryType Bounced = new DelieveryType("bounced");
        public static readonly DelieveryType Hard = new DelieveryType("hard");
        public static readonly DelieveryType Soft = new DelieveryType("soft");

        private DelieveryType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
