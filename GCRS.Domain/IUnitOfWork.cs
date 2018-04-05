using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GCRS.Domain
{
    public interface IUnitOfWork
    {
        DbSet<T> Repository<T>() where T : class;

        int SaveChanges();
    }
}
