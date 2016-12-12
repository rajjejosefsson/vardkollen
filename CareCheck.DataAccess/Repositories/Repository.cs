using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {

        internal CareCheckDbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(CareCheckDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public ICollection<TEntity> All()
        {
            return dbSet.ToList();
        }


    }
}