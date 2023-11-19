namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_PersonalDetails", "CurrentStatus", c => c.String());
            AddColumn("dbo.Tbl_formationsDetails", "CurrentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_formationsDetails", "CurrentStatus");
            DropColumn("dbo.tbl_PersonalDetails", "CurrentStatus");
        }
    }
}
