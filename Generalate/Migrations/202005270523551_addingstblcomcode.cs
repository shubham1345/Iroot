namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingstblcomcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComOutSides", "ComCode", c => c.String());
            AddColumn("dbo.tbl_DioceseCom", "ComCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_DioceseCom", "ComCode");
            DropColumn("dbo.ComOutSides", "ComCode");
        }
    }
}
