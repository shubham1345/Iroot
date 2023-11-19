namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newforRetirement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Retirement", "Diedcheck", c => c.String());
            AddColumn("dbo.tbl_Retirement", "SapCheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Retirement", "SapCheck");
            DropColumn("dbo.tbl_Retirement", "Diedcheck");
        }
    }
}
