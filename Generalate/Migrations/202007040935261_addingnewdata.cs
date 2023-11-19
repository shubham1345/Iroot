namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_OfficialDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocType1 = c.String(),
                        NameAndNo1 = c.String(),
                        Document1 = c.String(),
                        DocType2 = c.String(),
                        NameAndNo2 = c.String(),
                        Document2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_OfficialDocument");
        }
    }
}
