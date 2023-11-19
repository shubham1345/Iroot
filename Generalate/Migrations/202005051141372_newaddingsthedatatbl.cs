namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newaddingsthedatatbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societys", "Vission", c => c.String());
            AddColumn("dbo.Societys", "Mission", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Vission", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Mission", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Vission", c => c.String());
            AddColumn("dbo.tbl_Congregation", "Mission", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Vission", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Mission", c => c.String());
            AddColumn("dbo.tbl_Province", "Vission", c => c.String());
            AddColumn("dbo.tbl_Province", "Mission", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Province", "Mission");
            DropColumn("dbo.tbl_Province", "Vission");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Mission");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Vission");
            DropColumn("dbo.tbl_Congregation", "Mission");
            DropColumn("dbo.tbl_Congregation", "Vission");
            DropColumn("dbo.Tbl_Cong", "Mission");
            DropColumn("dbo.Tbl_Cong", "Vission");
            DropColumn("dbo.Societys", "Mission");
            DropColumn("dbo.Societys", "Vission");
        }
    }
}
