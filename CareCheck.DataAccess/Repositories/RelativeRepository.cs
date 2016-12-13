using CareCheck.DataAccess.Repositories.Interfaces;
using CareCheck.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CareCheck.DataAccess.Repositories
{
    public class RelativeRepository : IRelativeRepository
    {

        public ICollection<Relative> RelativeList()
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Relatives.ToList();
            }
        }

        public Relative FindById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                return context.Relatives.SingleOrDefault(r => r.Id == id);
            }
        }

        public Relative InsertOrUpdate(Relative relative)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                throw new NotImplementedException();

            }
        }

        public void DeleteById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext())
            {
                var relativeInDb = context.Relatives.Single(e => e.Id == id);
                context.Relatives.Remove(relativeInDb);
                context.SaveChanges();
            }
        }






        public void ConnectRelativeAndPatient(int patientId, int relativeId)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {

                var relative = context.Relatives.SingleOrDefault(p => p.Id == relativeId);
                var patient = context.Patients.SingleOrDefault(p => p.Id == patientId);

                // Connects the relative with patient using navigations (collection) in EF 
                patient.Relatives.Add(relative);
                context.SaveChanges();
            }

        }



        public Relative RelativesPatientByEmail(string email)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {

                // Change to get by email instead
                return context.Relatives.Where(r => r.PhoneNumber == email)
                                                 .Include(p => p.Patients)
                                                 .Single();
            }
        }




        public Patient PatientDetailInfoById(int id)
        {
            using (CareCheckDbContext context = new CareCheckDbContext()) // Use concrete context type
            {

                return context.Patients.Where(p => p.Id == id)
                                                           .Include(m => m.Medications)
                                                           .Include(r => r.Relatives)
                                                           .Single();
            }
        }






    }
}