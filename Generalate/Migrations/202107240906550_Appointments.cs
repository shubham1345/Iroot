namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Status");
        }
    }
}
