namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatablforcong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Congregation", "Activities", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Diocese", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Congregation", "Diocese");
            DropColumn("dbo.tbl_Congregation", "Activities");
        }
    }
}
