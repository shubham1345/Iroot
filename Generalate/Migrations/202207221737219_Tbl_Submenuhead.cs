namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Submenuhead : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Submenuhead",
                c => new
                    {
                        Submenu_Id = c.Int(nullable: false, identity: true),
                        Submenu_Name = c.String(),
                        Topmenu_Id = c.Int(nullable: false),
                        Topmenu_Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Submenu_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Submenuhead");
        }
    }
}
