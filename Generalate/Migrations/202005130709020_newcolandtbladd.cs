namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolandtbladd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_DioceseCom",
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
                        CreatedDate = c.String(),
                        ProvinceName = c.String(),
                        ComName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_DioceseCom");
        }
    }
}
