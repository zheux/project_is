using System;

namespace GCRS.Domain
{

    public class Rental:Deal
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PricePerRTU { get; set; }
        public int RTUCount { get; set; }
        public RentTimeUnit RTU { get; set; }
    }
}
