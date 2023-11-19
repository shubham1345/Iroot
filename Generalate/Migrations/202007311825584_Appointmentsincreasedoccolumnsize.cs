namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointmentsincreasedoccolumnsize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "doc", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Appointments", "DesignationType", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "DesignationType", c => c.String(maxLength: 500));
            AlterColumn("dbo.Appointments", "doc", c => c.String(maxLength: 50));
        }
    }
}
