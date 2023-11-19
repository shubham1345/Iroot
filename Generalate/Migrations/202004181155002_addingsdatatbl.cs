namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsdatatbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Passed", "Diedcheck", c => c.String());
            AddColumn("dbo.tbl_SeperationFromTheCongregation", "Sapcheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_SeperationFromTheCongregation", "Sapcheck");
            DropColumn("dbo.tbl_Passed", "Diedcheck");
        }
    }
}
