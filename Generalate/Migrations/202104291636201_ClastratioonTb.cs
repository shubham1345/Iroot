namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClastratioonTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claustrations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(),
                        ClaustrationFromDate = c.String(),
                        ClaustrationToDate = c.String(),
                        ClaustrationPurpose = c.String(),
                        ClaustrationPlace = c.String(),
                        ClaustrationCommunity = c.String(),
                        Claustrationdecree = c.String(),
                        ClaustrationMotivation = c.String(),
                        ClaustrationStatus = c.String(),
                        ClaustrationRemarks = c.String(),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Claustrations");
        }
    }
}
