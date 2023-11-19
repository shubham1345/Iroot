namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtblcolmnedit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Health", "FromDate", c => c.String());
            AlterColumn("dbo.tbl_Health", "ToDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Health", "ToDate", c => c.String(maxLength: 10));
            AlterColumn("dbo.tbl_Health", "FromDate", c => c.String(maxLength: 10));
        }
    }
}
