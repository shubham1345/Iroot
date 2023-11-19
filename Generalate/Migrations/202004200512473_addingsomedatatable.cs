namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsomedatatable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralateFileNoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                        MemberId = c.String(),
                        ProFileNo = c.String(),
                        GenFileNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneralateFileNoes");
        }
    }
}
