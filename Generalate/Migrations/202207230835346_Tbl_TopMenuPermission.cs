namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_TopMenuPermission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_TopMenuPermission",
                c => new
                    {
                        TopMenu_Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(),
                        RoleName = c.String(),
                        PageName = c.String(),
                        HasPermission = c.Boolean(nullable: false),
                        PageViewName = c.String(),
                        ParentId = c.Int(nullable: false),
                        TopMenuHeader_Id = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.TopMenu_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_TopMenuPermission");
        }
    }
}
