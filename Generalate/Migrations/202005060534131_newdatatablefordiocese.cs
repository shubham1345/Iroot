namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatatablefordiocese : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Diocese", "Place", c => c.String());
            AddColumn("dbo.tbl_Diocese", "FileDio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Diocese", "FileDio");
            DropColumn("dbo.tbl_Diocese", "Place");
        }
    }
}
