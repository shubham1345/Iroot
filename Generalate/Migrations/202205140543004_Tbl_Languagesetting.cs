namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Languagesetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Languagesetting",
                c => new
                    {
                        Setting_Id = c.Int(nullable: false, identity: true),
                        Active = c.String(),
                        Language_Name = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Setting_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Languagesetting");
        }
    }
}
