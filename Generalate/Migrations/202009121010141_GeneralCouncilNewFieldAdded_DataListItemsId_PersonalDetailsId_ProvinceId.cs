namespace Generalate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralCouncilNewFieldAdded_DataListItemsId_PersonalDetailsId_ProvinceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralCouncils", "DataListItemsId", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralCouncils", "PersonalDetailsId", c => c.Long());
            AddColumn("dbo.GeneralCouncils", "ProvinceId", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralCouncils", "ProvinceId");
            DropColumn("dbo.GeneralCouncils", "PersonalDetailsId");
            DropColumn("dbo.GeneralCouncils", "DataListItemsId");
        }
    }
}
