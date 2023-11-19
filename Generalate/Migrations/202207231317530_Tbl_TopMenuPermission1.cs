namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_TopMenuPermission1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_TopMenuPermission", "CreatePageview", c => c.String());
            AddColumn("dbo.Tbl_TopMenuPermission", "EditPageview", c => c.String());
            AddColumn("dbo.Tbl_TopMenuPermission", "DeletePageview", c => c.String());
            AddColumn("dbo.Tbl_TopMenuPermission", "ViewPageview", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_TopMenuPermission", "ViewPageview");
            DropColumn("dbo.Tbl_TopMenuPermission", "DeletePageview");
            DropColumn("dbo.Tbl_TopMenuPermission", "EditPageview");
            DropColumn("dbo.Tbl_TopMenuPermission", "CreatePageview");
        }
    }
}
