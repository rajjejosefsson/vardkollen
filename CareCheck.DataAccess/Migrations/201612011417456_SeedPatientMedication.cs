namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedPatientMedication : DbMigration
    {
        public override void Up()
        {

            Sql(@"

                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (1,1);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (1,2);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (1,3);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (1,4);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (2,1);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (2,2);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (3,4);
                INSERT INTO PatientMedications(Patient_Id, Medication_Id) VALUES (3,5);

    ");
        }

        public override void Down()
        {
        }
    }
}
