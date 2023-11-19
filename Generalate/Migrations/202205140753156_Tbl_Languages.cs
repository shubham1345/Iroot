namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Languages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Languages",
                c => new
                    {
                        Lnaguage_Id = c.Int(nullable: false, identity: true),
                        Language_Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Lnaguage_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Languages");
        }
    }
}
