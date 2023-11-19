namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaddcolpersonal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_PersonalDetails", "VowsStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_PersonalDetails", "VowsStatus");
        }
    }
}
