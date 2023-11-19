namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_Congregation4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Congregation", "Continent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Congregation", "Continent");
        }
    }
}
