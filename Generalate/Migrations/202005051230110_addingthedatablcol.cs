namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingthedatablcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComHouses", "Activities", c => c.String());
            AddColumn("dbo.ComHouses", "Diocese", c => c.String());
            AddColumn("dbo.ComOutSides", "Activities", c => c.String());
            AddColumn("dbo.ComOutSides", "Diocese", c => c.String());
            AddColumn("dbo.Societys", "Activities", c => c.String());
            AddColumn("dbo.Societys", "Diocese", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Activities", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Diocese", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Activities", c => c.String());
            AddColumn("dbo.Tbl_ParisInstitutionDetails", "Diocese", c => c.String());
            AddColumn("dbo.tbl_Province", "Activities", c => c.String());
            AddColumn("dbo.tbl_Province", "Diocese", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Province", "Diocese");
            DropColumn("dbo.tbl_Province", "Activities");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Diocese");
            DropColumn("dbo.Tbl_ParisInstitutionDetails", "Activities");
            DropColumn("dbo.Tbl_Cong", "Diocese");
            DropColumn("dbo.Tbl_Cong", "Activities");
            DropColumn("dbo.Societys", "Diocese");
            DropColumn("dbo.Societys", "Activities");
            DropColumn("dbo.ComOutSides", "Diocese");
            DropColumn("dbo.ComOutSides", "Activities");
            DropColumn("dbo.ComHouses", "Diocese");
            DropColumn("dbo.ComHouses", "Activities");
        }
    }
}
