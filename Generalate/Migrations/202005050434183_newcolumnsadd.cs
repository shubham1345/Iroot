namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumnsadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataListItems", "Continent", c => c.String());
            AddColumn("dbo.tbl_Primarydetails", "Continent", c => c.String());
            AddColumn("dbo.tbl_Primarydetails", "LangSpocken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Primarydetails", "LangSpocken");
            DropColumn("dbo.tbl_Primarydetails", "Continent");
            DropColumn("dbo.DataListItems", "Continent");
        }
    }
}
