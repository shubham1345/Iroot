namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Mandate", c => c.String());
            AddColumn("dbo.Appointments", "Place", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Place");
            DropColumn("dbo.Appointments", "Mandate");
        }
    }
}
