namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatalisttablhousevisit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_HomeVisit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FromDate = c.String(),
                        ToDate = c.String(),
                        Purpose = c.String(),
                        Place = c.String(),
                        Description = c.String(),
                        TransferLetter = c.String(),
                        ProvinceId = c.String(),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tbl_HomeLiveAndHomeVisit", "FromDate", c => c.String(maxLength: 256));
            AddColumn("dbo.tbl_HomeLiveAndHomeVisit", "ToDate", c => c.String(maxLength: 256));
            AddColumn("dbo.tbl_HomeLiveAndHomeVisit", "Description", c => c.String());
            AddColumn("dbo.tbl_HomeLiveAndHomeVisit", "ProvinceId", c => c.String(maxLength: 550));
            AlterColumn("dbo.tbl_HomeLiveAndHomeVisit", "ProvinceName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_HomeLiveAndHomeVisit", "ProvinceName", c => c.String(maxLength: 550));
            DropColumn("dbo.tbl_HomeLiveAndHomeVisit", "ProvinceId");
            DropColumn("dbo.tbl_HomeLiveAndHomeVisit", "Description");
            DropColumn("dbo.tbl_HomeLiveAndHomeVisit", "ToDate");
            DropColumn("dbo.tbl_HomeLiveAndHomeVisit", "FromDate");
            DropTable("dbo.tbl_HomeVisit");
        }
    }
}
