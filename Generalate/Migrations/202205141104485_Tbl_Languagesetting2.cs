namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_Languagesetting2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Languagesetting", "LanguageCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Languagesetting", "LanguageCode");
        }
    }
}
