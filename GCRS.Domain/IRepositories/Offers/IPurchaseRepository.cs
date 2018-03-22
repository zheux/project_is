using System;
using System.Collections.Generic;

namespace GCRS.Domain
{
    public interface IPurchaseRepository
    {
        void AddPurchase(Purchase purchase);
        void RemovePurchase(int OfferId, string ClientUsername);
        Purchase FindPurchase(Func<Purchase, bool> predicate);
        IEnumerable<Purchase> GetPurchases();
    }
}
