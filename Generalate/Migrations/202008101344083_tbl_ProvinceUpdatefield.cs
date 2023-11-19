namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_ProvinceUpdatefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Congregation", "CongregationMotto", c => c.String());
            AddColumn("dbo.tbl_Congregation", "CongregationLogo", c => c.String());
            AddColumn("dbo.tbl_Congregation", "CongregationCountriesofMission", c => c.String());
            AddColumn("dbo.tbl_Province", "ProvinceMotto", c => c.String());
            AddColumn("dbo.tbl_Province", "ProvinceLogo", c => c.String());
            AddColumn("dbo.tbl_Province", "ProvinceCountriesofMission", c => c.String());
            DropColumn("dbo.tbl_Congregation", "Motto");
            DropColumn("dbo.tbl_Congregation", "Logo");
            DropColumn("dbo.tbl_Congregation", "CountriesofMission");
            DropColumn("dbo.tbl_Province", "Motto");
            DropColumn("dbo.tbl_Province", "Logo");
            DropColumn("dbo.tbl_Province", "CountriesofMission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Province", "CountriesofMission", c => c.String());
            AddColumn("dbo.tbl_Province", "Logo", c => c.String());
            AddColumn("dbo.tbl_Province", "Motto", c => c.String());
            AddColumn("dbo.tbl_Congregation", "CountriesofMission", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Logo", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Motto", c => c.String());
            DropColumn("dbo.tbl_Province", "ProvinceCountriesofMission");
            DropColumn("dbo.tbl_Province", "ProvinceLogo");
            DropColumn("dbo.tbl_Province", "ProvinceMotto");
            DropColumn("dbo.tbl_Congregation", "CongregationCountriesofMission");
            DropColumn("dbo.tbl_Congregation", "CongregationLogo");
            DropColumn("dbo.tbl_Congregation", "CongregationMotto");
        }
    }
}
