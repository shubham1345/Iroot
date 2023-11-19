namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtbladdedinpro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_DistSecCouncil", "MemberName", c => c.String());
            AddColumn("dbo.tbl_DistSecCouncil", "DesignationName", c => c.String());
            AddColumn("dbo.tbl_DistSecCouncil", "ResponsibilityName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_DistSecCouncil", "ResponsibilityName");
            DropColumn("dbo.tbl_DistSecCouncil", "DesignationName");
            DropColumn("dbo.tbl_DistSecCouncil", "MemberName");
        }
    }
}
