namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedEmployeesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

    INSERT INTO Employees(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Martin','Matsson','930307-6694',   '0738479598', 'Fjällvägen 28D', '45153');
    INSERT INTO Employees(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Rasmus','Josefsson','900422-7136', '0722244865', 'Skandiavägen 6B', '45143');
    INSERT INTO Employees(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Patrik','Emilsson','960402-2189', '0761819606', 'Thunbergsgatan 11', '46140');
    INSERT INTO Employees(FirstName, LastName, PersonNumber, PhoneNumber, Adress, ZipCode) VALUES ('Vidar','Asp Johansson','950813-4157', '0733723182', 'Mjölnaregatan 16', '46132');

");
        }

        public override void Down()
        {
        }
    }
}
