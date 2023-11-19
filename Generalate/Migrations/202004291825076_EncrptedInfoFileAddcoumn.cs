namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EncrptedInfoFileAddcoumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UserLogins", "EncrptedInfoFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UserLogins", "EncrptedInfoFile");
        }
    }
}
