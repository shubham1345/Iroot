namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_TopMenuPermission3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_TopMenuPermission", "MemberId", c => c.String());
            AddColumn("dbo.Tbl_TopMenuPermission", "MemberName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_TopMenuPermission", "MemberName");
            DropColumn("dbo.Tbl_TopMenuPermission", "MemberId");
        }
    }
}
