namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ProvinceCouncil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ProvinceCouncil", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProvinceCouncil", "Status");
        }
    }
}
