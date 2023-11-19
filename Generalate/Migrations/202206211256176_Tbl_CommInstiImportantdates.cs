namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_CommInstiImportantdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_CommInstiImportantdates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainID = c.String(),
                        Name = c.String(),
                        Day = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        IsActive = c.Int(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_CommInstiImportantdates");
        }
    }
}
