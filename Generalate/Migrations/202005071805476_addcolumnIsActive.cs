namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UserLogins", "MemberId", c => c.String());
            AddColumn("dbo.Tbl_UserLogins", "IsActive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UserLogins", "IsActive");
            DropColumn("dbo.Tbl_UserLogins", "MemberId");
        }
    }
}
