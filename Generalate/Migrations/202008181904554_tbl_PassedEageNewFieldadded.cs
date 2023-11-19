namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_PassedEageNewFieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Passed", "EAge", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Passed", "EAge");
        }
    }
}
