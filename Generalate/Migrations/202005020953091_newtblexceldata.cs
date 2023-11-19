namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtblexceldata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExcelSheetDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataType = c.String(),
                        FileUpload = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExcelSheetDatas");
        }
    }
}
