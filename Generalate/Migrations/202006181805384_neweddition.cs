namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neweddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MultiLanguages", "FranchText", c => c.String());
            AddColumn("dbo.MultiLanguages", "Language2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MultiLanguages", "Language2");
            DropColumn("dbo.MultiLanguages", "FranchText");
        }
    }
}
