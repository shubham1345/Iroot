namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcoladdwithenterby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societys", "Enterby", c => c.String());
            AddColumn("dbo.Societys", "EnterbyName", c => c.String());
            AddColumn("dbo.Societys", "EnterbyId", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Enterby", c => c.String());
            AddColumn("dbo.Tbl_Cong", "EnterbyName", c => c.String());
            AddColumn("dbo.Tbl_Cong", "EnterbyId", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Enterby", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "EnterbyName", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "EnterbyId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "EnterbyId");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "EnterbyName");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Enterby");
            DropColumn("dbo.Tbl_Cong", "EnterbyId");
            DropColumn("dbo.Tbl_Cong", "EnterbyName");
            DropColumn("dbo.Tbl_Cong", "Enterby");
            DropColumn("dbo.Societys", "EnterbyId");
            DropColumn("dbo.Societys", "EnterbyName");
            DropColumn("dbo.Societys", "Enterby");
        }
    }
}
