namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    PersonNumber = c.String(),
                    PhoneNumber = c.String(),
                    Adress = c.String(),
                    ZipCode = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Medications",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ArticleNumber = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Patients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(maxLength: 30),
                    LastName = c.String(maxLength: 50),
                    PersonNumber = c.String(),
                    PhoneNumber = c.String(),
                    Adress = c.String(maxLength: 30),
                    ZipCode = c.String(maxLength: 15),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Relatives",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    PhoneNumber = c.String(),
                    Adress = c.String(),
                    ZipCode = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Schedules",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateTime = c.DateTime(nullable: false),
                    PatientId = c.Int(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.EmployeeId);

            CreateTable(
                "dbo.TodoList",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TaskId = c.Int(nullable: false),
                    ScheduleId = c.Int(nullable: false),
                    IsDone = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.ScheduleId);

            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PatientMedications",
                c => new
                {
                    Patient_Id = c.Int(nullable: false),
                    Medication_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Patient_Id, t.Medication_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Medications", t => t.Medication_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Medication_Id);

            CreateTable(
                "dbo.RelativePatients",
                c => new
                {
                    Relative_Id = c.Int(nullable: false),
                    Patient_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Relative_Id, t.Patient_Id })
                .ForeignKey("dbo.Relatives", t => t.Relative_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Relative_Id)
                .Index(t => t.Patient_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.TodoList", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TodoList", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.RelativePatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.RelativePatients", "Relative_Id", "dbo.Relatives");
            DropForeignKey("dbo.PatientMedications", "Medication_Id", "dbo.Medications");
            DropForeignKey("dbo.PatientMedications", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.RelativePatients", new[] { "Patient_Id" });
            DropIndex("dbo.RelativePatients", new[] { "Relative_Id" });
            DropIndex("dbo.PatientMedications", new[] { "Medication_Id" });
            DropIndex("dbo.PatientMedications", new[] { "Patient_Id" });
            DropIndex("dbo.TodoList", new[] { "ScheduleId" });
            DropIndex("dbo.TodoList", new[] { "TaskId" });
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropIndex("dbo.Schedules", new[] { "PatientId" });
            DropTable("dbo.RelativePatients");
            DropTable("dbo.PatientMedications");
            DropTable("dbo.Tasks");
            DropTable("dbo.TodoList");
            DropTable("dbo.Schedules");
            DropTable("dbo.Relatives");
            DropTable("dbo.Patients");
            DropTable("dbo.Medications");
            DropTable("dbo.Employees");
        }
    }
}
