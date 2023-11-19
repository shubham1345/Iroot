namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Topmenuheader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Topmenuheader",
                c => new
                    {
                        Header_id = c.Int(nullable: false, identity: true),
                        Header_Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Header_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Topmenuheader");
        }
    }
}
