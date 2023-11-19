namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaditionsdatatbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_DioBishSec",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DioId = c.String(),
                        MyId = c.String(),
                        DioName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        Address = c.String(),
                        File = c.String(),
                        Date = c.String(),
                        ProvinceName = c.String(),
                        BishopName = c.String(),
                        Types = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_DioBishSec");
        }
    }
}
