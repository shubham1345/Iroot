namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_Congregation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Congregation", "FoundationDate", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Foundationday", c => c.String());
            AddColumn("dbo.tbl_Congregation", "DiocesanDecreeDate", c => c.String());
            AddColumn("dbo.tbl_Congregation", "PontificalDecreeDate", c => c.String());
            AddColumn("dbo.tbl_Congregation", "GouvernementalDecreeDate", c => c.String());
            AddColumn("dbo.tbl_Congregation", "DepCIVCSVA", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Congregation", "DepCIVCSVA");
            DropColumn("dbo.tbl_Congregation", "GouvernementalDecreeDate");
            DropColumn("dbo.tbl_Congregation", "PontificalDecreeDate");
            DropColumn("dbo.tbl_Congregation", "DiocesanDecreeDate");
            DropColumn("dbo.tbl_Congregation", "Foundationday");
            DropColumn("dbo.tbl_Congregation", "FoundationDate");
        }
    }
}
