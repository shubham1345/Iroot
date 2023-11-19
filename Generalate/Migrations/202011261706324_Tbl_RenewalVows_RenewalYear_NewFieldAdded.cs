namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_RenewalVows_RenewalYear_NewFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RenewalVows", "RenewalYear", c => c.String(maxLength: 50));
            AddColumn("dbo.Tbl_RenewalVows", "FromDate", c => c.String());
            AddColumn("dbo.Tbl_RenewalVows", "ToDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_RenewalVows", "ToDate");
            DropColumn("dbo.Tbl_RenewalVows", "FromDate");
            DropColumn("dbo.Tbl_RenewalVows", "RenewalYear");
        }
    }
}
