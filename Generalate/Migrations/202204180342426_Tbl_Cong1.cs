namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Cong1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Cong", "IsStatisticActive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Cong", "IsStatisticActive");
        }
    }
}
