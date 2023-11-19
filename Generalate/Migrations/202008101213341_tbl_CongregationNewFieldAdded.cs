namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_CongregationNewFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Congregation", "NameofFounder", c => c.String());
            AddColumn("dbo.tbl_Congregation", "NameofCoFounder", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Motto", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Logo", c => c.String());
            AddColumn("dbo.tbl_Congregation", "CountriesofMission", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Congregation", "CountriesofMission");
            DropColumn("dbo.tbl_Congregation", "Logo");
            DropColumn("dbo.tbl_Congregation", "Motto");
            DropColumn("dbo.tbl_Congregation", "NameofCoFounder");
            DropColumn("dbo.tbl_Congregation", "NameofFounder");
        }
    }
}
