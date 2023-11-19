namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcommoncolumninrolepermission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolePagePermissions", "CreatedBy", c => c.String());
            AddColumn("dbo.RolePagePermissions", "CreatedDate", c => c.String());
            AddColumn("dbo.RolePagePermissions", "UpdateBy", c => c.String());
            AddColumn("dbo.RolePagePermissions", "UpdateDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolePagePermissions", "UpdateDate");
            DropColumn("dbo.RolePagePermissions", "UpdateBy");
            DropColumn("dbo.RolePagePermissions", "CreatedDate");
            DropColumn("dbo.RolePagePermissions", "CreatedBy");
        }
    }
}
