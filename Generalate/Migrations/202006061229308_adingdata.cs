namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adingdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_DistSecCommission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistSecName = c.String(),
                        DistSecId = c.String(),
                        FromDate = c.String(),
                        ToDate = c.String(),
                        MemberName = c.String(),
                        DesignationName = c.String(),
                        ResponsibilityName = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Circulars", "Date2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Circulars", "Date2");
            DropTable("dbo.tbl_DistSecCommission");
        }
    }
}
