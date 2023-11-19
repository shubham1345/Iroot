namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblContinentMst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblContinentMsts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContinentName = c.String(maxLength: 50),
                        ContinentName_French = c.String(maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblContinentMsts");
        }
    }
}
