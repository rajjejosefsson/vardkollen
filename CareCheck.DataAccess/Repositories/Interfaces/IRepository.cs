using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{

    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> List();
        TEntity FindById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }


}
