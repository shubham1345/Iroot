namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolrenewal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RenewalVows", "DeathCheck", c => c.String());
            AddColumn("dbo.Tbl_RenewalVows", "SapCheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_RenewalVows", "SapCheck");
            DropColumn("dbo.Tbl_RenewalVows", "DeathCheck");
        }
    }
}
