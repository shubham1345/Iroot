namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataListItems1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataListItems", "intRank", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_ProfessionDetails", "intRank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProfessionDetails", "intRank");
            DropColumn("dbo.DataListItems", "intRank");
        }
    }
}
