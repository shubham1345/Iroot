namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_SeperationFromTheCongregation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_SeperationFromTheCongregation", "Added_Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_SeperationFromTheCongregation", "Added_Year");
        }
    }
}
