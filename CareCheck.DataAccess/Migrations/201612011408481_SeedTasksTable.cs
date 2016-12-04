namespace CareCheck.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTasksTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO Tasks(Name) VALUES ('St�da');
                INSERT INTO Tasks(Name) VALUES ('Handla');
                INSERT INTO Tasks(Name) VALUES ('Tv�tta');
                INSERT INTO Tasks(Name) VALUES ('Diska');
                INSERT INTO Tasks(Name) VALUES ('Ge Medicin');
                INSERT INTO Tasks(Name) VALUES ('Duscha');
                INSERT INTO Tasks(Name) VALUES ('Posta Brev');
                INSERT INTO Tasks(Name) VALUES ('Promenad');
                INSERT INTO Tasks(Name) VALUES ('P�kl�dnad');
");

        }

        public override void Down()
        {
        }
    }
}
