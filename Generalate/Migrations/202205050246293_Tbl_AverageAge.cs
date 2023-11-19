namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_AverageAge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_AverageAge",
                c => new
                    {
                        Age_ID = c.Int(nullable: false, identity: true),
                        Average_Age = c.String(),
                    })
                .PrimaryKey(t => t.Age_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_AverageAge");
        }
    }
}
