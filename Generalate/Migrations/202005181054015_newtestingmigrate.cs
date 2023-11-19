namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtestingmigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataListItems", "FormationId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataListItems", "FormationId");
        }
    }
}
