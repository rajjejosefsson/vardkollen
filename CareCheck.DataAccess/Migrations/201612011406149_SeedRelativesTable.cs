namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedRelativesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode) VALUES ('Anders','Johansson', '072124552', '´Kungsgatan 29B', '45112');
                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode) VALUES ('Nils','Nilsson', '0724214223', 'Slottskogen 31A', '45112');
                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode) VALUES ('Johan','Ballan', '0734214122', 'Tallskogsgatan 15C', '45112');
                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode) VALUES ('Nicklas','Garbo', '0734124921', 'Brunnsgatan 31C', '45112');
");
        }

        public override void Down()
        {
        }
    }
}
