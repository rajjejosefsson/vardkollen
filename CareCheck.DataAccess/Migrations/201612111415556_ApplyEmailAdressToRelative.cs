namespace CareCheck.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyEmailAdressToRelative : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Relatives", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Relatives", "Email");
        }
    }
}
