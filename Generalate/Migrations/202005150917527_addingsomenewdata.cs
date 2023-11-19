namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingsomenewdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "OSProvince", c => c.String());
            AddColumn("dbo.Appointments", "OSCongName", c => c.String());
            AddColumn("dbo.Appointments", "OSCongProvince", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "OSCongProvince");
            DropColumn("dbo.Appointments", "OSCongName");
            DropColumn("dbo.Appointments", "OSProvince");
        }
    }
}
