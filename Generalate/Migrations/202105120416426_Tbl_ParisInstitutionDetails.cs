namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ParisInstitutionDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "History", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Remarks");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "History");
        }
    }
}
