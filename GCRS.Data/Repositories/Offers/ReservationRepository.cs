using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void AddReservation(Reservation reservation)
        {
            using (var context = new ApplicationDbContext())
            {
                if (reservation != null)
                {
                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveReservation(int OfferId, string ClientUsername)
        {
            using (var context = new ApplicationDbContext())
            {
                var reservation = context.Reservations.SingleOrDefault(m => m.RentalOfferId == OfferId && m.ClientUsername == ClientUsername);
                if (reservation != null)
                {
                    context.Reservations.Remove(reservation);
                    context.SaveChanges();
                }
            }
        }

        public Reservation FindReservation(Func<Reservation, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Reservations.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Reservation> GetReservations()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Reservations.ToList();
            }
        }
    }
}
