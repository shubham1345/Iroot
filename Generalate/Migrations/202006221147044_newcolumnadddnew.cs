namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnadddnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Province", "Fax", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Province", "Fax");
        }
    }
}
