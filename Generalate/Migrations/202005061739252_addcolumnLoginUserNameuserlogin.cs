namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnLoginUserNameuserlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UserLogins", "LoginUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UserLogins", "LoginUserName");
        }
    }
}
