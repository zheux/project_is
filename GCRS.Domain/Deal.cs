using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRS.Domain
{
    public enum State { Requested, Draft, Published, Paid, Canceled};

    public class Deal
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Property Property { get; set; }
        public Agent Agent { get; set; }
        public State State { get; set; }
        public uint Comission { get; set; }
    }
}
