namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedMedicationsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO Medications(Name, ArticleNumber) VALUES ('Digitalis','SH61237');
                INSERT INTO Medications(Name, ArticleNumber) VALUES ('Mirtazapin', 'DA512124');
                INSERT INTO Medications(Name, ArticleNumber) VALUES ('SSRI', '152124');
                INSERT INTO Medications(Name, ArticleNumber) VALUES ('Neuroleptika', 'AS125512');
                INSERT INTO Medications(Name, ArticleNumber) VALUES ('Risperidon', 'SE21421');      
");
        }

        public override void Down()
        {
        }
    }
}
