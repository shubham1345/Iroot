namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtbldatatbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Calender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenName = c.String(),
                        GenId = c.String(),
                        FromDate = c.String(),
                        ToDate = c.String(),
                        Event = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Calender");
        }
    }
}
