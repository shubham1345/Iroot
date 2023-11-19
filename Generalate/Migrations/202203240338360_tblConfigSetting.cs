namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblConfigSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblConfigSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        strConfigKey = c.String(),
                        strConfigValue = c.String(),
                        strPurpose = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblConfigSettings");
        }
    }
}
