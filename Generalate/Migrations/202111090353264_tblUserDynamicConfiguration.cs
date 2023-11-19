namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblUserDynamicConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserDynamicConfigurations",
                c => new
                    {
                        Mainid = c.Int(nullable: false, identity: true),
                        ListType = c.String(),
                        ListData = c.String(),
                        CurrentUser = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Mainid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblUserDynamicConfigurations");
        }
    }
}
