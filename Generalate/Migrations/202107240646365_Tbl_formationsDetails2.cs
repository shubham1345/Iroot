namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_formationsDetails2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_formationsDetails", "Receivedby", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_formationsDetails", "Receivedby", c => c.String());
        }
    }
}
