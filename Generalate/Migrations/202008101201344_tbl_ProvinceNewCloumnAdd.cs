namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_ProvinceNewCloumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Province", "Motto", c => c.String());
            AddColumn("dbo.tbl_Province", "Logo", c => c.String());
            AddColumn("dbo.tbl_Province", "CountriesofMission", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Province", "CountriesofMission");
            DropColumn("dbo.tbl_Province", "Logo");
            DropColumn("dbo.tbl_Province", "Motto");
        }
    }
}
