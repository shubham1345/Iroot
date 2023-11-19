namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedByaddcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UserLogins", "CreatedBy", c => c.String());
            AddColumn("dbo.Tbl_UserLogins", "CreatedDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UserLogins", "CreatedDate");
            DropColumn("dbo.Tbl_UserLogins", "CreatedBy");
        }
    }
}
