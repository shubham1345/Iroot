namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class familyAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyDetails", "FamilyNationality", c => c.String());
            AddColumn("dbo.FamilyDetails", "FamilyProfession", c => c.String());
            AddColumn("dbo.FamilyDetails", "FamilyRemarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FamilyDetails", "FamilyRemarks");
            DropColumn("dbo.FamilyDetails", "FamilyProfession");
            DropColumn("dbo.FamilyDetails", "FamilyNationality");
        }
    }
}
