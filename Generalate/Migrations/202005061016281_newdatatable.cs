namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatatable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_DioceseData");
            AlterColumn("dbo.tbl_DioceseData", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tbl_DioceseData", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_DioceseData");
            AlterColumn("dbo.tbl_DioceseData", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.tbl_DioceseData", "Id");
        }
    }
}
