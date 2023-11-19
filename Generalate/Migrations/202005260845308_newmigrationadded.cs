namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrationadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ProvinceCouncil", "MemberName", c => c.String());
            AddColumn("dbo.Tbl_ProvinceCouncil", "DesignationName", c => c.String());
            AddColumn("dbo.Tbl_ProvinceCouncil", "ResponsibilityName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProvinceCouncil", "ResponsibilityName");
            DropColumn("dbo.Tbl_ProvinceCouncil", "DesignationName");
            DropColumn("dbo.Tbl_ProvinceCouncil", "MemberName");
        }
    }
}
