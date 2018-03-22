using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public void AddPurchase(Purchase purchase)
        {
            using (var context = new ApplicationDbContext())
            {
                if (purchase != null)
                {
                    context.Purchases.Add(purchase);
                    context.SaveChanges();
                }
            }
        }

        public void RemovePurchase(int OfferId, string ClientUsername)
        {
            using (var context = new ApplicationDbContext())
            {
                var purchase = context.Purchases.SingleOrDefault(m => m.SellOfferId== OfferId && m.ClientUsername == ClientUsername);
                if (purchase != null)
                {
                    context.Purchases.Remove(purchase);
                    context.SaveChanges();
                }
            }
        }

        public Purchase FindPurchase(Func<Purchase, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Purchases.SingleOrDefault(predicate);
            }
        }
        
        public IEnumerable<Purchase> GetPurchases()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Purchases.ToList();
            }
        }
    }
}
