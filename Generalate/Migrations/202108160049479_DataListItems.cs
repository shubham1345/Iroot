namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataListItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataListItems", "Name_French", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataListItems", "Name_French");
        }
    }
}
