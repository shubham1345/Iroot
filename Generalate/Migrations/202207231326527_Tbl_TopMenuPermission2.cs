namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_TopMenuPermission2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_TopMenuPermission", "Createpermission", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_TopMenuPermission", "Editpermission", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_TopMenuPermission", "Deletepermission", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_TopMenuPermission", "Viewpermission", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_TopMenuPermission", "Viewpermission");
            DropColumn("dbo.Tbl_TopMenuPermission", "Deletepermission");
            DropColumn("dbo.Tbl_TopMenuPermission", "Editpermission");
            DropColumn("dbo.Tbl_TopMenuPermission", "Createpermission");
        }
    }
}
