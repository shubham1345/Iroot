namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcoladdhere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Academy", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Academy", "Description");
        }
    }
}
