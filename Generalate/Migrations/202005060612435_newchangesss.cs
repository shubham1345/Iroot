namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchangesss : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_Diocese");
            AlterColumn("dbo.tbl_Diocese", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tbl_Diocese", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_Diocese");
            AlterColumn("dbo.tbl_Diocese", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.tbl_Diocese", "Id");
        }
    }
}
