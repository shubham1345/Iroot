namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaddedforvowscheck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_PersonalDetails", "Vowscheck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_PersonalDetails", "Vowscheck");
        }
    }
}
