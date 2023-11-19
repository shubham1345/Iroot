namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoumnEncrptedInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UserLogins", "EncrptedInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UserLogins", "EncrptedInfo");
        }
    }
}
