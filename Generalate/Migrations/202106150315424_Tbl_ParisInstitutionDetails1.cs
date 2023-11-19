namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tbl_ParisInstitutionDetails1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "NameOfFoundress", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "NameOfFounder", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "FoundationDate", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Foundationday", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "DiocesanDecreeDate", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "PontificalDecreeDate", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "GouvernementalDecreeDate", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "DepCIVCSVA", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "DepCIVCSVA");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "GouvernementalDecreeDate");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "PontificalDecreeDate");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "DiocesanDecreeDate");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Foundationday");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "FoundationDate");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "NameOfFounder");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "NameOfFoundress");
        }
    }
}
