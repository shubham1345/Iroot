namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoumnsGeneralCouncil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralCouncils", "Name", c => c.String());
            AddColumn("dbo.GeneralCouncils", "Designation", c => c.String());
            AddColumn("dbo.GeneralCouncils", "Responsibility", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralCouncils", "Responsibility");
            DropColumn("dbo.GeneralCouncils", "Designation");
            DropColumn("dbo.GeneralCouncils", "Name");
        }
    }
}
