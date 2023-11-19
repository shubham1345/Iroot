namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_15_03_23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_formationsStatusYear",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        formationsDetailsId = c.Int(nullable: false),
                        MemberId = c.String(),
                        Status = c.String(),
                        StatusYear = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_SubmenuTabs",
                c => new
                    {
                        SubmenuTabsId = c.Int(nullable: false, identity: true),
                        Submenutab_Name = c.String(),
                        Submenu_Id = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.SubmenuTabsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_SubmenuTabs");
            DropTable("dbo.Tbl_formationsStatusYear");
        }
    }
}
