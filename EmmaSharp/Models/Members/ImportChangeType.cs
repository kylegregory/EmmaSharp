using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSharp.Models.Members
{
    public sealed class ImportChangeType
    {
        private readonly string name;

        public static readonly ImportChangeType Add = new ImportChangeType("a");
        public static readonly ImportChangeType Update = new ImportChangeType("u");

        private ImportChangeType(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
