namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatatableadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Diocese", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Diocese", "State");
        }
    }
}
