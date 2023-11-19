namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoggingTrackAddTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoggingTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoggingTime = c.String(),
                        LoginLogout = c.String(),
                        LoginId = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoggingTracks");
        }
    }
}
