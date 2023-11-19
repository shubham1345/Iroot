namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralCouncil1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralCouncils", "Mandate", c => c.String());
            AddColumn("dbo.tblGenCommissions", "ManDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblGenCommissions", "ManDate");
            DropColumn("dbo.GeneralCouncils", "Mandate");
        }
    }
}
