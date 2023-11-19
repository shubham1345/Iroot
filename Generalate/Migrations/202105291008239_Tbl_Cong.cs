namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Cong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Cong", "History", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Cong", "Remarks");
            DropColumn("dbo.Tbl_Cong", "History");
        }
    }
}
