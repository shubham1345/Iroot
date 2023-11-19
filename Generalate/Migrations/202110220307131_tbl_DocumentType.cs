namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_DocumentType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_DocumentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Name_French = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_DocumentType");
        }
    }
}
