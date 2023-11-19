namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Primarydetails", "Name", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Primarydetails", "Name");
        }
    }
}
