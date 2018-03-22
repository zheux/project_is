using System;
using System.Collections.Generic;

namespace GCRS.Domain
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        void RemoveReservation(int OfferId, string ClientUsername);
        Reservation FindReservation(Func<Reservation, bool> predicate);
        IEnumerable<Reservation> GetReservations();
    }
}
