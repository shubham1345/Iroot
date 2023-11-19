namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsnewmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Passed", "MemberID", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Name", c => c.String());
            AlterColumn("dbo.tbl_Passed", "LastCommunity", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Cause", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Date", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Age", c => c.String());
            AlterColumn("dbo.tbl_Passed", "WorkingYear", c => c.String());
            AlterColumn("dbo.tbl_Passed", "CurrentStatusFor", c => c.String());
            AlterColumn("dbo.tbl_Passed", "CurrentStatusAppo", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Time", c => c.String());
            AlterColumn("dbo.tbl_Passed", "InstitutionPlace", c => c.String());
            AlterColumn("dbo.tbl_Passed", "LastNatureRites", c => c.String());
            AlterColumn("dbo.tbl_Passed", "LastPlaceRites", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Spare1", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Spare2", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Spare3", c => c.String());
            AlterColumn("dbo.tbl_Passed", "SirName", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Description", c => c.String());
            AlterColumn("dbo.tbl_Passed", "Title", c => c.String());
            AlterColumn("dbo.tbl_Passed", "ProvinceName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Passed", "ProvinceName", c => c.String(maxLength: 550));
            AlterColumn("dbo.tbl_Passed", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Passed", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_Passed", "SirName", c => c.String(maxLength: 35));
            AlterColumn("dbo.tbl_Passed", "Spare3", c => c.String(maxLength: 35));
            AlterColumn("dbo.tbl_Passed", "Spare2", c => c.String(maxLength: 35));
            AlterColumn("dbo.tbl_Passed", "Spare1", c => c.String(maxLength: 35));
            AlterColumn("dbo.tbl_Passed", "LastPlaceRites", c => c.String(maxLength: 256));
            AlterColumn("dbo.tbl_Passed", "LastNatureRites", c => c.String(maxLength: 256));
            AlterColumn("dbo.tbl_Passed", "InstitutionPlace", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Passed", "Time", c => c.String(maxLength: 10));
            AlterColumn("dbo.tbl_Passed", "CurrentStatusAppo", c => c.String(maxLength: 150));
            AlterColumn("dbo.tbl_Passed", "CurrentStatusFor", c => c.String(maxLength: 150));
            AlterColumn("dbo.tbl_Passed", "WorkingYear", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Passed", "Age", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Passed", "Date", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Passed", "Cause", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Passed", "LastCommunity", c => c.String(maxLength: 256));
            AlterColumn("dbo.tbl_Passed", "Name", c => c.String(maxLength: 256));
            AlterColumn("dbo.tbl_Passed", "MemberID", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
