namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratecolumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralateFileNoes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralateFileNoes", "Name");
        }
    }
}
