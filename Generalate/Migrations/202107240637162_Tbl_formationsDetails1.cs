namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_formationsDetails1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_formationsDetails", "ReceivedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_formationsDetails", "ReceivedBy", c => c.String(maxLength: 50));
        }
    }
}
