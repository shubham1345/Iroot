namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMandateindatatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_provinceData", "Mandate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_provinceData", "Mandate");
        }
    }
}
