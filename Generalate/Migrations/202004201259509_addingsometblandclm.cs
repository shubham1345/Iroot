namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsometblandclm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsLetters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.String(),
                        Description = c.String(),
                        NewsType = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsLetters");
        }
    }
}
