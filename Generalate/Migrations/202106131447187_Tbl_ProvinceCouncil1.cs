namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ProvinceCouncil1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_ProCommission", "Mandate", c => c.String());
            AddColumn("dbo.Tbl_ProvinceCouncil", "Mandate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProvinceCouncil", "Mandate");
            DropColumn("dbo.tbl_ProCommission", "Mandate");
        }
    }
}
