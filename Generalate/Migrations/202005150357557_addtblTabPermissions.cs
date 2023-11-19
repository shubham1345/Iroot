namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtblTabPermissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(),
                        RoleName = c.String(),
                        TabName = c.String(),
                        TabViewName = c.String(),
                        TabId = c.Int(nullable: false),
                        provinceId = c.String(),
                        IsView = c.Boolean(nullable: false),
                        IsAdd = c.Boolean(nullable: false),
                        IsEdit = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TabPermissions");
        }
    }
}
