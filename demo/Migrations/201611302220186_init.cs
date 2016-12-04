namespace demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffSchedules",
                c => new
                    {
                        StaffId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffId, t.ScheduleId })
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Staff",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffSchedules", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.StaffSchedules", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.StaffSchedules", new[] { "ScheduleId" });
            DropIndex("dbo.StaffSchedules", new[] { "StaffId" });
            DropTable("dbo.Staff");
            DropTable("dbo.StaffSchedules");
            DropTable("dbo.Schedules");
        }
    }
}
