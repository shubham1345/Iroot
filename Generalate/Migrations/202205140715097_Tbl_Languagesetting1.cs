namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Languagesetting1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Languagesetting", "Language_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Languagesetting", "Language_Id");
        }
    }
}
