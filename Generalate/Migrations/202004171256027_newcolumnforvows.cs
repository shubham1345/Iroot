namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnforvows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RenewalVows", "MemberId", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_RenewalVows", "MemberId");
        }
    }
}
