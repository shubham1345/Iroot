namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_ProvinceGallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_ProvinceGallery",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainID = c.String(),
                        Title = c.String(),
                        FileName = c.String(),
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
            DropTable("dbo.tbl_ProvinceGallery");
        }
    }
}
