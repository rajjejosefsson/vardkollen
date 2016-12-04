namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedRelativesPatientTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO RelativePatients(Relative_Id, Patient_Id) VALUES (1,1);
                INSERT INTO RelativePatients(Relative_Id, Patient_Id) VALUES (2,2);
                INSERT INTO RelativePatients(Relative_Id, Patient_Id) VALUES (3,3);
                INSERT INTO RelativePatients(Relative_Id, Patient_Id) VALUES (4,4);
        
    ");
        }

        public override void Down()
        {
        }
    }
}
