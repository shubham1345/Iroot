namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdataadding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_DioceseData", "DioceseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_DioceseData", "DioceseName");
        }
    }
}
