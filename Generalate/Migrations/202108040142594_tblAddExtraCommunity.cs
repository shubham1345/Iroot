namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblAddExtraCommunity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAddExtraCommunities",
                c => new
                    {
                        EntryId = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        UserId = c.String(maxLength: 550),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.EntryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblAddExtraCommunities");
        }
    }
}
