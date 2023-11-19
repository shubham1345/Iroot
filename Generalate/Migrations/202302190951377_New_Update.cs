namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_formationsStatusYear",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        formationsDetailsId = c.Int(nullable: false),
                        MemberId = c.String(),
                        Status = c.String(),
                        StatusYear = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tbl_Primarydetails", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Primarydetails", "Remarks");
            DropTable("dbo.Tbl_formationsStatusYear");
        }
    }
}
