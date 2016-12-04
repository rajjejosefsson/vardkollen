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
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-01 13:45', 4, 2);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-01 13:55', 3, 3);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-01 15:15', 2, 2);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-02 04:30', 1, 4);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-02 07:00', 4, 3);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-02 09:30', 3, 2);
                INSERT INTO Schedules(DateTime, PatientId, EmployeeId) VALUES ('2016-12-02 12:15', 3, 1);
");
        }

        public override void Down()
        {
        }
    }
}
