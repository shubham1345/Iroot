namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberUnicIdinTranfer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Transfer", "MemberUnicId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Transfer", "MemberUnicId");
        }
    }
}
