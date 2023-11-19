namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FamilyDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyDetails", "Country", c => c.String());
            AddColumn("dbo.FamilyDetails", "Nationality", c => c.String());
            AddColumn("dbo.FamilyDetails", "LangSpocken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FamilyDetails", "LangSpocken");
            DropColumn("dbo.FamilyDetails", "Nationality");
            DropColumn("dbo.FamilyDetails", "Country");
        }
    }
}
