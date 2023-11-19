namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentsNewFieldAdded_Ins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "InsDesignationType", c => c.String());
            AddColumn("dbo.Appointments", "OptionGuid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "OptionGuid");
            DropColumn("dbo.Appointments", "InsDesignationType");
        }
    }
}
