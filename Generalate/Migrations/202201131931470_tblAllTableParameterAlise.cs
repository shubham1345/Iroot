namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblAllTableParameterAlise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAllTableParameterAlises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParameterName = c.String(),
                        AliasName = c.String(),
                        FrenchName = c.String(),
                        PageCode = c.String(),
                        IsShow = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblAllTableParameterAlises");
        }
    }
}
