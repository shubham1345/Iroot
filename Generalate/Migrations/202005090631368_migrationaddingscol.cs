namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationaddingscol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_ComOSInstitute", "Diocese", c => c.String());
            AddColumn("dbo.tbl_ComOSInstitute", "ProvinceName", c => c.String());
            AddColumn("dbo.tbl_ComOSInstitute", "InstName", c => c.String());
            AddColumn("dbo.tbl_DioceseInst", "ProvinceName", c => c.String());
            AddColumn("dbo.tbl_DioceseInst", "InstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_DioceseInst", "InstName");
            DropColumn("dbo.tbl_DioceseInst", "ProvinceName");
            DropColumn("dbo.tbl_ComOSInstitute", "InstName");
            DropColumn("dbo.tbl_ComOSInstitute", "ProvinceName");
            DropColumn("dbo.tbl_ComOSInstitute", "Diocese");
        }
    }
}
