using CareCheck.DomainClasses;
using System.Collections.Generic;

namespace CareCheck.DataAccess.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        ICollection<Patient> PatientList();
        Patient FindById(int id);
        void InsertOrUpdate(Patient patient);
        void DeleteById(int id);

    }
}
