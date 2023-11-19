namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrationsfoecouncil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralCouncils", "GenId", c => c.String(maxLength: 150));
            AddColumn("dbo.GeneralCouncils", "GenName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralCouncils", "GenName");
            DropColumn("dbo.GeneralCouncils", "GenId");
        }
    }
}
