using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public enum TagType { Sell, Rental, All}

    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public TagType TagType { get; set; }
    }
}
