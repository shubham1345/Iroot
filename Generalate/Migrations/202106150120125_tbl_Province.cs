namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_Province : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Province", "StartDate", c => c.String());
            AddColumn("dbo.tbl_Province", "EndDate", c => c.String());
            AddColumn("dbo.tbl_Province", "SuspensionDate", c => c.String());
            AddColumn("dbo.tbl_Province", "RestartDate", c => c.String());
            AddColumn("dbo.tbl_Province", "NameofFounders", c => c.String());
            AddColumn("dbo.tbl_Province", "NameofFounder", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Province", "NameofFounder");
            DropColumn("dbo.tbl_Province", "NameofFounders");
            DropColumn("dbo.tbl_Province", "RestartDate");
            DropColumn("dbo.tbl_Province", "SuspensionDate");
            DropColumn("dbo.tbl_Province", "EndDate");
            DropColumn("dbo.tbl_Province", "StartDate");
        }
    }
}
