namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentsSGGeneralteNewFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "SGGeneralate", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "SGGeneralate");
        }
    }
}
