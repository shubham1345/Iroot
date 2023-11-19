namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaddingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Circulars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                        Date = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Name = c.String(),
                        File = c.String(),
                        GenFilecheck = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GeneralateFileNoes", "GenFilecheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralateFileNoes", "GenFilecheck");
            DropTable("dbo.Circulars");
        }
    }
}
