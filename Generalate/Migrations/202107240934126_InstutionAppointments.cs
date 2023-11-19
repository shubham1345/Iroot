namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstutionAppointments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstutionAppointments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstutionAppointments", "Status");
        }
    }
}
