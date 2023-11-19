namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Submenuhead2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Submenuhead", "File_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Submenuhead", "File_Name");
        }
    }
}
