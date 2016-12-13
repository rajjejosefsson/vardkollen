using CareCheck.DomainClasses;
using System.Data.Entity;

namespace CareCheck.DataAccess
{
    public class CareCheckDbContext : DbContext
    {

        public CareCheckDbContext() : base("CareCheckDb")
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Relative> Relatives { get; set; }
    }
}