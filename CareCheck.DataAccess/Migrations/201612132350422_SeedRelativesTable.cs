namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedRelativesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode, Email) VALUES ('Anders','Johansson', '072124552', 'Kungsgatan 29B', '45112', 'anders@gmail.com');
                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode, Email) VALUES ('Nils','Nilsson', '0724214223', 'Slottskogen 31A', '45112', 'nisse@gmail.com');
                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode, Email) VALUES ('Johan','Ballan', '0734214122', 'Tallskogsgatan 15C', '45112', 'ballan@gmail.com');
                INSERT INTO Relatives(FirstName, LastName, PhoneNumber, Adress, ZipCode, Email) VALUES ('Nicklas','Garbo', '0734124921', 'Brunnsgatan 31C', '45112', 'gabbe@gmail.com');
");
        }

        public override void Down()
        {
        }
    }
}
