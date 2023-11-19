namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_InstitutionAppointmentDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_InstitutionAppointmentDetails", "Name_French", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_InstitutionAppointmentDetails", "Name_French");
        }
    }
}
