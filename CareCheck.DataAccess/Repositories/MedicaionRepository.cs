using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System.Collections.Generic;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class MedicaionRepository : IMedicaionRepository
    {

        public ICollection<Medication> MedicationList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Medications.AsNoTracking().ToList();
            }
        }

        public void InsertOrUpdate(Medication medication)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {
                if (!context.Medications.Any(t => t.Name == medication.Name))
                {
                    context.Medications.Add(medication);
                    context.SaveChanges();
                }
            }
        }


        public void DeleteById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                var medicationInDb = context.Medications.Single(e => e.Id == id);
                context.Medications.Remove(medicationInDb);
                context.SaveChanges();
            }
        }



        public ICollection<Medication> PatientsMedications(Patient patient)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                throw new System.NotImplementedException();
            }
        }
    }
}