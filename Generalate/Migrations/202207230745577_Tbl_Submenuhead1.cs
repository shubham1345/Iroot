namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Submenuhead1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Submenuhead", "Page_name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Submenuhead", "Page_name");
        }
    }
}
