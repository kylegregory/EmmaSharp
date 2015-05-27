using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Mailings
{
    public sealed class DeliveryTypeShort
    {
        private readonly string name;

        public static readonly DeliveryTypeShort Delieverd = new DeliveryTypeShort("d");
        public static readonly DeliveryTypeShort Hard = new DeliveryTypeShort("h");
        public static readonly DeliveryTypeShort Soft = new DeliveryTypeShort("s");

        private DeliveryTypeShort(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
    public sealed class DeliveryType
    {
        private readonly string name;

        public static readonly DeliveryType Delieverd = new DeliveryType("delivered");
        public static readonly DeliveryType Hard = new DeliveryType("hard");
        public static readonly DeliveryType Soft = new DeliveryType("short");

        private DeliveryType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
