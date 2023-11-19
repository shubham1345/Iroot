namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ParisInstitutionDetails2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Continent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Continent");
        }
    }
}
