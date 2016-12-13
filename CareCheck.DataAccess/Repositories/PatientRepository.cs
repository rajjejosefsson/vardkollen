using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        public ICollection<Patient> PatientList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Patients.AsNoTracking().ToList();
            }
        }

        public Patient FindById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Patients.AsNoTracking().SingleOrDefault(p => p.Id == id);
            }
        }

        public void InsertOrUpdate(Patient patient)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                // if using create or edit
                if (patient.Id == 0)
                {
                    context.Patients.Add(patient);
                }
                else
                {
                    // EDIT Employee (Could use dto)
                    var patientInDb = context.Patients.SingleOrDefault(p => p.Id == patient.Id);
                    patientInDb.FirstName = patient.FirstName;
                    patientInDb.LastName = patient.LastName;
                    patientInDb.PersonNumber = patient.PersonNumber;
                    patientInDb.PhoneNumber = patient.PhoneNumber;
                    patientInDb.Adress = patient.Adress;
                    patientInDb.ZipCode = patient.ZipCode;
                }

                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                var patientInDb = context.Patients.SingleOrDefault(e => e.Id == id);
                context.Patients.Remove(patientInDb);
                context.SaveChanges();
            }
        }









    }
}