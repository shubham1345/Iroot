namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewcoldio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Diocese", "ProvinceName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Diocese", "ProvinceName");
        }
    }
}
