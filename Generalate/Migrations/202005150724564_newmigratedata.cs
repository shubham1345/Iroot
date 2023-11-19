namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigratedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Diocese", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Diocese");
        }
    }
}
