namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoumntabpermissiontbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TabPermissions", "IsPermission", c => c.String());
            DropColumn("dbo.TabPermissions", "IsView");
            DropColumn("dbo.TabPermissions", "IsAdd");
            DropColumn("dbo.TabPermissions", "IsEdit");
            DropColumn("dbo.TabPermissions", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TabPermissions", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.TabPermissions", "IsEdit", c => c.Boolean(nullable: false));
            AddColumn("dbo.TabPermissions", "IsAdd", c => c.Boolean(nullable: false));
            AddColumn("dbo.TabPermissions", "IsView", c => c.Boolean(nullable: false));
            DropColumn("dbo.TabPermissions", "IsPermission");
        }
    }
}
