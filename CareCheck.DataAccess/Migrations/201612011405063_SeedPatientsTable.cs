namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedPatientsTable : DbMigration
    {
        public override void Up()
        {

            Sql(@"
                INSERT INTO Patients(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Berit','Johansson','380107-6414', '0738479598', 'Drottninggatan 65C', '45112');
                INSERT INTO Patients(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Sture','Nilsson','390501-5136', '073124951', 'Simmvägen 23', '45151');
                INSERT INTO Patients(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Allan','Ballan','350121-2489', '075121357', 'Trelleborgsvägen 2', '5124');
                INSERT INTO Patients(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Greta','Garbo','410113-4127', '071124142', 'Sveavägen 21', '46412');


");
        }

        public override void Down()
        {
        }
    }
}
