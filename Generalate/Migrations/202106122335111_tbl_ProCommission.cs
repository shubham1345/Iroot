namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_ProCommission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_ProCommission", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_ProCommission", "Status");
        }
    }
}
