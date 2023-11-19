namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataLists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataLists", "Name_French", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataLists", "Name_French");
        }
    }
}
