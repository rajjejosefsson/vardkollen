using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface IRelativeRepository
    {

        ICollection<Relative> RelativeList();

        Relative FindById(int id);

        Relative InsertOrUpdate(Relative relative);

        void DeleteById(int id);
    }
}
