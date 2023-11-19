namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_formationsDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_formationsDetails", "VowsDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_formationsDetails", "VowsDate");
        }
    }
}
