namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedScheduleTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-01 08:30', 1, 1);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-01 11:30', 1, 1);

                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-02 16:30', 3, 1);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-02 16:30', 5, 1);

                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-01 13:45', 3, 2);
");
        }

        public override void Down()
        {
        }
    }
}
