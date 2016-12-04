using System.Data.Entity;

namespace demo
{
    public class MyDbDemoContext : DbContext
    {
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffSchedule> StaffSchedules { get; set; }

        public DbSet<Patient> Schedules { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasKey(x => x.Id);
            modelBuilder.Entity<Patient>().HasKey(x => x.Id);

            modelBuilder.Entity<StaffSchedule>().HasKey(x =>
                new
                {
                    x.StaffId,
                    x.ScheduleId
                });

            modelBuilder.Entity<StaffSchedule>()
                .HasRequired(x => x.Staff)
                .WithMany(x => x.StaffSchedules)
                .HasForeignKey(x => x.StaffId);

            modelBuilder.Entity<StaffSchedule>()
                .HasRequired(x => x.Schedule)
                .WithMany(x => x.StaffSchedules)
                .HasForeignKey(x => x.ScheduleId);

        }

    }
}