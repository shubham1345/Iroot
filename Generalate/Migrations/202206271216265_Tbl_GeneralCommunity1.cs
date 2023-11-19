namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_GeneralCommunity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_GeneralCommunity", "CreatedBy", c => c.String());
            AddColumn("dbo.Tbl_GeneralCommunity", "UpdateBy", c => c.String());
            AddColumn("dbo.Tbl_GeneralCommunity", "UpdateDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_GeneralCommunity", "UpdateDate");
            DropColumn("dbo.Tbl_GeneralCommunity", "UpdateBy");
            DropColumn("dbo.Tbl_GeneralCommunity", "CreatedBy");
        }
    }
}
