namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtblcommission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_ProCommission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                        ProId = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_ProCommission");
        }
    }
}
