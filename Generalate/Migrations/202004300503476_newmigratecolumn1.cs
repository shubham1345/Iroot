namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigratecolumn1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RenewalVows", "FileNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_RenewalVows", "FileNo");
        }
    }
}
