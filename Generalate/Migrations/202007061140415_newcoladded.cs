namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcoladded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_OfficialDocument", "MemberId", c => c.String());
            AddColumn("dbo.tbl_OfficialDocument", "CreatedBy", c => c.String());
            AddColumn("dbo.tbl_OfficialDocument", "CreatedDate", c => c.String());
            AddColumn("dbo.tbl_OfficialDocument", "UpdateBy", c => c.String());
            AddColumn("dbo.tbl_OfficialDocument", "UpdateDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_OfficialDocument", "UpdateDate");
            DropColumn("dbo.tbl_OfficialDocument", "UpdateBy");
            DropColumn("dbo.tbl_OfficialDocument", "CreatedDate");
            DropColumn("dbo.tbl_OfficialDocument", "CreatedBy");
            DropColumn("dbo.tbl_OfficialDocument", "MemberId");
        }
    }
}
