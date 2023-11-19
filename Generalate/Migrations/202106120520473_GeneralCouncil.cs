namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralCouncil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralCouncils", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralCouncils", "Status");
        }
    }
}
