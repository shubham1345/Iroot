namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtblfordiocese : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Diocese",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DioId = c.String(),
                        DisSec = c.String(),
                        DioceseName = c.String(),
                        ActiveCkeck = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        EmailId = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_DioceseData",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DioId = c.String(),
                        Title = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_DioceseData");
            DropTable("dbo.tbl_Diocese");
        }
    }
}
