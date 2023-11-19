namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_LandDetailsByProvince : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_LandDetailsByProvince",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        LandType = c.String(),
                        PCIId = c.String(),
                        DocumentType = c.String(),
                        Date = c.String(),
                        Title = c.String(),
                        File = c.String(),
                        CreatedDate = c.String(),
                        ProvinceName = c.String(),
                        ParishName = c.String(),
                        CreatedBy = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_LandDetailsByProvince");
        }
    }
}
