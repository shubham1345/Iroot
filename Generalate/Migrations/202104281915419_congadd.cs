namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class congadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Cong", "PostalCode", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Enitity", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Continent", c => c.String());
            AddColumn("dbo.Tbl_Cong", "CommunityType", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Cong", "StartDate", c => c.String());
            AddColumn("dbo.Tbl_Cong", "EndDate", c => c.String());
            AddColumn("dbo.Tbl_Cong", "SuspensionDate", c => c.String());
            AddColumn("dbo.Tbl_Cong", "RestartDate", c => c.String());
            AddColumn("dbo.Tbl_Cong", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Cong", "Remark");
            DropColumn("dbo.Tbl_Cong", "RestartDate");
            DropColumn("dbo.Tbl_Cong", "SuspensionDate");
            DropColumn("dbo.Tbl_Cong", "EndDate");
            DropColumn("dbo.Tbl_Cong", "StartDate");
            DropColumn("dbo.Tbl_Cong", "Status");
            DropColumn("dbo.Tbl_Cong", "CommunityType");
            DropColumn("dbo.Tbl_Cong", "Continent");
            DropColumn("dbo.Tbl_Cong", "Enitity");
            DropColumn("dbo.Tbl_Cong", "PostalCode");
        }
    }
}
